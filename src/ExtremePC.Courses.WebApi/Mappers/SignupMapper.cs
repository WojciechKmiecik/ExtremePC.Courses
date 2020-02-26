using ExtremePC.Courses.Definition.Models;
using ExtremePC.Courses.WebApi.WebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtremePC.Courses.WebApi.Mappers
{
    public static class SignupMapper
    {
        public static SignupModel Map(this StudentSignUpWebModel webModel, long? Id = 0)
        {
            var model = new SignupModel();
            if (webModel != null)
            {
                model.Age = webModel.Age;
                model.FirstName = webModel.FirstName;
                model.LastName = webModel.LastName;
                model.Id = Id ?? 0;
            }
            return model;
        }
    }
}
