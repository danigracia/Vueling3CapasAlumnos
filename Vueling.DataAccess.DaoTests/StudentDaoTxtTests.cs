using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Vueling.DataAccess.Dao.Factories;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.LoggerAdapter;
using NMock;

namespace Vueling.DataAccess.Dao.Tests
{
    [TestClass()]
    public class StudentDaoTxtTests
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Logger logger = new Logger();
        private MockFactory mock_factory = new MockFactory();

        #region Initialize, CleanUp
        [TestInitialize]
        public void Initialize()
        {
            log.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " iniciado");
            
            string[] AllFiles = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Student.*");
            foreach (string s  in AllFiles)
            {
                if(File.Exists(s)) File.Delete(s);
            }
            log.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " terminado");

        }

        [TestCleanup]
        public void Cleanup()
        {
            string[] AllFiles = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Student.*");
            foreach (string s in AllFiles)
            {
                File.Delete(s);
            }
            mock_factory.VerifyAllExpectationsHaveBeenMet();
            mock_factory.ClearExpectations();
        }
        #endregion

        [DataRow(1, "H", "J", 12, "1123-A", "12-05-1992")]
        [DataRow(2, "I", "F", 23, "98765434-L", "15-09-1982")]
        [DataRow(3, "G", "B", 11, "11111111-Z", "1-10-2012")]
        [DataTestMethod()]
        public void TxtAddTest(int id, string name, string surname, int edad, string dni, string datebirth)
        {
            log.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " iniciado");

            Student student = new Student(id, name, surname, edad, dni, datebirth);

            AbstarctFactory formatfactory = new FormatFactory();
            IStudentDao stddao = formatfactory.CreateStudentFormat(Config.txt);

            Student studenttest = stddao.Add(student);

            studenttest.SavedFormat = student.SavedFormat;

            log.Info("studenttest G: " + studenttest.Student_Guid + ", stuednt G:" + student.Student_Guid);
            log.Info("studenttest: " + studenttest.FechaNacimiento + ", stuednt:" + student.FechaNacimiento);
            log.Info("studenttest: " + studenttest.Nombre + ", stuednt:" + student.Nombre);
            log.Info("studenttest: " + studenttest.Edad + ", stuednt:" + student.Edad);
            log.Info("studenttest: " + studenttest.HoraRegistro + ", stuednt:" + student.HoraRegistro);
            log.Info("studenttest: " + studenttest.IdAlumno + ", stuednt:" + student.IdAlumno);
            log.Info("studenttest: " + studenttest.Apellido + ", stuednt:" + student.Apellido);
            log.Info("studenttest: " + studenttest.SavedFormat + ", stuednt:" + student.SavedFormat);
            log.Info("studenttest: " + studenttest.Dni + ", stuednt:" + student.Dni);

            Assert.IsTrue(student.Equals(studenttest));

            log.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " terminado");

        }

    }
}