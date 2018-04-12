using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.DataAccess.Dao;
using Vueling.DataAccess.Dao.Factories;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Singletons;
using Vueling.Common.Logic.LoggerAdapter;

namespace Vueling.Business.Logic
{
    public class StudentBL : IStudentBL
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Logger logger = new Logger();
        readonly AbstarctFactory FormFac;
        private Config config;

        public StudentBL()
        {
            FormFac = new FormatFactory();
        }
        public void BusinessLogic(Student student)
        {
            logger.Info("Método " + System.Reflection.MethodBase.GetCurrentMethod().Name + " iniciado");

            config = (Config)Enum.Parse(typeof(Config), student.SavedFormat);

            try
            {
                (FormFac.CreateStudentFormat(config)).Add(this.Complete(student));
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }

            logger.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                        " terminado");
        }

        public Student Complete(Student student)
        {
            logger.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");

            this.GetAge(student);
            this.HoraRegistro(student);

            logger.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
            return student;
        }

        private void GetAge(Student student)
        {
            logger.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");
            try
            {
                int year = Convert.ToInt32(DateTime.Now.ToString("yyyy")) - Convert.ToInt32(student.FechaNacimiento.ToString("yyyy"));
                if (student.FechaNacimiento.DayOfYear > DateTime.Now.DayOfYear) year--;
                student.Edad = year;
            }
            catch (FormatException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (OverflowException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }

            logger.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
        }

        private void HoraRegistro(Student student)
        {
            logger.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");

            student.HoraRegistro = DateTime.Now;

            logger.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
        }
    }
}
