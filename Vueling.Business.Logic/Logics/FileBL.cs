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
        public void FileBusinessLogic()
        {

        }

        public List<Student> ReadFile(Config formato)
        {
            AbstarctFactory formfact = new FormatFactory();

            return (formfact.CreateStudentFormat(formato.ToString())).ReadAll();
        }

        public void FillSingletons()
        {
            SingletonJson sinjson = SingletonJson.Instance;
            SingletonXml sinxml = SingletonXml.Instance;
        }

        public void Buscar()
        {
            /*
            string chosen = checkedListBoxProperties.SelectedItem.ToString();

            IEnumerable<Student> query = from st in liststudent
                                         where st.Nombre == this.textBoxBusquedaGeneral.Text
                                         orderby st
                                         select st;
            return;
            */
        }

    }
}
