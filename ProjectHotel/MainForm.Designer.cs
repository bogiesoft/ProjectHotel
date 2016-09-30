namespace ProjectHotel
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.InstellingB = new System.Windows.Forms.Button();
            this.Afbeelding = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Afbeelding)).BeginInit();
            this.SuspendLayout();
            // 
            // InstellingB
            // 
            this.InstellingB.Location = new System.Drawing.Point(898, 510);
            this.InstellingB.Name = "InstellingB";
            this.InstellingB.Size = new System.Drawing.Size(75, 23);
            this.InstellingB.TabIndex = 0;
            this.InstellingB.Text = "Instellingen";
            this.InstellingB.UseVisualStyleBackColor = true;
            this.InstellingB.Click += new System.EventHandler(this.InstellingB_Click);
            // 
            // Afbeelding
            // 
            this.Afbeelding.Location = new System.Drawing.Point(13, 13);
            this.Afbeelding.Name = "Afbeelding";
            this.Afbeelding.Size = new System.Drawing.Size(971, 480);
            this.Afbeelding.TabIndex = 1;
            this.Afbeelding.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 545);
            this.Controls.Add(this.Afbeelding);
            this.Controls.Add(this.InstellingB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Hotel Sim";
            ((System.ComponentModel.ISupportInitialize)(this.Afbeelding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InstellingB;
        private System.Windows.Forms.PictureBox Afbeelding;
    }
}

