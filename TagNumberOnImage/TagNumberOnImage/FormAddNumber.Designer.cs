namespace TagNumberOnImage
{
    partial class FormAddNumber
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
            this.btnOK = new System.Windows.Forms.Button();
            this.nudAddNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(76, 48);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // nudAddNumber
            // 
            this.nudAddNumber.Location = new System.Drawing.Point(12, 20);
            this.nudAddNumber.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudAddNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAddNumber.Name = "nudAddNumber";
            this.nudAddNumber.Size = new System.Drawing.Size(210, 20);
            this.nudAddNumber.TabIndex = 1;
            this.nudAddNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FormAddNumber
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 81);
            this.Controls.Add(this.nudAddNumber);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAddNumber";
            this.Text = "Add number";
            ((System.ComponentModel.ISupportInitialize)(this.nudAddNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown nudAddNumber;
    }
}