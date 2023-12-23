
namespace Project.V14
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.labelHelp_KDG = new System.Windows.Forms.Label();
            this.buttonOk_KDG = new System.Windows.Forms.Button();
            this.pictureBoxHelp_KDG = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHelp_KDG)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHelp_KDG
            // 
            this.labelHelp_KDG.AutoSize = true;
            this.labelHelp_KDG.Location = new System.Drawing.Point(331, 13);
            this.labelHelp_KDG.Name = "labelHelp_KDG";
            this.labelHelp_KDG.Size = new System.Drawing.Size(363, 187);
            this.labelHelp_KDG.TabIndex = 1;
            this.labelHelp_KDG.Text = resources.GetString("labelHelp_KDG.Text");
            // 
            // buttonOk_KDG
            // 
            this.buttonOk_KDG.Location = new System.Drawing.Point(669, 293);
            this.buttonOk_KDG.Name = "buttonOk_KDG";
            this.buttonOk_KDG.Size = new System.Drawing.Size(119, 39);
            this.buttonOk_KDG.TabIndex = 2;
            this.buttonOk_KDG.Text = "OK";
            this.buttonOk_KDG.UseVisualStyleBackColor = true;
            this.buttonOk_KDG.Click += new System.EventHandler(this.buttonOk_KDG_Click);
            // 
            // pictureBoxHelp_KDG
            // 
            this.pictureBoxHelp_KDG.Image = global::Project.V14.Properties.Resources.VfZH0Ksf2Is;
            this.pictureBoxHelp_KDG.Location = new System.Drawing.Point(13, 13);
            this.pictureBoxHelp_KDG.Name = "pictureBoxHelp_KDG";
            this.pictureBoxHelp_KDG.Size = new System.Drawing.Size(312, 319);
            this.pictureBoxHelp_KDG.TabIndex = 0;
            this.pictureBoxHelp_KDG.TabStop = false;
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 338);
            this.Controls.Add(this.buttonOk_KDG);
            this.Controls.Add(this.labelHelp_KDG);
            this.Controls.Add(this.pictureBoxHelp_KDG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.Text = "Справка";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHelp_KDG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxHelp_KDG;
        private System.Windows.Forms.Label labelHelp_KDG;
        private System.Windows.Forms.Button buttonOk_KDG;
    }
}