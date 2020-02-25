using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ExtremePC.Courses.Definition.Error
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }


        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
