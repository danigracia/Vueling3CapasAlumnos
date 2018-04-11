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

        private Student readstudent;
        private Student studentread;
        private List<Student> liststudents;
        private List<Student> liststudentfound;
        private string[] linesplit;

        public Student Add(Student student)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " iniciado");

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
            try
            {
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
            }
            catch (IOException e)
            {
                log.Error("Error en el metodo SetStudent()" + e.Message);
                throw;
            }

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
        }

        private Student GetStudentByGuid(Guid studentguid, string path)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");

            try
            {              
                var alllines = File.ReadAllLines(path);
                string findstudent = "";
                foreach (string line in alllines)
                {
                    if (line.Contains(studentguid.ToString()))
                    {
                        findstudent = line;
                    }
                }

                var lineSplit = findstudent.Split(',');
                readstudent = new Student(Int32.Parse(lineSplit[0]), lineSplit[1], lineSplit[2], lineSplit[3], Int32.Parse(lineSplit[4]), lineSplit[5], lineSplit[6], lineSplit[7]);
                readstudent.SavedFormat = "txt";
            }
            catch (IOException e)
            {
                log.Error("Error en el metodo GetStudentFromTxtByGuid()" + e.Message);
                throw;
            }
            catch (FormatException e)
            {
                log.Error("Error de formato en el metodo GetStudentFromTxtByGuid()" + e.Message);
                throw;
            }

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
            log.Info("Datos del student leido del file txt:");
            log.Info("datebirth:" + readstudent.FechaNacimiento.ToString());

            return readstudent;
        }


        public List<Student> ReadAll()
        {
            liststudents = new List<Student>();

            try
            {
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
            }
            catch (IOException e)
            {
                log.Error("Error en el metodo ReadAllTxt()" + e.Message);
                throw;
            }
            finally
            {
                //if ()
                //
            }
            return liststudents;
        }

        /*
        public List<Student> Buscar(string text, string property)
        {
            List<Student> liststudent;

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
        */
    }
}
