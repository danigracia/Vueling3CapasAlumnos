using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;

namespace Vueling.Business.Logic.Interfaces
{
    public interface IFileBL
    {
        void FillSingletons();
        List<Student> Buscar(Config format, string textabuscar, string propertyabuscar);
        List<Student> ReadFile(Config con);
    }
}
