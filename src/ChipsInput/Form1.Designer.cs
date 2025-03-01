
namespace ChipsInput
{
    partial class Form1
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
            this.chipsInputControl1 = new CustomControls.ChipsInputControl();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chipsInputControl1
            // 
            this.chipsInputControl1.BackColor = System.Drawing.Color.White;
            this.chipsInputControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chipsInputControl1.Location = new System.Drawing.Point(113, 135);
            this.chipsInputControl1.MinimumSize = new System.Drawing.Size(200, 30);
            this.chipsInputControl1.Name = "chipsInputControl1";
            this.chipsInputControl1.Size = new System.Drawing.Size(508, 30);
            this.chipsInputControl1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 45);
            this.button1.TabIndex = 1;
            this.button1.Text = "Show entered chips";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chipsInputControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }


        #endregion

        private CustomControls.ChipsInputControl chipsInputControl1;
        private System.Windows.Forms.Button button1;
    }
}

