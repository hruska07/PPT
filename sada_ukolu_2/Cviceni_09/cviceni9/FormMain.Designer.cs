namespace cviceni9
{
    partial class FormMain
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
            this.button1 = new System.Windows.Forms.Button();
            this.lb_proces = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_START
            // 
            this.bt_START.ForeColor = System.Drawing.Color.Red;
            this.bt_START.Location = new System.Drawing.Point(142, 12);
            this.bt_START.Name = "bt_START";
            this.bt_START.Size = new System.Drawing.Size(57, 40);
            this.bt_START.TabIndex = 0;
            this.bt_START.Text = "TEST";
            this.bt_START.UseVisualStyleBackColor = true;
            this.bt_START.Click += new System.EventHandler(this.bt_START_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Vygenerovat originální";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_proces
            // 
            this.lb_proces.AutoSize = true;
            this.lb_proces.Location = new System.Drawing.Point(241, 48);
            this.lb_proces.Name = "lb_proces";
            this.lb_proces.Size = new System.Drawing.Size(0, 13);
            this.lb_proces.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(12, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 40);
            this.button2.TabIndex = 3;
            this.button2.Text = "Vygenerovat seřazený";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(142, 58);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(57, 40);
            this.button3.TabIndex = 4;
            this.button3.Text = "TEST";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 111);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lb_proces);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_START);
            this.Location = new System.Drawing.Point(50, 50);
            this.Name = "FormMain";
            this.Text = "Hromadné zpracování dat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_START;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_proces;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

