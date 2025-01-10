using System.Windows.Forms;

namespace CSiC_Example_SAFE_Net
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
            BtnOpen = new Button();
            BtnAttach = new Button();
            BtnClose = new Button();
            Button1 = new Button();
            BtnOpenpath = new Button();
            SuspendLayout();
            // 
            // BtnOpen
            // 
            BtnOpen.Location = new Point(14, 14);
            BtnOpen.Margin = new Padding(4, 3, 4, 3);
            BtnOpen.Name = "BtnOpen";
            BtnOpen.Size = new Size(88, 27);
            BtnOpen.TabIndex = 0;
            BtnOpen.Text = "Open";
            BtnOpen.UseVisualStyleBackColor = true;
            BtnOpen.Click += BtnOpen_Click;
            // 
            // BtnAttach
            // 
            BtnAttach.Location = new Point(14, 47);
            BtnAttach.Margin = new Padding(4, 3, 4, 3);
            BtnAttach.Name = "BtnAttach";
            BtnAttach.Size = new Size(88, 27);
            BtnAttach.TabIndex = 1;
            BtnAttach.Text = "Attach";
            BtnAttach.UseVisualStyleBackColor = true;
            BtnAttach.Click += BtnAttach_Click;
            // 
            // BtnClose
            // 
            BtnClose.Location = new Point(14, 81);
            BtnClose.Margin = new Padding(4, 3, 4, 3);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(88, 27);
            BtnClose.TabIndex = 2;
            BtnClose.Text = "Close";
            BtnClose.UseVisualStyleBackColor = true;
            BtnClose.Click += BtnClose_Click;
            // 
            // Button1
            // 
            Button1.Location = new Point(119, 47);
            Button1.Margin = new Padding(4, 3, 4, 3);
            Button1.Name = "Button1";
            Button1.Size = new Size(88, 27);
            Button1.TabIndex = 3;
            Button1.Text = "Button1";
            Button1.UseVisualStyleBackColor = true;
            Button1.Click += Button1_Click;
            // 
            // BtnOpenpath
            // 
            BtnOpenpath.Location = new Point(119, 14);
            BtnOpenpath.Margin = new Padding(4, 3, 4, 3);
            BtnOpenpath.Name = "BtnOpenpath";
            BtnOpenpath.Size = new Size(88, 27);
            BtnOpenpath.TabIndex = 5;
            BtnOpenpath.Text = "Open Path";
            BtnOpenpath.UseVisualStyleBackColor = true;
            BtnOpenpath.Click += BtnOpenpath_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(226, 114);
            Controls.Add(BtnOpenpath);
            Controls.Add(Button1);
            Controls.Add(BtnClose);
            Controls.Add(BtnAttach);
            Controls.Add(BtnOpen);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            ShowIcon = false;
            Text = "CSiAmerica C# Example";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnAttach;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Button BtnOpenpath;
    }
}