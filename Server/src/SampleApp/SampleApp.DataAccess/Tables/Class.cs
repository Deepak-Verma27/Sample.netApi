using SampleApp.Base;
using SampleApp.Base.Entities.SampleService;
using SimpleStack.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.DataAccess.Tables
{
    [TableWithSequence("class", SequenceName = "class_id_seq")]
    [Alias("class")]
    public class Class:IClass
    {

        public Class()
        {
        }

        [PrimaryKey]
        [AutoIncrement]
        public long Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [Alias("name")]
        public string Name { get; set; }
        [Alias("created_by")]
        public long? CreatedBy { get; set; }

        [Alias("created_date")]
        public DateTime? CreatedDate { get; set; }

        [Alias("modified_by")]
        public long? ModifiedBy { get; set; }

        [Alias("modified_date")]
        public DateTime? ModifiedDate { get; set; }

    }

}
