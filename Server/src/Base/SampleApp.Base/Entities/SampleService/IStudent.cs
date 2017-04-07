using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.Base.Entities
{
    public interface IStudent : IEntity, IStamp
    {
        string Name { get; set; }
        string address { get; set; }

        DateTime? BirthDate { get; set; }
        Boolean IsActive { get; set; }
             
        int ClassId { get; set; }
    }
}
