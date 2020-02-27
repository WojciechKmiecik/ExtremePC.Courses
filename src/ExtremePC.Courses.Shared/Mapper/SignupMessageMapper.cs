using ExtremePC.Courses.Contracts.Messages;
using ExtremePC.Courses.Definition.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtremePC.Courses.Shared.Mapper
{
    public static class SignupMessageMapper
    {
        public static SignupStudentMessage Map(this SignupModel model)
        {
            var message = new SignupStudentMessage();
            if (model != null)
            {
                message.Age = model.Age;
                message.FirstName = model.FirstName;
                message.LastName = model.LastName;
                message.CourseId = model.Id;
            }
            return message;
        }

        public static (SignupModel, string) Map(this SignupStudentMessage message)
        {
            var model = new SignupModel();
            string guid = string.Empty;
            if (message != null)
            {
                model.Age = message.Age;
                model.FirstName = message.FirstName;
                model.LastName = message.LastName;
                model.Id = message.CourseId;
                guid = message.Guid?.ToString();
            }
            return (model, guid);
        }
    }
}
