using ExtremePC.Courses.Definition.DataInterfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremePC.Courses.Dal.Entites.Abstract
{
    public abstract class BaseEntity : IChangeTrackedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long Id { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public DateTime ChangedDateTimeUtc { get; set; }
    }
}
