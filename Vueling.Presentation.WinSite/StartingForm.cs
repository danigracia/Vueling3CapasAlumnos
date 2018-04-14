using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vueling.Presentation.WinSite
{
    public partial class StartingForm : Form
    {
        Form childform;

        public StartingForm()
        {
            InitializeComponent();
        }

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
    }
}
