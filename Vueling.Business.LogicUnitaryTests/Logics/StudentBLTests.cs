using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMock;
using Vueling.Common.Logic.LoggerAdapter;
using Vueling.DataAccess.Dao;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Factories;
using System.IO;

namespace Vueling.Business.Logic.Tests
{
    [TestClass()]
    public class StudentBLTests
    {

        private readonly Logger logger = new Logger();
        private MockFactory mock_factory = new MockFactory();

        Mock<AbstarctFactory> Afactorymock; //Createmock con la interfaç
        Mock<IStudentDao> Istudentdaomock;
        Mock<IStudentBL> Istudentblmock;

        Student student;
        Student studenttest;
        Config format;

        [TestInitialize()]
        public void Initialize()
        {
            logger.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " iniciado");
            logger.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " terminado");
        }

        [TestCleanup()]
        public void Cleanup()
        {
            mock_factory.VerifyAllExpectationsHaveBeenMet();
            mock_factory.ClearExpectations();
        }

        [TestMethod()]
        public void BusinessLogicTest()
        {
            logger.Info("Inici CompleteTest.");

            student = new Student();
            format = new Config();

            Afactorymock = mock_factory.CreateMock<AbstarctFactory>();
            Istudentdaomock = mock_factory.CreateMock<IStudentDao>();
            Istudentblmock = mock_factory.CreateMock<IStudentBL>();

            Afactorymock.
                Expects.
                One.
                MethodWith(s => s.CreateStudentFormat(format)).
                WillReturn(Istudentdaomock.MockObject);

            Istudentblmock.
                Expects.
                One.
                MethodWith(s => s.Complete(student)).
                WillReturn(student);
       
            IStudentDao isttest = Afactorymock.MockObject.CreateStudentFormat(format);

            Student studentcomplete = Istudentblmock.MockObject.Complete(student);

            Istudentdaomock.
                Expects.
                One.
                MethodWith(s => s.Add(student)).
                WillReturn(studentcomplete);

            studenttest = Istudentdaomock.MockObject.Add(studentcomplete);

            Assert.IsNotNull(isttest);
            Assert.IsTrue(student.Equals(studenttest));
        }
    }
}