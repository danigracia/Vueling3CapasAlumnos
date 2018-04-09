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
        private readonly string path = FileUtils.GetPath() + ".json";

        public Student Add(Student student)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " iniciado");
            Student studentread;
            try
            {
                this.SetStudent(student, path);
                studentread = this.GetStudentByGuid(student.Student_Guid, path);
            }
            catch (IOException e)
            {
                log.Error("Error en el metodo SetStudent()" + e.Message);
                throw;
            }

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " terminado");
            return studentread;
        }

        private void SetStudent(Student student, string path)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");
            List<Student> liststudents;

            try
            {
                if (File.Exists(path))
                {
                    using (TextReader reader = new StreamReader(path))
                    {
                        liststudents = JsonConvert.DeserializeObject<List<Student>>(reader.ReadToEnd());
                    }
                    using (TextWriter writer = new StreamWriter(path))
                    {
                        liststudents.Add(student);
                        writer.Write(JsonConvert.SerializeObject(liststudents));
                    }
                }
                else
                {
                    using (TextWriter writer = new StreamWriter(path))
                    {
                        writer.WriteLine(student.ToJson());
                    }
                }
            }
            catch (IOException e)
            {
                log.Error("Error en el metodo ReadAllTxt()" + e.Message);
                throw;
            }

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
        }

        private Student GetStudentByGuid(Guid studentguid, string path)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");

            Student studentread = new Student();
            try
            {
                var alllines = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(path));
                foreach (Student st in alllines)
                {
                    if (st.Student_Guid == studentguid) studentread = st;
                }
            }
            catch (IOException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
            log.Info("Datos del student leido del file json:");

            return studentread;
        }


        public List<Student> ReadAll()
        {
            List<Student> liststudents = new List<Student>();

            try
            {
   
                if (File.Exists(path))
                {
                    liststudents = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(path));

                    log.Info("Datos del student leido del file json:");
                }

            }
            catch (IOException e)
            {
                log.Error("Error en el metodo ReadAll()" + e.Message);
                throw;
            }

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
            return liststudents;
        }

        public List<Student> Buscar(string text, string property)
        {
            List<Student> liststudent;
            List<Student> liststudentfound;
            try
            {
                liststudent = this.ReadAll();
                liststudentfound = new List<Student>();

                IEnumerable<Student> query = from st in liststudent
                                         where st.GetType().GetProperty(property).GetValue(st).ToString() == text
                                         select st;

                foreach (Student student in query)
                {
                    liststudentfound.Add(student);
                }
            }
            catch (IOException e)
            {
                log.Error("Error en el metodo Buscar()" + e.Message);
                throw;
            }
            return liststudentfound;
        }
    }
}
