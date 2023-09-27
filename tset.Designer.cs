namespace Xtreme
{
    partial class tset
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabPageAdv1 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.statusBarAdv1 = new Syncfusion.Windows.Forms.Tools.StatusBarAdv();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarAdv1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(337, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(200, 100);
            this.tabControlAdv1.Controls.Add(this.tabPageAdv1);
            this.tabControlAdv1.Location = new System.Drawing.Point(276, 201);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.Size = new System.Drawing.Size(200, 100);
            this.tabControlAdv1.TabIndex = 1;
            // 
            // tabPageAdv1
            // 
            this.tabPageAdv1.Image = null;
            this.tabPageAdv1.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPageAdv1.Location = new System.Drawing.Point(1, 25);
            this.tabPageAdv1.Name = "tabPageAdv1";
            this.tabPageAdv1.ShowCloseButton = true;
            this.tabPageAdv1.Size = new System.Drawing.Size(197, 73);
            this.tabPageAdv1.TabIndex = 1;
            this.tabPageAdv1.Text = "tabPageAdv1";
            this.tabPageAdv1.ThemesEnabled = false;
            // 
            // statusBarAdv1
            // 
            this.statusBarAdv1.BeforeTouchSize = new System.Drawing.Size(800, 26);
            this.statusBarAdv1.CustomLayoutBounds = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.statusBarAdv1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBarAdv1.Location = new System.Drawing.Point(0, 424);
            this.statusBarAdv1.Name = "statusBarAdv1";
            this.statusBarAdv1.Padding = new System.Windows.Forms.Padding(3);
            this.statusBarAdv1.Size = new System.Drawing.Size(800, 26);
            this.statusBarAdv1.Spacing = new System.Drawing.Size(2, 2);
            this.statusBarAdv1.TabIndex = 2;
            // 
            // tset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusBarAdv1);
            this.Controls.Add(this.tabControlAdv1);
            this.Controls.Add(this.panel1);
            this.Name = "tset";
            this.Text = "tset";
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarAdv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv1;
        private Syncfusion.Windows.Forms.Tools.StatusBarAdv statusBarAdv1;
    }
}