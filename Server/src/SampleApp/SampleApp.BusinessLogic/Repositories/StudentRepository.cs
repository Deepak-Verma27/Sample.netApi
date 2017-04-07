using Dapper;
using Npgsql;
using SampleApp.Base.Entities;
using SampleApp.Base.Objects;
using SampleApp.Base.Repositories;
using SampleApp.BusinessLogic.Base;
using SampleApp.DataAccess;
using SampleApp.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.BusinessLogic.Repositories
{
    public class StudentRepository<TStudent>: ModuleBaseRepository<TStudent>, IStudentRepository
        where TStudent : class, IStudent, new()
    {
        public StudentRepository(BaseValidationErrorCodes errorCodes, DatabaseContext dbContext)
            : base(errorCodes, dbContext)
        {

        }

        public async Task<IStudent> AddNew(IStudent entity)
        {
            try
            {
                TStudent tEntity = entity as TStudent;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                {
                    await this.ThrowEntityException(errors);
                }

                var savedEntity = await base.AddNew(tEntity);
                return savedEntity;
            }
            catch (PostgresException ex)
            {
                throw new EntityUpdateException(ex);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IStudent> Update(IStudent entity)
        {
            try
            {
                TStudent tEntity = entity as TStudent;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                {
                    await this.ThrowEntityException(errors);
                }

                var savedEntity = await base.Update(tEntity, x => new
                {
                    x.Name,
                    x.address,
                    x.BirthDate,
                    x.ClassId,                                                               
                    x.ModifiedBy,                   
                    x.ModifiedDate
                });
                return entity;
            }
            catch (PostgresException ex)
            {
                throw new EntityUpdateException(ex);
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await this.Connection.DeleteAllAsync<TStudent>(i => i.Id == id);
            }
            catch (PostgresException ex)
            {
                throw new EntityUpdateException(ex);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IStudent>> FindAll()
        {
            return await this.Connection.SelectAsync<TStudent>();
        }

        public async Task<IEnumerable<CustomDDO>> FindAllDDO()
        {
            var expression = this.Connection.DialectProvider.ExpressionVisitor<TStudent>().Select(i => new { i.Id, i.Name });

            return await this.Connection.QueryAsync<CustomDDO>(expression.SelectExpression);
        }

        private async Task<bool> CheckDuplicate(IStudent entity)
        {
            var role = await this.Connection.FirstOrDefaultAsync<TStudent>(i => i.Name == entity.Name && i.Id != entity.Id);
            return role != null;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(TStudent entity)
        {
            return await this.ValidateEntity(entity);
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(TStudent entity)
        {
            return await this.ValidateEntity(entity);
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntity(TStudent entity)
        {
            ICollection<IValidationResult> errors = (await base.ValidateEntity(entity)).ToList();

            if (await this.CheckDuplicate(entity))
            {
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.RoleAlreadyExist, entity.Name]));
            }
            return errors;
        }
    
    }
}
