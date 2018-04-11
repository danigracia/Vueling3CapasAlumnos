﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestInitialize()]
        public void Initialize()
        {
            logger.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " iniciado");
            logger.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " terminado");
        }

        [TestCleanup]
        public void Cleanup()
        {
            mock_factory.VerifyAllExpectationsHaveBeenMet();
            mock_factory.ClearExpectations();
        }

        [TestMethod()]
        public void BusinessLogicTest()
        {
            logger.Info("Inici CompleteTest.");

            Mock<AbstarctFactory> Afactorymock = mock_factory.CreateMock<AbstarctFactory>(); //Createmock con la interfaç
            Mock<IStudentDao> Istudentmock = mock_factory.CreateMock<IStudentDao>();
            Mock<IStudentBL> Istudentblmock = mock_factory.CreateMock<IStudentBL>();

            Student student = new Student();
            Student studenttest;
            Student studentcomplete;
            Config format = new Config();

            Afactorymock.
                Expects.
                One.
                MethodWith(s => s.CreateStudentFormat(format)).
                WillReturn(Istudentmock.MockObject);
            
            IStudentDao isttest = Afactorymock.MockObject.CreateStudentFormat(format);

            Istudentblmock.
                Expects.
                One.
                MethodWith(s => s.Complete(student)).
                WillReturn(student);

            studentcomplete = Istudentblmock.MockObject.Complete(student);

            Istudentmock.
                Expects.
                One.
                MethodWith(s => s.Add(student)).
                WillReturn(studentcomplete);

            studenttest = Istudentmock.MockObject.Add(studentcomplete);

            Assert.IsNotNull(isttest);
            Assert.IsTrue(student.Equals(studenttest));
        }
    }
}