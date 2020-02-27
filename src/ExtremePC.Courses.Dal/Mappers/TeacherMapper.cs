using ExtremePC.Courses.Dal.Entites;
using ExtremePC.Courses.Definition.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtremePC.Courses.Dal.Mappers
{
    internal  static class TeacherMapper
    {
        public static TeacherEntity Map(this TeacherModel model)
        {
            var entity = new TeacherEntity();
            if (model != null)
            {
                entity.Id = model.Id;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
            }
            return entity;               
        }
        public static TeacherModel Map(this TeacherEntity entity)
        {
            var model = new TeacherModel();
            if (entity != null)
            {
                model.Id = entity.Id;
                model.FirstName = entity.FirstName;
                model.LastName = entity.LastName;
            }
            return model;
        }
    }
}
