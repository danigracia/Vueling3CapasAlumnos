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

namespace Vueling.Business.Logic.Logics
{
    public class FileBL : IFileBL
    {
        AbstarctFactory formfact;
        SingletonJson sinjson;
        SingletonXml sinxml;
        List<Student> liststudent;
        private List<Student> liststudentfound;

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
            //liststudent = (formfact.CreateStudentFormat(format)).Buscar(textabuscar, propertyabuscar);

            try
            {
                liststudent = (formfact.CreateStudentFormat(format)).ReadAll();
                liststudentfound = new List<Student>();

                IEnumerable<Student> query = from st in liststudent
                                             where st.GetType().GetProperty(propertyabuscar).GetValue(st).ToString() == textabuscar
                                             select st;


                foreach (Student student in query)
                {
                    liststudentfound.Add(student);
                }
            }
            catch (IOException e)
            {
                //logger.Error("Error en el metodo Buscar()" + e.Message);
                throw;
            }
            return liststudentfound;



            return liststudent;
        }

    }
}
