namespace cc
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
            ((System.ComponentModel.ISupportInitialize)(this.drawCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // drawCanvas
            // 
            this.drawCanvas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.drawCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawCanvas.Location = new System.Drawing.Point(12, 12);
            this.drawCanvas.Name = "drawCanvas";
            this.drawCanvas.Size = new System.Drawing.Size(572, 307);
            this.drawCanvas.TabIndex = 0;
            this.drawCanvas.TabStop = false;
            this.drawCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawCanvas_MouseDown);
            this.drawCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawCanvas_MouseMove);
            this.drawCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawCanvas_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(596, 408);
            this.Controls.Add(this.drawCanvas);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drawCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox drawCanvas;




    }
}

