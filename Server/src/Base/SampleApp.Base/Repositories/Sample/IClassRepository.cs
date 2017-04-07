using SampleApp.Base.Entities.SampleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.Base.Repositories.Sample
{
    interface IClassRepository:IClass
    {
        Task<IClass> AddNew(IClass entity);

        Task<IClass> Update(IClass entity);

        Task Delete(int id);

        Task<IEnumerable<IClass>> FindAll();

        Task<IEnumerable<IClass>> FindAllDDO();
    }
}
