using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vueling.Common.Logic.Models;

namespace Vueling.Common.Logic
{
    public class FileUtils
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string GetPath()
        {
            try
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + typeof(Student).Name;
            }
            catch (AccessViolationException)
            {
                log.Error("Error en el metodo GetPath()");
                throw;
            }
        }

    }
}