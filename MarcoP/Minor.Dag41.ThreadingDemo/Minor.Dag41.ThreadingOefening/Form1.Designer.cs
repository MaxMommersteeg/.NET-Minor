namespace Minor.Dag41.ThreadingOefening
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
            this.txtInvoer1 = new System.Windows.Forms.TextBox();
            this.txtInvoer2 = new System.Windows.Forms.TextBox();
            this.txtInvoer3 = new System.Windows.Forms.TextBox();
            this.txtUitvoer = new System.Windows.Forms.TextBox();
            this.btnSumOfSquares = new System.Windows.Forms.Button();
            this.btnSumOfSquaresAsync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInvoer1
            // 
            this.txtInvoer1.Location = new System.Drawing.Point(155, 12);
            this.txtInvoer1.Name = "txtInvoer1";
            this.txtInvoer1.Size = new System.Drawing.Size(281, 44);
            this.txtInvoer1.TabIndex = 0;
            this.txtInvoer1.Text = "2";
            this.txtInvoer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInvoer2
            // 
            this.txtInvoer2.Location = new System.Drawing.Point(155, 62);
            this.txtInvoer2.Name = "txtInvoer2";
            this.txtInvoer2.Size = new System.Drawing.Size(281, 44);
            this.txtInvoer2.TabIndex = 1;
            this.txtInvoer2.Text = "3";
            this.txtInvoer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInvoer3
            // 
            this.txtInvoer3.Location = new System.Drawing.Point(155, 112);
            this.txtInvoer3.Name = "txtInvoer3";
            this.txtInvoer3.Size = new System.Drawing.Size(281, 44);
            this.txtInvoer3.TabIndex = 2;
            this.txtInvoer3.Text = "4";
            this.txtInvoer3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUitvoer
            // 
            this.txtUitvoer.Location = new System.Drawing.Point(155, 222);
            this.txtUitvoer.Name = "txtUitvoer";
            this.txtUitvoer.Size = new System.Drawing.Size(281, 44);
            this.txtUitvoer.TabIndex = 3;
            this.txtUitvoer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSumOfSquares
            // 
            this.btnSumOfSquares.Location = new System.Drawing.Point(12, 162);
            this.btnSumOfSquares.Name = "btnSumOfSquares";
            this.btnSumOfSquares.Size = new System.Drawing.Size(281, 54);
            this.btnSumOfSquares.TabIndex = 4;
            this.btnSumOfSquares.Text = "Sum Of Squares";
            this.btnSumOfSquares.UseVisualStyleBackColor = true;
            this.btnSumOfSquares.Click += new System.EventHandler(this.btnSumOfSquares_Click);
            // 
            // btnSumOfSquaresAsync
            // 
            this.btnSumOfSquaresAsync.Location = new System.Drawing.Point(299, 162);
            this.btnSumOfSquaresAsync.Name = "btnSumOfSquaresAsync";
            this.btnSumOfSquaresAsync.Size = new System.Drawing.Size(360, 54);
            this.btnSumOfSquaresAsync.TabIndex = 5;
            this.btnSumOfSquaresAsync.Text = "Sum Of Squares Async";
            this.btnSumOfSquaresAsync.UseVisualStyleBackColor = true;
            this.btnSumOfSquaresAsync.Click += new System.EventHandler(this.btnSumOfSquaresAsync_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 286);
            this.Controls.Add(this.btnSumOfSquaresAsync);
            this.Controls.Add(this.btnSumOfSquares);
            this.Controls.Add(this.txtUitvoer);
            this.Controls.Add(this.txtInvoer3);
            this.Controls.Add(this.txtInvoer2);
            this.Controls.Add(this.txtInvoer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInvoer1;
        private System.Windows.Forms.TextBox txtInvoer2;
        private System.Windows.Forms.TextBox txtInvoer3;
        private System.Windows.Forms.TextBox txtUitvoer;
        private System.Windows.Forms.Button btnSumOfSquares;
        private System.Windows.Forms.Button btnSumOfSquaresAsync;
    }
}

