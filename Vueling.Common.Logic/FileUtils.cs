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

        //Serializar
        //Deserializar
        //Crear fichero

        #region Path
        public static string GetPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + typeof(Student).Name;
        }
        #endregion


        #region TxtFileUtils

        public static void SetStudentToTxt(Student student, string path)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");
            if (!File.Exists(path))
            {
                using (StreamWriter stwriter = File.CreateText(path))
                {
                    stwriter.WriteLine(student.ToString());
                }
            }
            else
            {
                using (StreamWriter strw = File.AppendText(path))
                {
                    strw.WriteLine(student.ToString());
                }
            }
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
        }

        public static Student GetStudentFromTxtByGuid(Guid studentguid, string path)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");
            var alllines = File.ReadAllLines(path);
            string findstudent = "";
            foreach (string line in alllines)
            {
                if (line.Contains(studentguid.ToString()))
                {
                    findstudent = line;
                }
            }

            var linesplit = findstudent.Split(',');
            Student readstudent = new Student(Int32.Parse(linesplit[0]), linesplit[1], linesplit[2], linesplit[3], Int32.Parse(linesplit[4]), linesplit[5], linesplit[6], linesplit[7]);


            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
            log.Info("Datos del student leido del file txt:");
            log.Info("datebirth:" + readstudent.FechaNacimiento.ToString());
            return readstudent;
        }

        public List<Student> ReadAllTxt()
        {

        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + typeof(Student).Name + ".txt";
        Student readstudent;
            List<Student> liststudents = new List<Student>();
            string[] linesplit;

            if (File.Exists(path))
            {                
                var alllines = File.ReadAllLines(path);
                foreach (string line in alllines)
                {
                    linesplit = line.Split(',');
                    readstudent = new Student(Int32.Parse(linesplit[0]), linesplit[1], linesplit[2], linesplit[3], Int32.Parse(linesplit[4]), linesplit[5], linesplit[6], linesplit[7]);

                    liststudents.Add(readstudent);
                }
            }
            return liststudents;
        }
        #endregion

        #region JsonFileUtils
        public static void SetStudentToJson(Student student, string path)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");
            List<Student> liststudents = new List<Student>();

            //string path = ConfigurationManager.AppSettings["ConfigPathJson"].ToString();

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

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
        }

        public  static Student GetStudentFromJsonByGuid(Guid studentguid, string path)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");

            Student studentread = new Student();
            var alllines = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(path));
            foreach (Student st in alllines)
            {
                if (st.Student_Guid == studentguid) studentread = st;
            }

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
            log.Info("Datos del student leido del file json:");

            return studentread;
        }

        #endregion

        #region XmlFilUtils
        public static void SetStudentToXml(Student student, string path)
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

        public static Student GetStudentFromXmlByGuid(Guid studentguid, string path)
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
        #endregion
    }
}
