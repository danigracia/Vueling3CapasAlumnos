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
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentForm studentform = new StudentForm();
            studentform.ShowDialog();
        }

        private void buttonReadTxt_Click(object sender, EventArgs e)
        {
            this.FillDataGridTxt();
        }

        private void buttonReadJson_Click(object sender, EventArgs e)
        {
            this.FillDataGridJson();
        }

        private void buttonReadXml_Click(object sender, EventArgs e)
        {
            this.FillDataGridXml();
        }

        #region Fill DataGrids
        private void FillDataGridTxt()
        {
            liststudent = fileutils.ReadAllTxt();
            this.dGVStudents.DataSource = liststudent;
            this.dGVStudents.Columns["SavedFormat"].Visible = false;
        }

        private void FillDataGridJson()
        {
            this.dGVStudents.DataSource = sinjson.LoadAll();
            this.dGVStudents.Columns["SavedFormat"].Visible = false;
        }

        private void FillDataGridXml()
        {
            this.dGVStudents.DataSource = sinxml.LoadAll();
            this.dGVStudents.Columns["SavedFormat"].Visible = false;
        }
        #endregion

    }
}
