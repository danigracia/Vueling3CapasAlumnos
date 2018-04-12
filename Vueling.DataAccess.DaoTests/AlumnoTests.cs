using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Vueling.DataAccess.Dao.Factories;
using static Vueling.Common.Logic.Enums.TiposFichero;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;
using Newtonsoft.Json;
using Vueling.Business.Logic;

namespace Vueling.DataAccess.Dao.Tests
{
    [TestClass()]
    public class AlumnoTests
    {
        FicheroFactory ficheroFactory;

        [TestInitialize]
        public void Initialize()
        {
            this.InicializarVariables();
            this.EliminarFichero();
        }

        private void EliminarFichero()
        {
            string pathFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json");
            if (File.Exists(pathFile))
            {
                File.Delete(pathFile);
            }
            string[] fileEntries = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.*");
            for (int i = 0; i < fileEntries.Length; ++i)
            {
                File.Delete(fileEntries[i]);
            }
        }

        private void InicializarVariables()
        {
            this.ficheroFactory = new FicheroFactory();
        }

        [DataRow(TipoFichero.Texto, "MiPrimerFicheroTxt.txt")]
        [DataRow(TipoFichero.Json, "MiPrimerFicheroJson.json")]
        [DataRow(TipoFichero.Xml, "MiPrimerFicheroJson.xml")]
        [DataTestMethod]
        public void CrearTipoFicheroFactoryTest(TipoFichero tipo, string nombre)
        {
            IFichero fichero = (IFichero)ficheroFactory.CrearFichero(tipo, nombre);
            switch (tipo)
            {
                case TipoFichero.Json:
                    Assert.IsTrue(fichero.GetType() == typeof(FicheroJson));
                    break;
                case TipoFichero.Texto:
                    Assert.IsTrue(fichero.GetType() == typeof(FicheroTxt));
                    break;
                case TipoFichero.Xml:
                    Assert.IsTrue(fichero.GetType() == typeof(FicheroXml));
                    break;
            }
        }

        [DataRow(TipoFichero.Texto, "ListadoDeAlumnos.txt", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataRow(TipoFichero.Json, "ListadoDeAlumnos.json", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataRow(TipoFichero.Xml, "ListadoDeAlumnos.xml", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void CrearFicheroTest(TipoFichero tipo, string nombreFichero, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            IFichero fichero = (IFichero)ficheroFactory.CrearFichero(tipo, nombreFichero);
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));

            fichero.Guardar(alumno);
            Assert.IsTrue(File.Exists(fichero.Ruta));
        }

        [DataRow(TipoFichero.Texto, "ListadoDeAlumnos.txt", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void GuardarAlumnoFicheroTextoTest(TipoFichero tipo, string nombreFichero, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            IFichero fichero = (IFichero)ficheroFactory.CrearFichero(tipo, nombreFichero);
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));

            fichero.Guardar(alumno);

            Alumno alumnoFichero = FileUtils.DeserializeTexto(fichero.Ruta);
            Assert.IsTrue(alumno.Equals(alumnoFichero));
        }

        [DataRow(TipoFichero.Json, "ListadoDeAlumnos.json", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void GuardarAlumnoFicheroJsonTest(TipoFichero tipo, string nombreFichero, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            IFichero fichero = (IFichero)ficheroFactory.CrearFichero(tipo, nombreFichero);
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));

            fichero.Guardar(alumno);

            Alumno alumnoFichero = FileUtils.DeserializeJson(fichero.Ruta);
            Assert.IsTrue(alumno.Equals(alumnoFichero));
        }

        [DataRow(TipoFichero.Xml, "ListadoDeAlumnos.xml", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void GuardarAlumnoFicheroXmlTest(TipoFichero tipo, string nombreFichero, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            IFichero fichero = (IFichero)ficheroFactory.CrearFichero(tipo, nombreFichero);
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));

            fichero.Guardar(alumno);

            Alumno alumnoFichero = FileUtils.DeserializeXml(fichero.Ruta);
            Assert.IsTrue(alumno.Equals(alumnoFichero));
        }

        [DataRow("22-01-1992", 26)]
        [DataRow("22-05-1992", 26)]
        [DataTestMethod]
        public void CalcularEdadTest(string fechaNacimiento, int resultado)
        {
            AlumnoBL alumnoBl = new AlumnoBL();
            int edad = alumnoBl.CalcularEdad(Convert.ToDateTime(fechaNacimiento));
            Assert.IsTrue(resultado == edad);
        }
    }
}