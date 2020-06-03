using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculateServices
{
   public interface ILog
    {
        public void LogWrite(string msg);
    }
    public class Log : ILog
    {
        public void LogWrite(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
