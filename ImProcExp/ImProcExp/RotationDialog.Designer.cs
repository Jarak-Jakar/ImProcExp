namespace ImProcExp
{
    partial class RotationDialog
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
            this.ClockwisePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ClockwiseDegreesText = new System.Windows.Forms.TextBox();
            this.ClockwiseLabel = new System.Windows.Forms.Label();
            this.ClockwiseAccept = new System.Windows.Forms.Button();
            this.ClockwiseCancel = new System.Windows.Forms.Button();
            this.ClockwisePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClockwisePanel
            // 
            this.ClockwisePanel.Controls.Add(this.ClockwiseDegreesText);
            this.ClockwisePanel.Controls.Add(this.ClockwiseLabel);
            this.ClockwisePanel.Controls.Add(this.ClockwiseAccept);
            this.ClockwisePanel.Controls.Add(this.ClockwiseCancel);
            this.ClockwisePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClockwisePanel.Location = new System.Drawing.Point(0, 0);
            this.ClockwisePanel.Name = "ClockwisePanel";
            this.ClockwisePanel.Size = new System.Drawing.Size(274, 99);
            this.ClockwisePanel.TabIndex = 0;
            this.ClockwisePanel.Visible = false;
            // 
            // ClockwiseDegreesText
            // 
            this.ClockwiseDegreesText.Dock = System.Windows.Forms.DockStyle.Top;
            this.ClockwiseDegreesText.Location = new System.Drawing.Point(3, 3);
            this.ClockwiseDegreesText.Name = "ClockwiseDegreesText";
            this.ClockwiseDegreesText.Size = new System.Drawing.Size(259, 20);
            this.ClockwiseDegreesText.TabIndex = 0;
            // 
            // ClockwiseLabel
            // 
            this.ClockwiseLabel.AutoSize = true;
            this.ClockwiseLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClockwiseLabel.Location = new System.Drawing.Point(3, 26);
            this.ClockwiseLabel.Name = "ClockwiseLabel";
            this.ClockwiseLabel.Size = new System.Drawing.Size(266, 39);
            this.ClockwiseLabel.TabIndex = 1;
            this.ClockwiseLabel.Text = "Enter integer degrees for the image to be rotated clockwise (remember that rotati" +
    "ons that aren\'t multiples of 90 degrees will cause information loss)";
            // 
            // ClockwiseAccept
            // 
            this.ClockwiseAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ClockwiseAccept.Location = new System.Drawing.Point(3, 68);
            this.ClockwiseAccept.Name = "ClockwiseAccept";
            this.ClockwiseAccept.Size = new System.Drawing.Size(75, 23);
            this.ClockwiseAccept.TabIndex = 2;
            this.ClockwiseAccept.Text = "Accept";
            this.ClockwiseAccept.UseVisualStyleBackColor = true;
            this.ClockwiseAccept.Click += new System.EventHandler(this.ClockwiseAccept_Click);
            // 
            // ClockwiseCancel
            // 
            this.ClockwiseCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ClockwiseCancel.Location = new System.Drawing.Point(84, 68);
            this.ClockwiseCancel.Name = "ClockwiseCancel";
            this.ClockwiseCancel.Size = new System.Drawing.Size(75, 23);
            this.ClockwiseCancel.TabIndex = 3;
            this.ClockwiseCancel.Text = "Cancel";
            this.ClockwiseCancel.UseVisualStyleBackColor = true;
            this.ClockwiseCancel.Click += new System.EventHandler(this.ClockwiseCancel_Click);
            // 
            // RotationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 99);
            this.Controls.Add(this.ClockwisePanel);
            this.Name = "RotationDialog";
            this.Text = "RotationDialog";
            this.ClockwisePanel.ResumeLayout(false);
            this.ClockwisePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ClockwisePanel;
        private System.Windows.Forms.TextBox ClockwiseDegreesText;
        private System.Windows.Forms.Label ClockwiseLabel;
        private System.Windows.Forms.Button ClockwiseAccept;
        private System.Windows.Forms.Button ClockwiseCancel;
        public int angle;
    }
}