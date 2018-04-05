using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Business.Logic.Interfaces;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Singletons;
using Vueling.DataAccess.Dao.Factories;

namespace Vueling.Business.Logic.Logics
{
    public class FileBL : IFileBL
    {

        public List<Student> ReadFile(Config con)
        {
            AbstarctFactory formfact = new FormatFactory();
            return (formfact.CreateStudentFormat(con)).ReadAll();
        }

        public void FillSingletons()
        {
            SingletonJson sinjson = SingletonJson.Instance;
            SingletonXml sinxml = SingletonXml.Instance;
        }

        public List<Student> Buscar(Config format, string textabuscar, string propertyabuscar)
        {
            List<Student> liststudent;
            AbstarctFactory formfact = new FormatFactory();
            liststudent = (formfact.CreateStudentFormat(format)).Buscar(textabuscar, propertyabuscar);

            return liststudent;
        }

    }
}
