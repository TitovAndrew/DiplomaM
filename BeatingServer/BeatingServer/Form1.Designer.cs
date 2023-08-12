
namespace BeatingServer
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxStats = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonOpenStats = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxStats
            // 
            this.textBoxStats.BackColor = System.Drawing.SystemColors.Menu;
            this.textBoxStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxStats.Location = new System.Drawing.Point(12, 12);
            this.textBoxStats.Multiline = true;
            this.textBoxStats.Name = "textBoxStats";
            this.textBoxStats.ReadOnly = true;
            this.textBoxStats.Size = new System.Drawing.Size(478, 238);
            this.textBoxStats.TabIndex = 0;
            this.textBoxStats.TabStop = false;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 259);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.TabStop = false;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonOpenStats
            // 
            this.buttonOpenStats.Location = new System.Drawing.Point(331, 259);
            this.buttonOpenStats.Name = "buttonOpenStats";
            this.buttonOpenStats.Size = new System.Drawing.Size(159, 23);
            this.buttonOpenStats.TabIndex = 2;
            this.buttonOpenStats.TabStop = false;
            this.buttonOpenStats.Text = "Открыть историю запросов";
            this.buttonOpenStats.UseVisualStyleBackColor = true;
            this.buttonOpenStats.Click += new System.EventHandler(this.buttonOpenStats_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 294);
            this.Controls.Add(this.buttonOpenStats);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.textBoxStats);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Сервер колебаний";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxStats;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonOpenStats;
    }
}

