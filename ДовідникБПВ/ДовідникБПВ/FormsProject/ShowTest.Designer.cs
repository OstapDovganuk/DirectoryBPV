namespace FormsProject
{
    partial class ShowTest
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
            this.Test = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Test
            // 
            this.Test.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Test.Location = new System.Drawing.Point(0, 0);
            this.Test.Name = "Test";
            this.Test.Size = new System.Drawing.Size(800, 450);
            this.Test.TabIndex = 0;
            this.Test.Text = "";
            // 
            // ShowTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Test);
            this.Name = "ShowTest";
            this.Text = "ShowTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Test;
    }
}