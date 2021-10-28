
namespace WindowsFormsApp
{
    partial class teacherform
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.name,
            this.lastname});
            this.dataGridView1.Location = new System.Drawing.Point(12, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(343, 375);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            // 
            // name
            // 
            this.name.HeaderText = "name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // lastname
            // 
            this.lastname.HeaderText = "lastname";
            this.lastname.Name = "lastname";
            this.lastname.ReadOnly = true;
            // 
            // name1
            // 
            this.name1.AutoSize = true;
            this.name1.Location = new System.Drawing.Point(281, 13);
            this.name1.Name = "name1";
            this.name1.Size = new System.Drawing.Size(35, 13);
            this.name1.TabIndex = 1;
            this.name1.Text = "label1";
            // 
            // teacherform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.name1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "teacherform";
            this.Text = "teacher_form";
            this.Load += new System.EventHandler(this.teacher_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewLinkColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastname;
        private System.Windows.Forms.Label name1;
    }
}