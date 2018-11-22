namespace cviceni9
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_START = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_START
            // 
            this.bt_START.ForeColor = System.Drawing.Color.Red;
            this.bt_START.Location = new System.Drawing.Point(12, 12);
            this.bt_START.Name = "bt_START";
            this.bt_START.Size = new System.Drawing.Size(57, 40);
            this.bt_START.TabIndex = 0;
            this.bt_START.Text = "TEST";
            this.bt_START.UseVisualStyleBackColor = true;
            this.bt_START.Click += new System.EventHandler(this.bt_START_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 237);
            this.Controls.Add(this.bt_START);
            this.Location = new System.Drawing.Point(50, 50);
            this.Name = "Form1";
            this.Text = "FormMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_START;
    }
}

