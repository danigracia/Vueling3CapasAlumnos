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
    public class StudentDaoTxt : IStudentDao
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string path = FileUtils.GetPath() + ".txt";

        public Student Add(Student student)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + 
                " iniciado");

            //FileUtils.SetStudentToTxt(student, path);
            this.SetStudent(student, path);

            //return FileUtils.GetStudentFromTxtByGuid(student.Student_Guid, path);
            return this.GetStudentByGuid(student.Student_Guid, path);
        }

        private void SetStudent(Student student, string path)
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

        private Student GetStudentByGuid(Guid studentguid, string path)
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
            readstudent.SavedFormat = "txt";

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
            log.Info("Datos del student leido del file txt:");
            log.Info("datebirth:" + readstudent.FechaNacimiento.ToString());
            return readstudent;
        }


        public List<Student> ReadAll()
        {
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

        public List<Student> Buscar(string text, string property)
        {
            List<Student> liststudent = this.ReadAll();
            List<Student> liststudentfound = new List<Student>();

            // where st.Nombre == text

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
