﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vueling.Common.Logic.LoggerAdapter;
using Vueling.Common.Logic.Models;

namespace Vueling.Common.Logic
{
    public class FileUtils
    {
        private static readonly Logger logger = new Logger();

        public static string GetPath()
        {
            try
            {
                //return Environment.GetEnvironmentVariable("FolderToSave", EnvironmentVariableTarget.User) + @"\" + typeof(Student).Name;
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + typeof(Student).Name;
            }
            catch (AccessViolationException)
            {
                logger.Error("Error en el metodo GetPath()");
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Error("Error en el metodo GetPath()");
                throw;
            }
            catch (PlatformNotSupportedException e)
            {
                logger.Error("Error en el metodo GetPath()");
                throw;
            }
        }

        public static void SetFormat(Config con)
        {
            string st = CommonResources.ResourceLogger.StartMethod;
            try
            {
                Environment.SetEnvironmentVariable("Save_Format", con.ToString(), EnvironmentVariableTarget.User);
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e.Message);
            }
            catch (ArgumentException e)
            {
                logger.Error(e.Message);
            }
            catch (System.Security.SecurityException e)
            {
                logger.Error(e.Message);
            }
        }

    }
}