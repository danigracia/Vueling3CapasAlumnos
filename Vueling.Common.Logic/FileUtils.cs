using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;

namespace Vueling.Common.Logic
{
    public class FileUtils
    {
        //Serializar
        //Deserializar
        //Crear fichero
        

        public static string GetPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + typeof(Student).Name;
        }

    public List<Student> ReadAllTxt()
        {

        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + typeof(Student).Name + ".txt";
        Student readstudent;
            List<Student> liststudents = new List<Student>();
            string[] linesplit;

            if (File.Exists(path))
            {                
                var alllines = File.ReadAllLines(path);
                foreach (string line in alllines)
                {
                    linesplit = line.Split(',');
                    readstudent = new Student(Int32.Parse(linesplit[0]), linesplit[1], linesplit[2], Int32.Parse(linesplit[3]), linesplit[4], linesplit[5], linesplit[6]);

                    liststudents.Add(readstudent);
                }
            }
            return liststudents;
        }
    }
}
