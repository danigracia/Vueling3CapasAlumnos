using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Models;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.Presentation.WinSite
{
    public partial class AlumnoForm : Form
    {
        private Alumno alumno;
        private IAlumnoBL alumnoBL;

        public AlumnoForm()
        {
            InitializeComponent();
            alumno = new Alumno();
            alumnoBL = new AlumnoBL();
        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            Button buttonTxt = (Button)sender;
            this.LoadAlumnoData();
            alumnoBL.Add(alumno, TipoFichero.Texto);
            MessageBox.Show("El alumno se ha guardado correctamente!");
        }

        private void btnJson_Click(object sender, EventArgs e)
        {
            Button buttonJson = (Button)sender;
            this.LoadAlumnoData();
            alumnoBL.Add(alumno, TipoFichero.Json);
            MessageBox.Show("El alumno se ha guardado correctamente!");
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            Button buttonTxt = (Button)sender;
            this.LoadAlumnoData();
            alumnoBL.Add(alumno, TipoFichero.Xml);
            MessageBox.Show("El alumno se ha guardado correctamente!");
        }

        private void LoadAlumnoData()
        {
            alumno.Id = Convert.ToInt32(txtId.Text);
            alumno.Nombre = txtNombre.Text;
            alumno.Apellidos = txtApellidos.Text;
            alumno.Dni = txtDni.Text;
            alumno.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
        }
    }
}
