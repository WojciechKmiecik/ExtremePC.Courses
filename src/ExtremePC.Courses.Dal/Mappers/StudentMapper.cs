using ExtremePC.Courses.Dal.Entites;
using ExtremePC.Courses.Definition.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtremePC.Courses.Dal.Mappers
{
    internal  static class StudentMapper
    {
        public static StudentEntity Map(this StudentModel model)
        {
            var entity = new StudentEntity();
            if (model != null)
            {
                entity.Id = model.Id;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
            }
            return entity;               
        }
        public static StudentModel Map(this StudentEntity entity)
        {
            var model = new StudentModel();
            if (model != null)
            {
                model.Id = entity.Id;
                model.FirstName = entity.FirstName;
                model.LastName = entity.LastName;
            }
            return model;
        }
    }
}
