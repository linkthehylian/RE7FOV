
namespace RE7FOV
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fovBar = new System.Windows.Forms.TrackBar();
            this.fovLabel = new System.Windows.Forms.Label();
            this.fovValueLabel = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.refreshBtn = new System.Windows.Forms.PictureBox();
            this.dlc1Box = new System.Windows.Forms.CheckBox();
            this.dlc2Box = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.fovBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // fovBar
            // 
            this.fovBar.AutoSize = false;
            this.fovBar.Location = new System.Drawing.Point(12, 30);
            this.fovBar.Maximum = 22;
            this.fovBar.Name = "fovBar";
            this.fovBar.Size = new System.Drawing.Size(416, 30);
            this.fovBar.TabIndex = 0;
            this.fovBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.fovBar.Scroll += new System.EventHandler(this.fovBar_Scroll);
            // 
            // fovLabel
            // 
            this.fovLabel.AutoSize = true;
            this.fovLabel.Location = new System.Drawing.Point(21, 10);
            this.fovLabel.Name = "fovLabel";
            this.fovLabel.Size = new System.Drawing.Size(31, 13);
            this.fovLabel.TabIndex = 1;
            this.fovLabel.Text = "FOV:";
            // 
            // fovValueLabel
            // 
            this.fovValueLabel.AutoSize = true;
            this.fovValueLabel.Location = new System.Drawing.Point(52, 10);
            this.fovValueLabel.Name = "fovValueLabel";
            this.fovValueLabel.Size = new System.Drawing.Size(13, 13);
            this.fovValueLabel.TabIndex = 2;
            this.fovValueLabel.Text = "0";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(382, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(40, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "GitHub";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "v2.2";
            // 
            // refreshBtn
            // 
            this.refreshBtn.Enabled = false;
            this.refreshBtn.Image = global::RE7FOV.Properties.Resources._242_2424608_file_refresh_refresh_icon_png;
            this.refreshBtn.Location = new System.Drawing.Point(345, 3);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(26, 24);
            this.refreshBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.refreshBtn.TabIndex = 6;
            this.refreshBtn.TabStop = false;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // dlc1Box
            // 
            this.dlc1Box.AutoSize = true;
            this.dlc1Box.Enabled = false;
            this.dlc1Box.Location = new System.Drawing.Point(131, 89);
            this.dlc1Box.Name = "dlc1Box";
            this.dlc1Box.Size = new System.Drawing.Size(79, 17);
            this.dlc1Box.TabIndex = 7;
            this.dlc1Box.Text = "Not A Hero";
            this.dlc1Box.UseVisualStyleBackColor = true;
            this.dlc1Box.CheckedChanged += new System.EventHandler(this.dlc1Box_CheckedChanged);
            // 
            // dlc2Box
            // 
            this.dlc2Box.AutoSize = true;
            this.dlc2Box.Enabled = false;
            this.dlc2Box.Location = new System.Drawing.Point(216, 89);
            this.dlc2Box.Name = "dlc2Box";
            this.dlc2Box.Size = new System.Drawing.Size(79, 17);
            this.dlc2Box.TabIndex = 8;
            this.dlc2Box.Text = "End of Zoe";
            this.dlc2Box.UseVisualStyleBackColor = true;
            this.dlc2Box.CheckedChanged += new System.EventHandler(this.dlc2Box_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(434, 111);
            this.Controls.Add(this.dlc2Box);
            this.Controls.Add(this.dlc1Box);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.fovValueLabel);
            this.Controls.Add(this.fovLabel);
            this.Controls.Add(this.fovBar);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "RE7FOV";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseHover += new System.EventHandler(this.Main_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.fovBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar fovBar;
        private System.Windows.Forms.Label fovLabel;
        private System.Windows.Forms.Label fovValueLabel;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox refreshBtn;
        private System.Windows.Forms.CheckBox dlc1Box;
        private System.Windows.Forms.CheckBox dlc2Box;
    }
}

