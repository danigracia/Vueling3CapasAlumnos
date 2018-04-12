using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Business.Logic.Interfaces;
using Vueling.Business.Logic.Logics;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;
using Vueling.Presentation.WinSite.Resources;

namespace Vueling.Presentation.WinSite
{
    public partial class StudentListForm : Form
    {
        List<Student> liststudent;
        IFileBL filebl;
        Config format;
        IFileBL filebusiness;

        public StudentListForm()
        {
            InitializeComponent();
            AplicarIdioma();
        }


        private void StudentListForm_Load(object sender, EventArgs e)
        {
            format = Config.txt;
            filebl = new FileBL();
            liststudent = new List<Student>();

            this.FillDataGrid(Config.txt);
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
            format = Config.txt;
            this.FillDataGrid(Config.txt);
        }

        private void buttonReadJson_Click(object sender, EventArgs e)
        {
            format = Config.json;
            this.FillDataGrid(Config.json);
        }

        private void buttonReadXml_Click(object sender, EventArgs e)
        {
            format = Config.xml;
            this.FillDataGrid(Config.xml);
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
            filebusiness = new FileBL();
            string selectedprop = "";
            foreach (Control con in this.Controls)
            {
                if(con is RadioButton)
                {
                    if (((RadioButton)con).Checked)
                    {
                        selectedprop = ((RadioButton)con).Tag.ToString();
                    }
                }
            }
            this.dGVStudents.DataSource = filebusiness.Buscar(format, this.textBoxBusquedaGeneral.Text, selectedprop);
            this.dGVStudents.Columns["SavedFormat"].Visible = false;
        }

        public void AplicarIdioma()
        {
            radioButtonId.Text = StringResources.labelId;
            radioButtonNombre.Text = StringResources.labelNombre;
            radioButtonApellido.Text = StringResources.labelApellido;
            radioButtonDni.Text = StringResources.labelDni;
            radioButtonEdad.Text = StringResources.labelAge;
            radioButtonGuid.Text = StringResources.labelGuid;
            buttonBusquedaGeneral.Text = StringResources.labelSearch;
            buttonReadTxt.Text = StringResources.labelReadtxt;
            buttonReadJson.Text = StringResources.labelReadjson;
            buttonReadXml.Text = StringResources.labelReadxml;
            this.Text = StringResources.FormName;
        }
    }
}
