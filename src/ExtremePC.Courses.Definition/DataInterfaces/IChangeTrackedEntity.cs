using System;

namespace ExtremePC.Courses.Definition.DataInterfaces
{
    public interface IChangeTrackedEntity
    {
        DateTime CreatedDateTimeUtc { get; set; }
        DateTime ChangedDateTimeUtc { get; set; }
    }
}
