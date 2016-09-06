namespace ConvertInfixToPostfixExpression
{
    partial class AStepCtrl
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
            this.lblStack = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.grpStepNumber = new System.Windows.Forms.GroupBox();
            this.grpStepNumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStack
            // 
            this.lblStack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStack.ForeColor = System.Drawing.Color.Crimson;
            this.lblStack.Location = new System.Drawing.Point(21, 24);
            this.lblStack.Name = "lblStack";
            this.lblStack.Size = new System.Drawing.Size(556, 22);
            this.lblStack.TabIndex = 0;
            this.lblStack.Text = "Stack:";
            // 
            // lblOutput
            // 
            this.lblOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOutput.ForeColor = System.Drawing.Color.Green;
            this.lblOutput.Location = new System.Drawing.Point(21, 50);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(556, 22);
            this.lblOutput.TabIndex = 0;
            this.lblOutput.Text = "Output:";
            // 
            // grpStepNumber
            // 
            this.grpStepNumber.Controls.Add(this.lblOutput);
            this.grpStepNumber.Controls.Add(this.lblStack);
            this.grpStepNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStepNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStepNumber.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grpStepNumber.Location = new System.Drawing.Point(0, 0);
            this.grpStepNumber.Name = "grpStepNumber";
            this.grpStepNumber.Size = new System.Drawing.Size(600, 80);
            this.grpStepNumber.TabIndex = 2;
            this.grpStepNumber.TabStop = false;
            this.grpStepNumber.Text = "Step";
            // 
            // AStepCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpStepNumber);
            this.Name = "AStepCtrl";
            this.Size = new System.Drawing.Size(600, 80);
            this.grpStepNumber.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStack;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.GroupBox grpStepNumber;
    }
}
