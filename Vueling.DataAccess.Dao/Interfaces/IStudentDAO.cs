﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;

namespace Vueling.DataAccess.Dao
{
    public interface IStudentDao
    {
        Student Add(Student student);
        List<Student> Buscar(string text, string property);
        List<Student> ReadAll();
    }
}
