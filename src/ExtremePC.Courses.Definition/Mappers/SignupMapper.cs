
using ExtremePC.Courses.Definition.Models;

namespace ExtremePC.Courses.Dal.Mappers
{
    public  static class SignupMapper
    {
        
        public static StudentModel Map(this SignupModel incomingModel)
        {
            var model = new StudentModel();
            if (incomingModel != null)
            {
                model.FirstName = incomingModel.FirstName;
                model.LastName = incomingModel.LastName;
                model.Age = incomingModel.Age;
            }
            return model;
        }
    }
}
