using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.Singletons;

namespace Vueling.Presentation.WinSite
{
    public partial class StudentListForm : Form
    {
        List<Student> liststudent;
        FileUtils fileutils;
        SingletonJson sinjson;
        SingletonXml sinxml;
        private Config formatconfig;
        public StudentListForm()
        {
            InitializeComponent();
        }

        private void StudentListForm_Load(object sender, EventArgs e)
        {
            // Cargar datos de fichero de texto en grid
            #region DataGrid's
            this.FillDataGridTxt();
            #endregion

            formatconfig = Config.txt;
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentForm studentform = new StudentForm();
            studentform.ShowDialog();
        }

        #region Buttons Format
        private void buttonReadTxt_Click(object sender, EventArgs e)
        {
            this.FillDataGridTxt();
            formatconfig = Config.txt;
        }

        private void buttonReadJson_Click(object sender, EventArgs e)
        {
            this.FillDataGridJson();
            formatconfig = Config.json;
        }

        private void buttonReadXml_Click(object sender, EventArgs e)
        {
            this.FillDataGridXml();
            formatconfig = Config.xml;
        }
        #endregion

        #region Fill DataGrids
        private void FillDataGridTxt()
        {
            liststudent = fileutils.ReadAllTxt();
            this.dGVStudents.DataSource = liststudent;
            this.dGVStudents.Columns["SavedFormat"].Visible = false;
        }

        private void FillDataGridJson()
        {
            liststudent = sinjson.LoadAll();
            this.dGVStudents.DataSource = liststudent;
            this.dGVStudents.Columns["SavedFormat"].Visible = false;
        }

        private void FillDataGridXml()
        {
            liststudent = sinxml.LoadAll();
            this.dGVStudents.DataSource = liststudent;
            this.dGVStudents.Columns["SavedFormat"].Visible = false;
        }
        #endregion

        private void buttonBusquedaGeneral_Click(object sender, EventArgs e)
        {
            IEnumerable<Student> query = from st in liststudent
                                         where st.Nombre == this.textBoxNombre.Text
                                        orderby st
                                        select st;

            foreach (Student item in query)
                Console.WriteLine(item);
        }
    }
}
