using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.Base.Entities.SampleService
{
    public interface IClass : IEntity, IStamp
    {
        string Name { get; set; }
       
    }
}
