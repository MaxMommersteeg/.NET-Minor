using System;

namespace DelegatesInHetWild
{
    partial class Form1
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
            this.txtGroet = new System.Windows.Forms.TextBox();
            this.redGreenButton1 = new DelegatesInHetWild.RedGreenButton();
            this.btnClickMe = new DelegatesInHetWild.RedGreenButton();
            this.SuspendLayout();
            // 
            // txtGroet
            // 
            this.txtGroet.Location = new System.Drawing.Point(58, 41);
            this.txtGroet.Name = "txtGroet";
            this.txtGroet.Size = new System.Drawing.Size(462, 44);
            this.txtGroet.TabIndex = 1;
            // 
            // redGreenButton1
            // 
            this.redGreenButton1.Location = new System.Drawing.Point(447, 137);
            this.redGreenButton1.Name = "redGreenButton1";
            this.redGreenButton1.Size = new System.Drawing.Size(91, 125);
            this.redGreenButton1.TabIndex = 2;
            this.redGreenButton1.Text = "redGreenButton1";
            this.redGreenButton1.UseVisualStyleBackColor = true;
            // 
            // btnClickMe
            // 
            this.btnClickMe.Location = new System.Drawing.Point(141, 137);
            this.btnClickMe.Name = "btnClickMe";
            this.btnClickMe.Size = new System.Drawing.Size(260, 208);
            this.btnClickMe.TabIndex = 0;
            this.btnClickMe.Text = "Click Me";
            this.btnClickMe.UseVisualStyleBackColor = true;
            this.btnClickMe.Click += new System.EventHandler(this.btnClickMe_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 446);
            this.Controls.Add(this.redGreenButton1);
            this.Controls.Add(this.txtGroet);
            this.Controls.Add(this.btnClickMe);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtGroet;
        private RedGreenButton redGreenButton1;
        private RedGreenButton btnClickMe;
    }
}

