using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.LoggerAdapter;
using Vueling.Common.Logic.Models;

namespace Vueling.DataAccess.Dao
{
    public class StudentDaoTxt : IStudentDao
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Logger logger = new Logger();
        private readonly string path = FileUtils.GetPath() + ".txt";

        private Student readstudent;
        private Student studentread;
        private List<Student> liststudents;
        private string[] linesplit;

        public Student Add(Student student)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " iniciado");

            try
            {
                this.SetStudent(student, path);
                studentread = this.GetStudentByGuid(student.Student_Guid, path);
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace + e.Message);
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
            catch (System.Security.SecurityException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (NotSupportedException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (UnauthorizedAccessException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (PathTooLongException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (IOException e)
            {
                logger.Error(e.StackTrace + e.Message);
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
            catch (System.Security.SecurityException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (NotSupportedException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (UnauthorizedAccessException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (PathTooLongException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (IOException e)
            {
                logger.Error(e.StackTrace + e.Message);
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
            catch (System.Security.SecurityException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (NotSupportedException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (UnauthorizedAccessException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (PathTooLongException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (IOException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            finally
            {
                //if ()
                //
            }
            return liststudents;
        }
    }
}
