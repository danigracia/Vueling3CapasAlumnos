﻿using System;
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
using Vueling.Common.Logic.LoggerAdapter;
using Vueling.Common.Logic.Models;

namespace Vueling.DataAccess.Dao
{
    public class StudentDaoXml : IStudentDao
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string path = FileUtils.GetPath() + ".xml";
        private readonly Logger logger = new Logger();

        private Student studentread;
        private List<Student> liststudents;
        private List<Student> alllines;

        public Student Add(Student student)
        {
            logger.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");
            
            try
            {
                this.SetStudent(student, path);
                studentread = this.GetStudentByGuid(student.Student_Guid, path);
            }
            catch (IOException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }

            #region logs
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
            foreach (PropertyInfo prop in typeof(Student).GetProperties())
            {
                log.Info("studentread." + prop.Name + ": " + prop.GetValue(studentread) + ", student." + prop.Name + ": " + prop.GetValue(student));
                Console.WriteLine(prop.Name);
            }
            #endregion

            return studentread;
        }

        private void SetStudent(Student student, string path)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");
            liststudents = new List<Student>();

            try
            {
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
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (OutOfMemoryException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (ObjectDisposedException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (FileNotFoundException e)
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

            alllines = new List<Student>();
            studentread = new Student();

            try
            {
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
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (OutOfMemoryException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (ObjectDisposedException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (FileNotFoundException e)
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
            log.Info("Datos del student leido del file xml:");

            return studentread;
        }

        public List<Student> ReadAll()
        {
            liststudents = new List<Student>();

            try
            {
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
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (OutOfMemoryException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (ObjectDisposedException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (FileNotFoundException e)
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

            log.Info("Datos del student leido del file xml:");

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
            return liststudents;
        }
    }
}