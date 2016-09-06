namespace DesktopFlashCard
{
    partial class FormCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCard));
            this.picText = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.tmrChangeCard = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picText)).BeginInit();
            this.SuspendLayout();
            // 
            // picText
            // 
            this.picText.Image = ((System.Drawing.Image)(resources.GetObject("picText.Image")));
            this.picText.Location = new System.Drawing.Point(10, 10);
            this.picText.Name = "picText";
            this.picText.Size = new System.Drawing.Size(86, 98);
            this.picText.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picText.TabIndex = 0;
            this.picText.TabStop = false;
            this.picText.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FormCard_MouseDoubleClick);
            this.picText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormCard_MouseDown);
            this.picText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormCard_MouseMove);
            this.picText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormCard_MouseUp);
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(10, 111);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(86, 23);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FormCard_MouseDoubleClick);
            this.lblName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormCard_MouseDown);
            this.lblName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormCard_MouseMove);
            this.lblName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormCard_MouseUp);
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(94, 3);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(9, 7);
            this.lblClose.TabIndex = 2;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // tmrChangeCard
            // 
            this.tmrChangeCard.Enabled = true;
            this.tmrChangeCard.Interval = 5000;
            this.tmrChangeCard.Tick += new System.EventHandler(this.tmrChangeCard_Tick);
            // 
            // FormCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(106, 140);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(106, 140);
            this.MinimumSize = new System.Drawing.Size(106, 140);
            this.Name = "FormCard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormCard_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FormCard_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormCard_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormCard_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormCard_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.picText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picText;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Timer tmrChangeCard;
    }
}

