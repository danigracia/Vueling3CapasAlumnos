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


        public Student Add(Student student)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + 
                " iniciado");

            string path = FileUtils.GetPath() + ".txt";
            //string path = ConfigurationManager.AppSettings["ConfigPathTxt"].ToString();

            FileUtils.SetStudentToTxt(student, path);

            return FileUtils.GetStudentFromTxtByGuid(student.Student_Guid, path);
        }


        public List<Student> ReadAll()
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
    }
}
