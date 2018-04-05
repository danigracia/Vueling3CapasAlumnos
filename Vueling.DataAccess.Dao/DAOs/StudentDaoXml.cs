using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;

namespace Vueling.DataAccess.Dao
{
    public class StudentDaoXml : IStudentDao
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string path = FileUtils.GetPath() + ".xml";

        public Student Add(Student student)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");

            //FileUtils.SetStudentToXml(student, path);
            this.SetStudent(student, path);

            #region logs
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
            Student studentread;
            //studentread = FileUtils.GetStudentFromXmlByGuid(student.Student_Guid, path);
            studentread = this.GetStudentByGuid(student.Student_Guid, path);

            foreach (PropertyInfo prop in typeof(Student).GetProperties())
            {
                log.Info("studentread." + prop.Name + ": " + prop.GetValue(studentread) + ", student." + prop.Name + ": " + prop.GetValue(student));
                Console.WriteLine(prop.Name);
            }
            #endregion

            //return FileUtils.GetStudentFromXmlByGuid(student.Student_Guid, path);
            return this.GetStudentByGuid(student.Student_Guid, path);
        }

        private void SetStudent(Student student, string path)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");
            List<Student> liststudents = new List<Student>();

            XmlSerializer serializer = new XmlSerializer(liststudents.GetType());

            if (File.Exists(path))
            {
                using (TextReader reader = new StreamReader(path))
                {
                    String readtoend = reader.ReadToEnd();
                    StringReader streader = new StringReader(readtoend);
                    liststudents = (List<Student>)serializer.Deserialize(streader);
                }
                using (TextWriter writer = new StreamWriter(path))
                {
                    liststudents.Add(student);
                    serializer.Serialize(writer, liststudents);
                }
            }
            else
            {
                using (TextWriter writer = new StreamWriter(path))
                {
                    liststudents.Add(student);
                    serializer.Serialize(writer, liststudents);
                }
            }

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
        }

        private Student GetStudentByGuid(Guid studentguid, string path)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");

            List<Student> alllines = new List<Student>();
            Student studentread = new Student();

            XmlSerializer serializer = new XmlSerializer(alllines.GetType());

            using (TextReader reader = new StreamReader(path))
            {
                String readtoend = reader.ReadToEnd();
                StringReader streader = new StringReader(readtoend);
                alllines = (List<Student>)serializer.Deserialize(streader);
            }

            foreach (Student st in alllines)
            {
                if (st.Student_Guid == studentguid) studentread = st;
            }

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
            log.Info("Datos del student leido del file xml:");

            return studentread;
        }



        public List<Student> ReadAll()
        {

            List<Student> liststudents = new List<Student>();

            XmlSerializer serializer = new XmlSerializer(liststudents.GetType());

            if (File.Exists(path))
            {
                using (TextReader reader = new StreamReader(path))
                {
                    String readtoend = reader.ReadToEnd();
                    StringReader streader = new StringReader(readtoend);
                    liststudents = (List<Student>)serializer.Deserialize(streader);
                }
            }
            log.Info("Datos del student leido del file xml:");

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
            return liststudents;
        }

        public List<Student> Buscar(string text, string property)
        {
            List<Student> liststudent = this.ReadAll();
            List<Student> liststudentfound = new List<Student>();

            IEnumerable<Student> query = from st in liststudent
                                         where st.GetType().GetProperty(property).GetValue(st).ToString() == text
                                         select st;

            foreach (Student student in query)
            {
                liststudentfound.Add(student);
            }
            return liststudentfound;
        }
    }
}