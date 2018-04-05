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
        void FileBusinessLogic();
        void FillSingletons();
        void Buscar();
        List<Student> ReadFile(Config con);
    }
}
