﻿using System;
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
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;

namespace Vueling.Presentation.WinSite
{
    public partial class StartingForm : Form
    {
        Form childform;

        public StartingForm()
        {
            InitializeComponent();
        }

        #region Start Menus
        private void registrarNouAlumneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            childform = new StudentForm();
            CreateMdiForms(childform);
        }

        private void llistaDAlumnesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            childform = new StudentListForm();
            CreateMdiForms(childform);
        }

        private void CreateMdiForms(Form form)
        {
            foreach (Form fm in this.MdiChildren)
            {
                fm.Close();
            }
            form.MdiParent = this;
            form.Show();
        }
        #endregion

        #region Language Menus
        private void catalàToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("Student_Languaje", "ca-ES", EnvironmentVariableTarget.User);
            LanguageUtils.SetLanguaje();

            this.Update();
        }

        private void anglèsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("Student_Languaje", "en-001", EnvironmentVariableTarget.User);
            LanguageUtils.SetLanguaje();

            this.Update();
        }

        private void castellàToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("Student_Languaje", "es-ES", EnvironmentVariableTarget.User);
            LanguageUtils.SetLanguaje();

            this.Update();
        }
        #endregion

        #region SetFormats Menus
        private void txtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileUtils.SetFormat(Config.txt);
            this.ChangeFormatLabelStudentForm();
        }

        private void jsonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileUtils.SetFormat(Config.json);
            this.ChangeFormatLabelStudentForm();
        }

        private void xmlToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileUtils.SetFormat(Config.xml);
            this.ChangeFormatLabelStudentForm();
        }
        #endregion

        private void ChangeFormatLabelStudentForm()
        {
            //Millor amb events personalitzats pero no se fer-ho :P
            if (childform != null && childform.GetType() == typeof(StudentForm)) ((StudentForm)childform).ChangeFormatLabel();
        }
    }
}
