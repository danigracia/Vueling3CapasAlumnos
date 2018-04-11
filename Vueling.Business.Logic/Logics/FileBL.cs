using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Business.Logic.Interfaces;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Singletons;
using Vueling.DataAccess.Dao.Factories;
using System.IO;
using Vueling.Common.Logic.LoggerAdapter;

namespace Vueling.Business.Logic.Logics
{
    public class FileBL : IFileBL
    {
        private AbstarctFactory formfact;
        private SingletonJson sinjson;
        private SingletonXml sinxml;
        private List<Student> liststudent;
        private List<Student> liststudentfound;

        private readonly Logger logger = new Logger();

        public List<Student> ReadFile(Config con)
        {
            formfact = new FormatFactory();
            return (formfact.CreateStudentFormat(con)).ReadAll();
        }

        public void FillSingletons()
        {
            sinjson = SingletonJson.Instance;
            sinxml = SingletonXml.Instance;
        }

        public List<Student> Buscar(Config format, string textabuscar, string propertyabuscar)
        {
            formfact = new FormatFactory();

            try
            {
                liststudent = this.ReadFile(format);
                liststudentfound = new List<Student>();

                IEnumerable<Student> query = from st in liststudent
                                             where st.GetType().GetProperty(propertyabuscar).GetValue(st).ToString() == textabuscar
                                             select st;

                foreach (Student student in query)
                {
                    liststudentfound.Add(student);
                }
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (IOException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            return liststudentfound;
        }
    }
}
