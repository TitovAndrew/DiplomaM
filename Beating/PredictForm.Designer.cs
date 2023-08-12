
namespace Beating
{
    partial class PredictForm
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
            this.panelControls = new System.Windows.Forms.Panel();
            this.panelMeasurement = new System.Windows.Forms.Panel();
            this.textBoxW2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxW1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.radioButtonStateBeating = new System.Windows.Forms.RadioButton();
            this.radioButtonBorderLineStateBeating = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownStep = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFrequancy = new System.Windows.Forms.NumericUpDown();
            this.labelFrequancy = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCanvas1 = new System.Windows.Forms.Panel();
            this.panelCanvas2 = new System.Windows.Forms.Panel();
            this.panelControls.SuspendLayout();
            this.panelMeasurement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrequancy)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelControls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelControls.Controls.Add(this.panelMeasurement);
            this.panelControls.Controls.Add(this.buttonBack);
            this.panelControls.Controls.Add(this.buttonStart);
            this.panelControls.Controls.Add(this.radioButtonStateBeating);
            this.panelControls.Controls.Add(this.radioButtonBorderLineStateBeating);
            this.panelControls.Controls.Add(this.label2);
            this.panelControls.Controls.Add(this.numericUpDownStep);
            this.panelControls.Controls.Add(this.numericUpDownFrequancy);
            this.panelControls.Controls.Add(this.labelFrequancy);
            this.panelControls.Controls.Add(this.label1);
            this.panelControls.Location = new System.Drawing.Point(-1, -1);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(221, 441);
            this.panelControls.TabIndex = 1;
            // 
            // panelMeasurement
            // 
            this.panelMeasurement.Controls.Add(this.textBoxW2);
            this.panelMeasurement.Controls.Add(this.label3);
            this.panelMeasurement.Controls.Add(this.textBoxW1);
            this.panelMeasurement.Controls.Add(this.label9);
            this.panelMeasurement.Location = new System.Drawing.Point(3, 211);
            this.panelMeasurement.Name = "panelMeasurement";
            this.panelMeasurement.Size = new System.Drawing.Size(217, 89);
            this.panelMeasurement.TabIndex = 17;
            this.panelMeasurement.Visible = false;
            // 
            // textBoxW2
            // 
            this.textBoxW2.BackColor = System.Drawing.Color.White;
            this.textBoxW2.Location = new System.Drawing.Point(44, 46);
            this.textBoxW2.Name = "textBoxW2";
            this.textBoxW2.ReadOnly = true;
            this.textBoxW2.Size = new System.Drawing.Size(161, 23);
            this.textBoxW2.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "w2:";
            // 
            // textBoxW1
            // 
            this.textBoxW1.BackColor = System.Drawing.Color.White;
            this.textBoxW1.Location = new System.Drawing.Point(44, 17);
            this.textBoxW1.Name = "textBoxW1";
            this.textBoxW1.ReadOnly = true;
            this.textBoxW1.Size = new System.Drawing.Size(161, 23);
            this.textBoxW1.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(6, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "w1:";
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBack.Location = new System.Drawing.Point(12, 402);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(73, 25);
            this.buttonBack.TabIndex = 13;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(135, 180);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(73, 25);
            this.buttonStart.TabIndex = 12;
            this.buttonStart.Text = "Начать";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // radioButtonStateBeating
            // 
            this.radioButtonStateBeating.AutoSize = true;
            this.radioButtonStateBeating.Location = new System.Drawing.Point(12, 145);
            this.radioButtonStateBeating.Name = "radioButtonStateBeating";
            this.radioButtonStateBeating.Size = new System.Drawing.Size(194, 19);
            this.radioButtonStateBeating.TabIndex = 11;
            this.radioButtonStateBeating.Text = "Стабильное состояние биений";
            this.radioButtonStateBeating.UseVisualStyleBackColor = true;
            // 
            // radioButtonBorderLineStateBeating
            // 
            this.radioButtonBorderLineStateBeating.AutoSize = true;
            this.radioButtonBorderLineStateBeating.Checked = true;
            this.radioButtonBorderLineStateBeating.Location = new System.Drawing.Point(12, 120);
            this.radioButtonBorderLineStateBeating.Name = "radioButtonBorderLineStateBeating";
            this.radioButtonBorderLineStateBeating.Size = new System.Drawing.Size(204, 19);
            this.radioButtonBorderLineStateBeating.TabIndex = 10;
            this.radioButtonBorderLineStateBeating.TabStop = true;
            this.radioButtonBorderLineStateBeating.Text = "Пограничное состояния биений";
            this.radioButtonBorderLineStateBeating.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(8, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Шаг поиска:";
            // 
            // numericUpDownStep
            // 
            this.numericUpDownStep.DecimalPlaces = 3;
            this.numericUpDownStep.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownStep.Location = new System.Drawing.Point(114, 80);
            this.numericUpDownStep.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDownStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownStep.Name = "numericUpDownStep";
            this.numericUpDownStep.Size = new System.Drawing.Size(94, 23);
            this.numericUpDownStep.TabIndex = 8;
            this.numericUpDownStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // numericUpDownFrequancy
            // 
            this.numericUpDownFrequancy.DecimalPlaces = 2;
            this.numericUpDownFrequancy.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownFrequancy.Location = new System.Drawing.Point(114, 51);
            this.numericUpDownFrequancy.Name = "numericUpDownFrequancy";
            this.numericUpDownFrequancy.Size = new System.Drawing.Size(94, 23);
            this.numericUpDownFrequancy.TabIndex = 7;
            this.numericUpDownFrequancy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelFrequancy
            // 
            this.labelFrequancy.AutoSize = true;
            this.labelFrequancy.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.labelFrequancy.Location = new System.Drawing.Point(8, 53);
            this.labelFrequancy.Name = "labelFrequancy";
            this.labelFrequancy.Size = new System.Drawing.Size(100, 15);
            this.labelFrequancy.TabIndex = 6;
            this.labelFrequancy.Text = "Угловая частота:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ввод данных";
            // 
            // panelCanvas1
            // 
            this.panelCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCanvas1.BackColor = System.Drawing.Color.White;
            this.panelCanvas1.Location = new System.Drawing.Point(219, -1);
            this.panelCanvas1.Name = "panelCanvas1";
            this.panelCanvas1.Size = new System.Drawing.Size(632, 221);
            this.panelCanvas1.TabIndex = 2;
            this.panelCanvas1.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCanvas1_Paint);
            // 
            // panelCanvas2
            // 
            this.panelCanvas2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCanvas2.BackColor = System.Drawing.Color.White;
            this.panelCanvas2.Location = new System.Drawing.Point(219, 219);
            this.panelCanvas2.Name = "panelCanvas2";
            this.panelCanvas2.Size = new System.Drawing.Size(632, 221);
            this.panelCanvas2.TabIndex = 3;
            this.panelCanvas2.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCanvas2_Paint);
            // 
            // PredictForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 439);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.panelCanvas2);
            this.Controls.Add(this.panelCanvas1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "PredictForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Спрогнозировать биения для частоты";
            this.ResizeBegin += new System.EventHandler(this.PredictForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.PredictForm_ResizeEnd);
            this.Resize += new System.EventHandler(this.PredictForm_Resize);
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.panelMeasurement.ResumeLayout(false);
            this.panelMeasurement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrequancy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.NumericUpDown numericUpDownStep;
        private System.Windows.Forms.NumericUpDown numericUpDownFrequancy;
        private System.Windows.Forms.Label labelFrequancy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonStateBeating;
        private System.Windows.Forms.RadioButton radioButtonBorderLineStateBeating;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Panel panelCanvas1;
        private System.Windows.Forms.Panel panelCanvas2;
        private System.Windows.Forms.Panel panelMeasurement;
        private System.Windows.Forms.TextBox textBoxW2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxW1;
        private System.Windows.Forms.Label label9;
    }
}