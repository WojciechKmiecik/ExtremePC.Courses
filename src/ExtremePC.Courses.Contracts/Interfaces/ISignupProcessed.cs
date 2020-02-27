using System;
using System.Collections.Generic;
using System.Text;

namespace ExtremePC.Courses.Contracts.Interfaces
{
    public interface ISignupProcessed
    {
        public bool Result { get; set; }
        public string Message { get; set; }// confirmation, or faliure. Could be send via e-mail or signalR
    }
}
