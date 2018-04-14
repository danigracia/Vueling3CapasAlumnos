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
using System.Collections.ObjectModel;

namespace Vueling.Business.Logic.Logics
{
    public class FileBL : IFileBL
    {
        private readonly AbstarctFactory formfact;
        private static SingletonJson sinjson;
        private static SingletonXml sinxml;
        private List<Student> liststudent;

        private readonly Logger logger = new Logger();

        public FileBL()
        {
            formfact = new FormatFactory();
        }

        public List<Student> ReadFile(Config con)
        {
            switch (con)
            {
                case Config.txt:
                    return (formfact.CreateStudentFormat(con)).ReadAll();
                case Config.json:
                    return sinjson.LoadAll();
                case Config.xml:
                    return sinxml.LoadAll();
                default:
                    return (formfact.CreateStudentFormat(con)).ReadAll();
            }
        }

        public void FillSingletons()
        {
            sinjson = SingletonJson.Instance;
            sinxml = SingletonXml.Instance;
        }

        public List<Student> Buscar(Config format, string textabuscar, string propertyabuscar)
        {
            try
            {
                switch (format)
                {
                    case Config.txt:
                        liststudent = this.ReadFile(format);
                        break;
                    case Config.json:
                        liststudent = sinjson.LoadAll();
                        break;
                    case Config.xml:
                        liststudent = sinjson.LoadAll();
                        break;
                    default:
                        liststudent = this.ReadFile(format);
                        break;
                }

                IEnumerable<Student> liststudentfound = from st in liststudent
                                             where st.GetType().GetProperty(propertyabuscar).GetValue(st).ToString() == textabuscar
                                             select st;

                return liststudentfound.ToList<Student>();
            }
            catch (System.Reflection.AmbiguousMatchException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
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
        }
    }
}
