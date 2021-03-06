﻿using SampleApp.Base.Entities;
using SampleApp.Base.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.Base.Repositories
{
    public interface IStudentRepository : IDepRepository
    {
        Task<IStudent> AddNew(IStudent entity);

        Task<IStudent> Update(IStudent entity);

        Task Delete(int id);

        Task<IEnumerable<IStudent>> FindAll();

        Task<IEnumerable<CustomDDO>> FindAllDDO();

    }
}
