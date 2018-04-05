﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;

namespace Vueling.Common.Logic.Singletons
{
    public sealed class SingletonJson
    {
        private static SingletonJson instance = null;
        private static readonly object padlock = new object();
        readonly List<Student> liststudents;
        readonly FileUtils fu = new FileUtils();

        SingletonJson()
        {
            liststudents = fu.ReadAllJson();
        }

        public static SingletonJson Instance()
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonJson();
                    }
                }
            }
            return instance;
        }

        public List<Student> LoadAll()
        {
            return liststudents;
        }
    }
}
