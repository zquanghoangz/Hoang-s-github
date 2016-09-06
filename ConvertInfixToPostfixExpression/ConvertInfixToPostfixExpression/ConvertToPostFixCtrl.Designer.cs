namespace ConvertInfixToPostfixExpression
{
    partial class ConvertToPostFixCtrl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtInputExp = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.btnStepOver = new System.Windows.Forms.Button();
            this.pnlShowStep = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblSplitedExp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter your expression:";
            // 
            // txtInputExp
            // 
            this.txtInputExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputExp.Location = new System.Drawing.Point(139, 12);
            this.txtInputExp.Name = "txtInputExp";
            this.txtInputExp.Size = new System.Drawing.Size(400, 20);
            this.txtInputExp.TabIndex = 1;
            this.txtInputExp.Text = "(4+8)*(6-5)/((3-2)*(2+2))";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(551, 10);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(105, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start Convert";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnNextStep
            // 
            this.btnNextStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextStep.Enabled = false;
            this.btnNextStep.Location = new System.Drawing.Point(662, 10);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(78, 23);
            this.btnNextStep.TabIndex = 3;
            this.btnNextStep.Text = "Next Step";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // btnStepOver
            // 
            this.btnStepOver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStepOver.Enabled = false;
            this.btnStepOver.Location = new System.Drawing.Point(746, 10);
            this.btnStepOver.Name = "btnStepOver";
            this.btnStepOver.Size = new System.Drawing.Size(75, 23);
            this.btnStepOver.TabIndex = 3;
            this.btnStepOver.Text = "Step Over";
            this.btnStepOver.UseVisualStyleBackColor = true;
            this.btnStepOver.Click += new System.EventHandler(this.btnStepOver_Click);
            // 
            // pnlShowStep
            // 
            this.pnlShowStep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlShowStep.AutoScroll = true;
            this.pnlShowStep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlShowStep.Location = new System.Drawing.Point(12, 102);
            this.pnlShowStep.Name = "pnlShowStep";
            this.pnlShowStep.Size = new System.Drawing.Size(809, 462);
            this.pnlShowStep.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(709, 569);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.ForeColor = System.Drawing.Color.Green;
            this.lblOutput.Location = new System.Drawing.Point(12, 40);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(809, 24);
            this.lblOutput.TabIndex = 5;
            this.lblOutput.Text = "Postfix:";
            this.lblOutput.DoubleClick += new System.EventHandler(this.lblOutput_DoubleClick);
            // 
            // lblSplitedExp
            // 
            this.lblSplitedExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSplitedExp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblSplitedExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSplitedExp.ForeColor = System.Drawing.Color.Green;
            this.lblSplitedExp.Location = new System.Drawing.Point(12, 70);
            this.lblSplitedExp.Name = "lblSplitedExp";
            this.lblSplitedExp.Size = new System.Drawing.Size(809, 24);
            this.lblSplitedExp.TabIndex = 6;
            this.lblSplitedExp.Text = "Result:";
            this.lblSplitedExp.DoubleClick += new System.EventHandler(this.lblSplitedExp_DoubleClick);
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 597);
            this.Controls.Add(this.lblSplitedExp);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.pnlShowStep);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStepOver);
            this.Controls.Add(this.btnNextStep);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtInputExp);
            this.Controls.Add(this.label1);
            this.Name = "ConvertToPostFixCtrl";
            this.ResumeLayout(false);
            //this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputExp;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Button btnStepOver;
        private System.Windows.Forms.Panel pnlShowStep;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblSplitedExp;
    }
}

