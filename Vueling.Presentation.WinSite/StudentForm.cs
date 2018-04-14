using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Models;
using System.Reflection;
using Vueling.Common.Logic;
using Vueling.Common.Logic.LoggerAdapter;
using Vueling.Presentation.WinSite.Resources;
using System.Globalization;
using System.Threading;

namespace Vueling.Presentation.WinSite
{

    public partial class StudentForm : Form
    {
        private Student student;
        private IStudentBL studentBL;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static ITargetAdapterForLogger logger = new Logger();
        public StudentForm()
        {
            InitializeComponent();
            student = new Student();
            studentBL = new StudentBL();
            AplicarIdioma();

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            logger.Warn("Warning de proba");
            log.Warn("Error de proba");

        }

        private void buttonTxt_Click(object sender, EventArgs e)
        {
            this.SaveStudentData(sender);

            try
            {
                studentBL.BusinessLogic(student);
            }
            catch (Exception ex)
            {
                MessageBox.Show(new StringBuilder(ex.StackTrace).Append(ex.Message).ToString());
            }
        }

        private void buttonJson_Click(object sender, EventArgs e)
        {
            this.SaveStudentData(sender);

            try
            {
                studentBL.BusinessLogic(student);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        private void buttonXml_Click(object sender, EventArgs e)
        {
            this.SaveStudentData(sender);

            try
            {
                studentBL.BusinessLogic(student);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        private void SaveStudentData(object sender)
        {
            try
            {
                logger.Info("Metodo SaveStudentData iniciado");
                student.Nombre = this.textBoxNombre.Text;
                student.IdAlumno = Convert.ToInt32(this.textBoxId.Text);
                student.Apellido = this.textBoxApellidos.Text;
                student.FechaNacimiento = Convert.ToDateTime(this.textBoxFechaNacimiento.Text);
                student.Dni = this.textBoxDni.Text;
                student.Student_Guid = Guid.NewGuid();
                student.SavedFormat = ((Button)sender).Text.ToLower();
                log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " terminado");
            }
            catch (FormatException e)
            {
                MessageBox.Show(String.Format(e.StackTrace + e.Message));
            }
            catch (TargetException e)
            {
                MessageBox.Show(String.Format(e.StackTrace + e.Message));
            }
            catch (OverflowException e)
            {
                MessageBox.Show(String.Format(e.StackTrace + e.Message));
            }
        }

        private void buttonToList_Click(object sender, EventArgs e)
        {

        }

        public void AplicarIdioma()
        {
            labelId.Text = StringResources.labelId;
            labelNombre.Text = StringResources.labelNombre;
            labelApellido.Text = StringResources.labelApellido;
            labelDni.Text = StringResources.labelDni;
            labelFechaNacimiento.Text = StringResources.labelFechaNacimiento;
            buttonToList.Text = StringResources.labelListaForm;
            this.Text = StringResources.FormName;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cbLanguages.SelectedItem.ToString());
            AplicarIdioma();
        }

        private void llistaDAlumnesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                StudentListForm studentlist = new StudentListForm();
                studentlist.ShowDialog(this);
            }
            catch (InvalidOperationException inv)
            {
                MessageBox.Show(String.Format(inv.StackTrace + inv.Message));
            }
        }
    }
}
