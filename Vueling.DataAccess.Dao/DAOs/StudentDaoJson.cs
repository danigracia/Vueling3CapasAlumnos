using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;

namespace Vueling.DataAccess.Dao
{
    public class StudentDaoJson : IStudentDao
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public Student Add(Student student)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");

            string path = FileUtils.GetPath() + ".json";

            FileUtils.SetStudentToJson(student, path);

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");

            return FileUtils.GetStudentFromJsonByGuid(student.Student_Guid, path);

        }

        public List<Student> ReadAll()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + typeof(Student).Name + ".json";
            List<Student> liststudents = new List<Student>();

            if (File.Exists(path))
            {
                liststudents = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(path));

                log.Info("Datos del student leido del file json:");
            }


            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
            return liststudents;
        }
    }
}
