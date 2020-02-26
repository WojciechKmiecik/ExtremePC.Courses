using ExtremePC.Courses.Dal.Entites;
using ExtremePC.Courses.Definition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtremePC.Courses.Dal.Mappers
{
    internal  static class CourseMapper
    {
        public static CourseEntity Map(this CourseModel model)
        {
            var entity = new CourseEntity();
            if (model != null)
            {
                entity.Id = model.Id;
                entity.MaxCapacity = model.MaxCapacity;
                entity.TeacherId = model.TeacherId;
                entity.Topic = model.Topic;
                //TODO : Think fruther
            }
            return entity;               
        }
        public static CourseModel Map(this CourseEntity entity)
        {
            var model = new CourseModel();
            if (model != null)
            {
                model.Id = entity.Id;
                model.MaxCapacity = entity.MaxCapacity;
                model.TeacherId = entity.Teacher?.Id ?? 0;
                model.TeacherName = string.Concat(entity.Teacher?.FirstName, " ", entity.Teacher?.LastName);
                model.Topic = entity.Topic;
                model.Students = entity.CourseStudents?.Where(x => x.CourseId == model.Id)?.Select(x => x.Student?.Map())?.ToList();
            }
            return model;
        }
    }
}
