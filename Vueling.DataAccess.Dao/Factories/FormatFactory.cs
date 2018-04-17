﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;

namespace Vueling.DataAccess.Dao.Factories
{
    // public class FormatFactory<T> where T : VuelingModelObject     //(T seria un Student)
    public class FormatFactory : AbstarctFactory
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public override IStudentDao CreateStudentFormat(Config typ)
        {

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");

            switch (typ)
            {
                case Config.txt: return new StudentDaoTxt();
                case Config.json: return new StudentDaoJson();
                case Config.xml: return new StudentDaoXml();
                case Config.sql: return new StudentDaoSql();
                default: throw new ArgumentException("Invalid type", "typ");
            }
        }
    }
}
