namespace glazbaCopy
{
    partial class PlaylistaKopiranje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaylistaKopiranje));
            this.btnPly = new System.Windows.Forms.Button();
            this.tbUlaz = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIzlaz = new System.Windows.Forms.TextBox();
            this.napredak = new System.Windows.Forms.ProgressBar();
            this.btnKopiraj = new System.Windows.Forms.Button();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.SuspendLayout();
            // 
            // btnPly
            // 
            this.btnPly.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPly.Location = new System.Drawing.Point(404, 31);
            this.btnPly.Name = "btnPly";
            this.btnPly.Size = new System.Drawing.Size(58, 26);
            this.btnPly.TabIndex = 0;
            this.btnPly.Text = "...";
            this.btnPly.UseVisualStyleBackColor = true;
            this.btnPly.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbUlaz
            // 
            this.tbUlaz.Location = new System.Drawing.Point(81, 37);
            this.tbUlaz.Name = "tbUlaz";
            this.tbUlaz.ReadOnly = true;
            this.tbUlaz.Size = new System.Drawing.Size(289, 20);
            this.tbUlaz.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = ".m3u playlista:";
            // 
            // btnDest
            // 
            this.btnDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDest.Location = new System.Drawing.Point(404, 81);
            this.btnDest.Name = "btnDest";
            this.btnDest.Size = new System.Drawing.Size(58, 26);
            this.btnDest.TabIndex = 1;
            this.btnDest.Text = "...";
            this.btnDest.UseVisualStyleBackColor = true;
            this.btnDest.Click += new System.EventHandler(this.btnDest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Odredište:";
            // 
            // tbIzlaz
            // 
            this.tbIzlaz.Location = new System.Drawing.Point(81, 84);
            this.tbIzlaz.Name = "tbIzlaz";
            this.tbIzlaz.ReadOnly = true;
            this.tbIzlaz.Size = new System.Drawing.Size(289, 20);
            this.tbIzlaz.TabIndex = 11;
            // 
            // napredak
            // 
            this.napredak.Location = new System.Drawing.Point(8, 165);
            this.napredak.Name = "napredak";
            this.napredak.Size = new System.Drawing.Size(453, 53);
            this.napredak.TabIndex = 6;
            // 
            // btnKopiraj
            // 
            this.btnKopiraj.Location = new System.Drawing.Point(8, 124);
            this.btnKopiraj.Name = "btnKopiraj";
            this.btnKopiraj.Size = new System.Drawing.Size(95, 35);
            this.btnKopiraj.TabIndex = 2;
            this.btnKopiraj.Text = "Kopiraj!";
            this.btnKopiraj.UseVisualStyleBackColor = true;
            this.btnKopiraj.Click += new System.EventHandler(this.kopiraj_Click);
            // 
            // fileDialog
            // 
            this.fileDialog.InitialDirectory = "Desktop";
            this.fileDialog.SupportMultiDottedExtensions = true;
            // 
            // btnOdustani
            // 
            this.btnOdustani.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOdustani.ForeColor = System.Drawing.Color.Red;
            this.btnOdustani.Location = new System.Drawing.Point(366, 124);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(95, 35);
            this.btnOdustani.TabIndex = 101;
            this.btnOdustani.Text = "Zatvori";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // PlaylistaKopiranje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.OrangeRed;
            this.ClientSize = new System.Drawing.Size(473, 230);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnKopiraj);
            this.Controls.Add(this.napredak);
            this.Controls.Add(this.tbIzlaz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbUlaz);
            this.Controls.Add(this.btnPly);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PlaylistaKopiranje";
            this.Text = "PlaylistaKopiranje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPly;
        private System.Windows.Forms.TextBox tbUlaz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbIzlaz;
        private System.Windows.Forms.ProgressBar napredak;
        private System.Windows.Forms.Button btnKopiraj;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.Button btnOdustani;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
    }
}

