using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
  public  interface IInflationRate
    {
        double GetInflationRateByYear(int year);
    }
}
