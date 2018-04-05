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
        private List<Student> liststudents;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public Student Add(Student student)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");
            liststudents = new List<Student>();

            string path = FileUtils.GetPath() + ".json";

            FileUtils.SetStudentToJson(student, path);

            //string path = ConfigurationManager.AppSettings["ConfigPathJson"].ToString();

            //var group = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(Filename));
            //return group.FirstOrDefault(i => (Guid)typeof(T).GetProperty("Guid").GetValue(i) == guid);

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");

            return FileUtils.GetStudentFromJsonByGuid(student.Student_Guid, path);

        }
    }
}
