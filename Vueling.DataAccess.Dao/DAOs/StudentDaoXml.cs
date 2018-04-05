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
        private List<Student> liststudents;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public Student Add(Student student)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");

            string path = FileUtils.GetPath() + ".xml";

            FileUtils.SetStudentToXml(student, path);

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
            Student studentread = new Student();
            studentread = FileUtils.GetStudentFromXmlByGuid(student.Student_Guid, path);

            foreach (PropertyInfo prop in typeof(Student).GetProperties())
            {
                log.Info("studentread." + prop.Name + ": " + prop.GetValue(studentread) + ", student." + prop.Name + ": " + prop.GetValue(student));
                Console.WriteLine(prop.Name);
            }


            /*
            log.Info("studenttest G: " + studentread.Student_Guid + ", stuednt G:" + student.Student_Guid);
            log.Info("studenttest: " + studentread.FechaNacimiento + ", stuednt:" + student.FechaNacimiento);
            log.Info("studenttest: " + studentread.Nombre + ", stuednt:" + student.Nombre);
            log.Info("studenttest: " + studentread.Edad + ", stuednt:" + student.Edad);
            log.Info("studenttest: " + studentread.HoraRegistro + ", stuednt:" + student.HoraRegistro);
            log.Info("studenttest: " + studentread.IdAlumno + ", stuednt:" + student.IdAlumno);
            log.Info("studenttest: " + studentread.Apellido + ", stuednt:" + student.Apellido);
            log.Info("studenttest: " + studentread.SavedFormat + ", stuednt:" + student.SavedFormat);
            log.Info("studenttest: " + studentread.Dni + ", stuednt:" + student.Dni);
            */

            return FileUtils.GetStudentFromXmlByGuid(student.Student_Guid, path);
        }
    }
}