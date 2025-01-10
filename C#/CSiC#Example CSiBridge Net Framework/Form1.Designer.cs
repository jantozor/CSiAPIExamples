using System.Windows.Forms;

namespace CSiC_Example_CSiBridge_Net_Framework
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
            this.BtnOpen = new System.Windows.Forms.Button();
            this.BtnAttach = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.BtnOpenpath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(12, 12);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(75, 23);
            this.BtnOpen.TabIndex = 0;
            this.BtnOpen.Text = "Open";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnAttach
            // 
            this.BtnAttach.Location = new System.Drawing.Point(12, 41);
            this.BtnAttach.Name = "BtnAttach";
            this.BtnAttach.Size = new System.Drawing.Size(75, 23);
            this.BtnAttach.TabIndex = 1;
            this.BtnAttach.Text = "Attach";
            this.BtnAttach.UseVisualStyleBackColor = true;
            this.BtnAttach.Click += new System.EventHandler(this.BtnAttach_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(12, 70);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(102, 41);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 3;
            this.Button1.Text = "Button1";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // BtnOpenpath
            // 
            this.BtnOpenpath.Location = new System.Drawing.Point(102, 12);
            this.BtnOpenpath.Name = "BtnOpenpath";
            this.BtnOpenpath.Size = new System.Drawing.Size(75, 23);
            this.BtnOpenpath.TabIndex = 5;
            this.BtnOpenpath.Text = "Open Path";
            this.BtnOpenpath.UseVisualStyleBackColor = true;
            this.BtnOpenpath.Click += new System.EventHandler(this.BtnOpenpath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 99);
            this.Controls.Add(this.BtnOpenpath);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnAttach);
            this.Controls.Add(this.BtnOpen);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "CSiAmerica C# Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnAttach;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Button BtnOpenpath;
    }
}