using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;

namespace Vueling.DataAccess.Dao.Singletons
{
    public class SingletonXml
    {
        private static SingletonXml instance = null;
        private static readonly object padlock = new object();
        readonly List<Student> liststudents;
        readonly FileUtils fu = new FileUtils();

        protected SingletonXml()
        {
            liststudents = fu.ReadAllXml();
        }

        public static SingletonXml Instance
        {
            get
            {

                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonXml();
                        }
                    }
                }
                return instance;
            }
        }

        public List<Student> LoadAll()
        {
            return liststudents;
        }

    }
}
