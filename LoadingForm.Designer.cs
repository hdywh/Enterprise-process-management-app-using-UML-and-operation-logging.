namespace Diplom
{
    partial class LoadingForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingForm));
            SiticoneNetFrameworkUI.SiticoneRadialProgressBar.ProgressColorRange progressColorRange4 = new SiticoneNetFrameworkUI.SiticoneRadialProgressBar.ProgressColorRange();
            SiticoneNetFrameworkUI.SiticoneRadialProgressBar.ProgressColorRange progressColorRange5 = new SiticoneNetFrameworkUI.SiticoneRadialProgressBar.ProgressColorRange();
            SiticoneNetFrameworkUI.SiticoneRadialProgressBar.ProgressColorRange progressColorRange6 = new SiticoneNetFrameworkUI.SiticoneRadialProgressBar.ProgressColorRange();
            this.siticoneRadialProgressBar1 = new SiticoneNetFrameworkUI.SiticoneRadialProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.siticoneShimmerLabel1 = new SiticoneNetFrameworkUI.SiticoneShimmerLabel();
            this.SuspendLayout();
            // 
            // siticoneRadialProgressBar1
            // 
            this.siticoneRadialProgressBar1.AccessibleDescription = "Displays progress in a circular form.";
            this.siticoneRadialProgressBar1.AccessibleName = "Radial Progress Bar";
            this.siticoneRadialProgressBar1.AnimationSpeed = 4;
            this.siticoneRadialProgressBar1.AnimationStepValue = 1D;
            this.siticoneRadialProgressBar1.CanBeep = false;
            this.siticoneRadialProgressBar1.CanShake = false;
            this.siticoneRadialProgressBar1.Clockwise = true;
            this.siticoneRadialProgressBar1.ColorAnimationCycle = ((System.Collections.Generic.List<System.Drawing.Color>)(resources.GetObject("siticoneRadialProgressBar1.ColorAnimationCycle")));
            this.siticoneRadialProgressBar1.CurrentColorTheme = SiticoneNetFrameworkUI.SiticoneRadialProgressBar.ColorTheme.Ocean;
            this.siticoneRadialProgressBar1.Easing = SiticoneNetFrameworkUI.SiticoneRadialProgressBar.EasingFunction.Linear;
            this.siticoneRadialProgressBar1.EnableBackgroundShading = false;
            this.siticoneRadialProgressBar1.EnableBounce = false;
            this.siticoneRadialProgressBar1.EnableContinuousRotation = false;
            this.siticoneRadialProgressBar1.EnableKeyboardSupport = false;
            this.siticoneRadialProgressBar1.EnablePulsate = false;
            this.siticoneRadialProgressBar1.EnableRangeBasedColoring = false;
            this.siticoneRadialProgressBar1.EnableTextShadow = true;
            this.siticoneRadialProgressBar1.FillProgressArea = false;
            this.siticoneRadialProgressBar1.ForeColor = System.Drawing.Color.Black;
            this.siticoneRadialProgressBar1.Indeterminate = false;
            this.siticoneRadialProgressBar1.IsReadonly = false;
            this.siticoneRadialProgressBar1.Location = new System.Drawing.Point(162, 96);
            this.siticoneRadialProgressBar1.Maximum = 100D;
            this.siticoneRadialProgressBar1.Minimum = 0D;
            this.siticoneRadialProgressBar1.MinimumSize = new System.Drawing.Size(40, 40);
            this.siticoneRadialProgressBar1.MouseDragOrClickResponsive = false;
            this.siticoneRadialProgressBar1.MouseWheelResponsive = false;
            this.siticoneRadialProgressBar1.MouseWheelStepValue = 1D;
            this.siticoneRadialProgressBar1.Name = "siticoneRadialProgressBar1";
            this.siticoneRadialProgressBar1.ProgressBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            progressColorRange4.Color = System.Drawing.Color.Green;
            progressColorRange4.Maximum = 33D;
            progressColorRange4.Minimum = 0D;
            progressColorRange5.Color = System.Drawing.Color.Yellow;
            progressColorRange5.Maximum = 66D;
            progressColorRange5.Minimum = 34D;
            progressColorRange6.Color = System.Drawing.Color.Red;
            progressColorRange6.Maximum = 100D;
            progressColorRange6.Minimum = 67D;
            this.siticoneRadialProgressBar1.ProgressColorRanges.Add(progressColorRange4);
            this.siticoneRadialProgressBar1.ProgressColorRanges.Add(progressColorRange5);
            this.siticoneRadialProgressBar1.ProgressColorRanges.Add(progressColorRange6);
            this.siticoneRadialProgressBar1.ProgressFont = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.siticoneRadialProgressBar1.ProgressThickness = 16F;
            this.siticoneRadialProgressBar1.ReadonlyEndColor = System.Drawing.Color.DarkGray;
            this.siticoneRadialProgressBar1.ReadonlyStartColor = System.Drawing.Color.Gray;
            this.siticoneRadialProgressBar1.ReverseGradient = false;
            this.siticoneRadialProgressBar1.ShadowBlur = 5;
            this.siticoneRadialProgressBar1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(102)))));
            this.siticoneRadialProgressBar1.ShadowOffset = new System.Drawing.Point(2, 2);
            this.siticoneRadialProgressBar1.ShowRadialBorder = true;
            this.siticoneRadialProgressBar1.Size = new System.Drawing.Size(233, 233);
            this.siticoneRadialProgressBar1.StartAngle = -90;
            this.siticoneRadialProgressBar1.TabIndex = 0;
            this.siticoneRadialProgressBar1.Text = "siticoneRadialProgressBar1";
            this.siticoneRadialProgressBar1.TextFormat = "{0}%";
            this.siticoneRadialProgressBar1.Value = 78D;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // siticoneShimmerLabel1
            // 
            this.siticoneShimmerLabel1.AutoReverse = false;
            this.siticoneShimmerLabel1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(66)))), ((int)(((byte)(132)))));
            this.siticoneShimmerLabel1.Direction = SiticoneNetFrameworkUI.ShimmerDirection.LeftToRight;
            this.siticoneShimmerLabel1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.siticoneShimmerLabel1.IsAnimating = true;
            this.siticoneShimmerLabel1.IsPaused = false;
            this.siticoneShimmerLabel1.Location = new System.Drawing.Point(144, 335);
            this.siticoneShimmerLabel1.Name = "siticoneShimmerLabel1";
            this.siticoneShimmerLabel1.PauseDuration = 300;
            this.siticoneShimmerLabel1.ShimmerColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.siticoneShimmerLabel1.ShimmerOpacity = 1F;
            this.siticoneShimmerLabel1.ShimmerSpeed = 40;
            this.siticoneShimmerLabel1.ShimmerWidth = 0.2F;
            this.siticoneShimmerLabel1.Size = new System.Drawing.Size(275, 49);
            this.siticoneShimmerLabel1.TabIndex = 17;
            this.siticoneShimmerLabel1.Text = "Загрузка...";
            this.siticoneShimmerLabel1.ToolTipText = "";
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 489);
            this.Controls.Add(this.siticoneShimmerLabel1);
            this.Controls.Add(this.siticoneRadialProgressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadingForm";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.LoadingForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SiticoneNetFrameworkUI.SiticoneRadialProgressBar siticoneRadialProgressBar1;
        private System.Windows.Forms.Timer timer1;
        private SiticoneNetFrameworkUI.SiticoneShimmerLabel siticoneShimmerLabel1;
    }
}