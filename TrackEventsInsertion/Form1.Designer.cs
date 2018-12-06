namespace TrackEventsInsertion
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.stopinsertionBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Insert 200 lines in database";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(319, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(239, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "Insert continously";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // stopinsertionBt
            // 
            this.stopinsertionBt.BackColor = System.Drawing.Color.Salmon;
            this.stopinsertionBt.Location = new System.Drawing.Point(319, 90);
            this.stopinsertionBt.Name = "stopinsertionBt";
            this.stopinsertionBt.Size = new System.Drawing.Size(239, 36);
            this.stopinsertionBt.TabIndex = 3;
            this.stopinsertionBt.Text = "Stop insertion";
            this.stopinsertionBt.UseVisualStyleBackColor = false;
            this.stopinsertionBt.Click += new System.EventHandler(this.stopinsertionBt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 160);
            this.Controls.Add(this.stopinsertionBt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Simulator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button stopinsertionBt;
    }
}

