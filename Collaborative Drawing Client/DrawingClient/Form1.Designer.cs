namespace dClient
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
            this.drawCanvas = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.drawCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // drawCanvas
            // 
            this.drawCanvas.BackColor = System.Drawing.Color.White;
            this.drawCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawCanvas.Location = new System.Drawing.Point(12, 12);
            this.drawCanvas.Name = "drawCanvas";
            this.drawCanvas.Size = new System.Drawing.Size(572, 307);
            this.drawCanvas.TabIndex = 5;
            this.drawCanvas.TabStop = false;
            this.drawCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawCanvas_MouseDown);
            this.drawCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawCanvas_MouseMove);
            this.drawCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawCanvas_MouseUp);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(509, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(596, 408);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.drawCanvas);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drawCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox drawCanvas;
        private System.Windows.Forms.Button button1;
    }
}

