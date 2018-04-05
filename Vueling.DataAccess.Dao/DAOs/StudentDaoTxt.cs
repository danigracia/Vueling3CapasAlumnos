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

    }
}
