using SampleApp.Base;
using SampleApp.Base.Entities;
using SimpleStack.Orm.Attributes;
using System;

namespace SampleApp.DataAccess.Tables
{
    [TableWithSequence("student", SequenceName = "student_id_seq")]
    [Alias("student")]
    public class Student:IStudent
    {

        public Student()
        {
        }

        [PrimaryKey]
        [AutoIncrement]
        public long Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string address { get; set; }

        [Alias("is_active")]
        public Boolean IsActive { get; set; }
        
         [Alias("class_id")]
        public int ClassId { get; set; }

        [Alias("created_by")]
        public long? CreatedBy { get; set; }

        [Alias("created_date")]
        public DateTime? CreatedDate { get; set; }

        [Alias("modified_by")]
        public long? ModifiedBy { get; set; }

        [Alias("modified_date")]
        public DateTime? ModifiedDate { get; set; }

        [Alias("birth_date")]
        public DateTime? BirthDate { get; set; }

    }
}
