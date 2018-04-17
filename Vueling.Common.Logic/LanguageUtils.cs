using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vueling.Common.Logic
{
    public class LanguageUtils
    {
        // posar loggs
        public static void SetLanguaje()
        {
            //CultureInfo culture = new CultureInfo(Environment.GetEnvironmentVariable("Student_Languaje", EnvironmentVariableTarget.User));
            string culture = Environment.GetEnvironmentVariable("Student_Languaje", EnvironmentVariableTarget.User);

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);

            //Thread.CurrentThread.CurrentUICulture = culture;
            //Thread.CurrentThread.CurrentCulture = culture;
        }   
    }
}
