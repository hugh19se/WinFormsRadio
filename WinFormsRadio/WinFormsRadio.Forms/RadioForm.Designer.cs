namespace WinFormsRadio.Forms
{
    partial class RadioForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadioForm));
            VolumeSliderBar = new TrackBar();
            VolumeLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)VolumeSliderBar).BeginInit();
            SuspendLayout();
            // 
            // VolumeSliderBar
            // 
            VolumeSliderBar.Location = new Point(172, 30);
            VolumeSliderBar.Maximum = 100;
            VolumeSliderBar.Name = "VolumeSliderBar";
            VolumeSliderBar.Orientation = Orientation.Vertical;
            VolumeSliderBar.RightToLeft = RightToLeft.Yes;
            VolumeSliderBar.RightToLeftLayout = true;
            VolumeSliderBar.Size = new Size(45, 200);
            VolumeSliderBar.TabIndex = 0;
            VolumeSliderBar.ValueChanged += VolumeSliderBar_ValueChanged;
            // 
            // VolumeLabel
            // 
            VolumeLabel.AutoSize = true;
            VolumeLabel.Location = new Point(172, 12);
            VolumeLabel.Name = "VolumeLabel";
            VolumeLabel.Size = new Size(47, 15);
            VolumeLabel.TabIndex = 1;
            VolumeLabel.Text = "Volume";
            // 
            // RadioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 450);
            Controls.Add(VolumeLabel);
            Controls.Add(VolumeSliderBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RadioForm";
            Text = "Windows Forms Radio";
            Load += RadioForm_Load;
            ((System.ComponentModel.ISupportInitialize)VolumeSliderBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar VolumeSliderBar;
        private Label VolumeLabel;
    }
}
