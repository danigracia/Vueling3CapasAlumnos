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
using Vueling.Business.Logic.Interfaces;
using Vueling.Business.Logic.Logics;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;

namespace Vueling.Presentation.WinSite
{
    public partial class StudentListForm : Form
    {
        List<Student> liststudent = new List<Student>();
        IFileBL filebl;
    
        private Config formatconfig;

        public StudentListForm()
        {
            InitializeComponent();
        }

        private void StudentListForm_Load(object sender, EventArgs e)
        {
            formatconfig = Config.txt;
            filebl = new FileBL();

            this.FillDataGrid(formatconfig);
            filebl.FillSingletons();
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
            formatconfig = Config.txt;
            this.FillDataGrid(formatconfig);
        }

        private void buttonReadJson_Click(object sender, EventArgs e)
        {
            formatconfig = Config.json;
            this.FillDataGrid(formatconfig);
        }

        private void buttonReadXml_Click(object sender, EventArgs e)
        {
            formatconfig = Config.xml;
            this.FillDataGrid(formatconfig);
        }
        #endregion

        private void FillDataGrid(Config format)
        {
            liststudent = filebl.ReadFile(format);
            this.dGVStudents.DataSource = liststudent;
            this.dGVStudents.Columns["SavedFormat"].Visible = false;
        }

        private void buttonBusquedaGeneral_Click(object sender, EventArgs e)
        {
            IFileBL filebl = new FileBL();

            filebl.Buscar();

        }
    }
}
