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


namespace Vueling.Presentation.WinSite
{

    public partial class StudentForm : Form
    {
        private Student student;
        private IStudentBL studentBL;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static ITargetAdapterForLogger logger;
        public StudentForm()
        {
            InitializeComponent();
            student = new Student();
            studentBL = new StudentBL();
            logger = new Logger();
        }

        private void buttonTxt_Click(object sender, EventArgs e)
        {
            this.SaveStudentData(sender);

            try
            {
                studentBL.BusinessLogic(student);
            }
            catch (IOException)
            {
                MessageBox.Show("Fallo al tratar el archivo");
            }

            MessageBox.Show(String.Format("You have saved an student in {0} format", ((Button)sender).Text));

        }

        private void buttonJson_Click(object sender, EventArgs e)
        {
            this.SaveStudentData(sender);

            try
            {
                studentBL.BusinessLogic(student);
            }
            catch (IOException)
            {
                MessageBox.Show("Fallo al tratar el archivo");
            }


            MessageBox.Show(String.Format("You have saved an student in {0} format", ((Button)sender).Text));
        }

        private void buttonXml_Click(object sender, EventArgs e)
        {
            this.SaveStudentData(sender);

            try
            {
                studentBL.BusinessLogic(student);
            }
            catch (IOException)
            {
                MessageBox.Show("Fallo al tratar el archivo");
            }

            MessageBox.Show(String.Format("You have saved an student in {0} format", ((Button)sender).Text));
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
                MessageBox.Show(String.Format("Message error: " + e.Message));
            }
            catch (TargetException e)
            {
                MessageBox.Show(String.Format("Message error: " + e.Message));
            }
            catch (OverflowException e)
            {
                MessageBox.Show(String.Format("Message error: " + e.Message));
            }
        }

        private void buttonToList_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                StudentListForm studentlist = new StudentListForm();
                studentlist.ShowDialog();

            }
            catch (InvalidOperationException inv)
            {
                MessageBox.Show(String.Format("Message error: " + inv.Message));
            }
        }
    }
}
