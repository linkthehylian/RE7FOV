
namespace RE7FOV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.fovBar = new System.Windows.Forms.TrackBar();
            this.fovLabel = new System.Windows.Forms.Label();
            this.fovValueLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fovBar)).BeginInit();
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
            this.fovBar.TickStyle = System.Windows.Forms.TickStyle.None;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Developed by linkthehylian";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(434, 111);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fovValueLabel);
            this.Controls.Add(this.fovLabel);
            this.Controls.Add(this.fovBar);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "RE7FOV";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fovBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar fovBar;
        private System.Windows.Forms.Label fovLabel;
        private System.Windows.Forms.Label fovValueLabel;
        private System.Windows.Forms.Label label1;
    }
}

