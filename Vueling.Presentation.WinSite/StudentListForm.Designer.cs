namespace Vueling.Presentation.WinSite
{
    partial class StudentListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dGVStudents = new System.Windows.Forms.DataGridView();
            this.buttonReadTxt = new System.Windows.Forms.Button();
            this.buttonReadJson = new System.Windows.Forms.Button();
            this.buttonReadXml = new System.Windows.Forms.Button();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.labelBuscartext = new System.Windows.Forms.Label();
            this.buttonBusquedaGeneral = new System.Windows.Forms.Button();
            this.textBoxBusquedaGeneral = new System.Windows.Forms.TextBox();
            this.radioButtonId = new System.Windows.Forms.RadioButton();
            this.radioButtonNombre = new System.Windows.Forms.RadioButton();
            this.radioButtonApellido = new System.Windows.Forms.RadioButton();
            this.radioButtonEdad = new System.Windows.Forms.RadioButton();
            this.radioButtonDni = new System.Windows.Forms.RadioButton();
            this.radioButtonGuid = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dGVStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVStudents
            // 
            this.dGVStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVStudents.Location = new System.Drawing.Point(12, 175);
            this.dGVStudents.Name = "dGVStudents";
            this.dGVStudents.Size = new System.Drawing.Size(605, 200);
            this.dGVStudents.TabIndex = 0;
            // 
            // buttonReadTxt
            // 
            this.buttonReadTxt.Location = new System.Drawing.Point(13, 13);
            this.buttonReadTxt.Name = "buttonReadTxt";
            this.buttonReadTxt.Size = new System.Drawing.Size(73, 45);
            this.buttonReadTxt.TabIndex = 1;
            this.buttonReadTxt.Text = "Read From Txt File";
            this.buttonReadTxt.UseVisualStyleBackColor = true;
            this.buttonReadTxt.Click += new System.EventHandler(this.buttonReadTxt_Click);
            // 
            // buttonReadJson
            // 
            this.buttonReadJson.Location = new System.Drawing.Point(92, 13);
            this.buttonReadJson.Name = "buttonReadJson";
            this.buttonReadJson.Size = new System.Drawing.Size(73, 45);
            this.buttonReadJson.TabIndex = 2;
            this.buttonReadJson.Text = "Read From Json File";
            this.buttonReadJson.UseVisualStyleBackColor = true;
            this.buttonReadJson.Click += new System.EventHandler(this.buttonReadJson_Click);
            // 
            // buttonReadXml
            // 
            this.buttonReadXml.Location = new System.Drawing.Point(171, 13);
            this.buttonReadXml.Name = "buttonReadXml";
            this.buttonReadXml.Size = new System.Drawing.Size(73, 45);
            this.buttonReadXml.TabIndex = 3;
            this.buttonReadXml.Text = "Read From Xml File";
            this.buttonReadXml.UseVisualStyleBackColor = true;
            this.buttonReadXml.Click += new System.EventHandler(this.buttonReadXml_Click);
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(623, 346);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(83, 29);
            this.buttonVolver.TabIndex = 16;
            this.buttonVolver.Text = "Back";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // labelBuscartext
            // 
            this.labelBuscartext.AutoSize = true;
            this.labelBuscartext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuscartext.Location = new System.Drawing.Point(12, 70);
            this.labelBuscartext.Name = "labelBuscartext";
            this.labelBuscartext.Size = new System.Drawing.Size(72, 13);
            this.labelBuscartext.TabIndex = 23;
            this.labelBuscartext.Text = "Buscar por:";
            // 
            // buttonBusquedaGeneral
            // 
            this.buttonBusquedaGeneral.Location = new System.Drawing.Point(293, 135);
            this.buttonBusquedaGeneral.Name = "buttonBusquedaGeneral";
            this.buttonBusquedaGeneral.Size = new System.Drawing.Size(100, 23);
            this.buttonBusquedaGeneral.TabIndex = 25;
            this.buttonBusquedaGeneral.Text = "Search";
            this.buttonBusquedaGeneral.UseVisualStyleBackColor = true;
            this.buttonBusquedaGeneral.Click += new System.EventHandler(this.buttonBusquedaGeneral_Click);
            // 
            // textBoxBusquedaGeneral
            // 
            this.textBoxBusquedaGeneral.Location = new System.Drawing.Point(213, 109);
            this.textBoxBusquedaGeneral.Name = "textBoxBusquedaGeneral";
            this.textBoxBusquedaGeneral.Size = new System.Drawing.Size(180, 20);
            this.textBoxBusquedaGeneral.TabIndex = 26;
            // 
            // radioButtonId
            // 
            this.radioButtonId.AutoSize = true;
            this.radioButtonId.Location = new System.Drawing.Point(15, 95);
            this.radioButtonId.Name = "radioButtonId";
            this.radioButtonId.Size = new System.Drawing.Size(34, 17);
            this.radioButtonId.TabIndex = 0;
            this.radioButtonId.TabStop = true;
            this.radioButtonId.Tag = "IdAlumno";
            this.radioButtonId.Text = "Id";
            this.radioButtonId.UseVisualStyleBackColor = true;
            // 
            // radioButtonNombre
            // 
            this.radioButtonNombre.AutoSize = true;
            this.radioButtonNombre.Location = new System.Drawing.Point(15, 118);
            this.radioButtonNombre.Name = "radioButtonNombre";
            this.radioButtonNombre.Size = new System.Drawing.Size(62, 17);
            this.radioButtonNombre.TabIndex = 1;
            this.radioButtonNombre.TabStop = true;
            this.radioButtonNombre.Tag = "Nombre";
            this.radioButtonNombre.Text = "Nombre";
            this.radioButtonNombre.UseVisualStyleBackColor = true;
            // 
            // radioButtonApellido
            // 
            this.radioButtonApellido.AutoSize = true;
            this.radioButtonApellido.Location = new System.Drawing.Point(15, 141);
            this.radioButtonApellido.Name = "radioButtonApellido";
            this.radioButtonApellido.Size = new System.Drawing.Size(62, 17);
            this.radioButtonApellido.TabIndex = 2;
            this.radioButtonApellido.TabStop = true;
            this.radioButtonApellido.Tag = "Apellido";
            this.radioButtonApellido.Text = "Apellido";
            this.radioButtonApellido.UseVisualStyleBackColor = true;
            // 
            // radioButtonEdad
            // 
            this.radioButtonEdad.AutoSize = true;
            this.radioButtonEdad.Location = new System.Drawing.Point(100, 118);
            this.radioButtonEdad.Name = "radioButtonEdad";
            this.radioButtonEdad.Size = new System.Drawing.Size(50, 17);
            this.radioButtonEdad.TabIndex = 3;
            this.radioButtonEdad.TabStop = true;
            this.radioButtonEdad.Tag = "Edad";
            this.radioButtonEdad.Text = "Edad";
            this.radioButtonEdad.UseVisualStyleBackColor = true;
            // 
            // radioButtonDni
            // 
            this.radioButtonDni.AutoSize = true;
            this.radioButtonDni.Location = new System.Drawing.Point(100, 95);
            this.radioButtonDni.Name = "radioButtonDni";
            this.radioButtonDni.Size = new System.Drawing.Size(41, 17);
            this.radioButtonDni.TabIndex = 4;
            this.radioButtonDni.TabStop = true;
            this.radioButtonDni.Tag = "Dni";
            this.radioButtonDni.Text = "Dni";
            this.radioButtonDni.UseVisualStyleBackColor = true;
            // 
            // radioButtonGuid
            // 
            this.radioButtonGuid.AutoSize = true;
            this.radioButtonGuid.Location = new System.Drawing.Point(100, 141);
            this.radioButtonGuid.Name = "radioButtonGuid";
            this.radioButtonGuid.Size = new System.Drawing.Size(47, 17);
            this.radioButtonGuid.TabIndex = 5;
            this.radioButtonGuid.TabStop = true;
            this.radioButtonGuid.Tag = "Student_Guid";
            this.radioButtonGuid.Text = "Guid";
            this.radioButtonGuid.UseVisualStyleBackColor = true;
            // 
            // StudentListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 387);
            this.Controls.Add(this.radioButtonApellido);
            this.Controls.Add(this.radioButtonEdad);
            this.Controls.Add(this.radioButtonNombre);
            this.Controls.Add(this.radioButtonDni);
            this.Controls.Add(this.radioButtonId);
            this.Controls.Add(this.radioButtonGuid);
            this.Controls.Add(this.textBoxBusquedaGeneral);
            this.Controls.Add(this.buttonBusquedaGeneral);
            this.Controls.Add(this.labelBuscartext);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.buttonReadXml);
            this.Controls.Add(this.buttonReadJson);
            this.Controls.Add(this.buttonReadTxt);
            this.Controls.Add(this.dGVStudents);
            this.Name = "StudentListForm";
            this.Text = "ListaStudent";
            this.Load += new System.EventHandler(this.StudentListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVStudents;
        private System.Windows.Forms.Button buttonReadTxt;
        private System.Windows.Forms.Button buttonReadJson;
        private System.Windows.Forms.Button buttonReadXml;
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.Label labelBuscartext;
        private System.Windows.Forms.Button buttonBusquedaGeneral;
        private System.Windows.Forms.TextBox textBoxBusquedaGeneral;
        private System.Windows.Forms.RadioButton radioButtonGuid;
        private System.Windows.Forms.RadioButton radioButtonDni;
        private System.Windows.Forms.RadioButton radioButtonEdad;
        private System.Windows.Forms.RadioButton radioButtonApellido;
        private System.Windows.Forms.RadioButton radioButtonNombre;
        private System.Windows.Forms.RadioButton radioButtonId;
    }
}