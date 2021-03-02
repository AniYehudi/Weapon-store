namespace Practice
{
    partial class DialogConfirmationP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogConfirmationP));
            this.buttonNu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNu
            // 
            this.buttonNu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonNu.Location = new System.Drawing.Point(363, 93);
            this.buttonNu.Name = "buttonNu";
            this.buttonNu.Size = new System.Drawing.Size(107, 50);
            this.buttonNu.TabIndex = 65;
            this.buttonNu.Text = "Nu";
            this.buttonNu.UseVisualStyleBackColor = true;
            this.buttonNu.Click += new System.EventHandler(this.buttonNu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 29);
            this.label1.TabIndex = 64;
            this.label1.Text = "Mesaj!!!";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button5.Location = new System.Drawing.Point(62, 93);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(107, 50);
            this.button5.TabIndex = 63;
            this.button5.Text = "Da";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // DialogConfirmationP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(537, 155);
            this.Controls.Add(this.buttonNu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DialogConfirmationP";
            this.Text = "Confirm!";
            this.Load += new System.EventHandler(this.DialogConfirmationP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNu;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
    }
}