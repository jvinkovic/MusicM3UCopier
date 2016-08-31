using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Windows;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;
using Microsoft.WindowsAPICodePack;

namespace glazbaCopy
{
    public partial class PlaylistaKopiranje : Form
    {
        private string file = "";
        private string folder = "";
        delegate void delegatAsync(ProgressBar bar);
        delegate void async2(ProgressBar bar);
        string preskoceni = "";
        delegate void pbMaxDel(int max);
        delegate void pbIncDel();
        delegate void enaKop();
        TaskbarManager tbManager = null;
        bool moze = false;

        public PlaylistaKopiranje()
        {
            InitializeComponent();
            napredak.Minimum = 0;
            napredak.Maximum = 1;
            napredak.Step = 1;
        }

        //
        // ukloniti X gumb jer se ne smije zatvarati putem njega
        // sruši se jer djeca ne završe kada treba
        // 
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        //otvori playlistu
        private void button1_Click(object sender, EventArgs e)
        {
            fileDialog.Title = "Open m3u file";
            fileDialog.Filter = "M3U files|*.m3u";
            fileDialog.InitialDirectory = @"C:\";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.file = fileDialog.FileName;
                this.tbUlaz.Text = this.file;
            }
        }


        //otvori odredište
        private void btnDest_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.folder = folderDialog.SelectedPath;
                this.tbIzlaz.Text = this.folder;
            }
        }


        private void pbInc() {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new pbIncDel(pbInc));
                }
                else
                {
                    this.napredak.Increment(1);
                }
            }
            catch (Exception)
            {
            }
        }

        private void pbMax(int max)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new pbMaxDel(pbMax), max);
                }
                else
                {
                    this.napredak.Maximum = max;
                    this.napredak.Minimum = 0;
                    this.napredak.Value = 0;
                }
            }
            catch (Exception)
            {
            }

        }

        private void eKop() {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new enaKop(eKop));
                }
                else
                {
                    this.btnKopiraj.Enabled = true;
                }
            }
            catch (Exception)
            {
            }
        }

        //ASINKRONO KOPIRANJE!
        private void aCp(ProgressBar bar)
        {
            

            try
            {
                //da se pojavljuje i u taskbaru progressBar
                if (TaskbarManager.IsPlatformSupported)
                {
                    moze = true;
                    tbManager = TaskbarManager.Instance;
                    tbManager.SetProgressState(TaskbarProgressBarState.Normal);
                }

            }
            catch (Exception)
            {
            }
            if (validate())
            {
                try
                {
                    this.preskoceni = "";
                    //bar.Value = 0;//**************************
                    string line;
                    System.IO.StreamReader fr = new System.IO.StreamReader(this.file, Encoding.Default);
                    line = fr.ReadLine();
                    if (line != "#EXTM3U")
                    {
                        MessageBox.Show("Nije odabrana valjana m3u datoteka!");
                        fr.Close();
                        enaKop btn = new enaKop(eKop);
                        btn.Invoke();
                        return;
                    }

                    //****************************
                    pbMaxDel max = new pbMaxDel(pbMax);
                    int NlinMax = (File.ReadLines(this.file).Count() - 1) / 2;
                    max.Invoke(NlinMax);
                    if (moze) {
                        tbManager.SetProgressValue(0, NlinMax);
                    }
                    int count = 0;
                    while ((line = fr.ReadLine()) != null)
                    {
                        count++;
                        line = fr.ReadLine();  //jer mora preskočti parne

                        //kopiranje redom i napredak zabilježen
                        string sourceFile = line;
                        string imeFile = Path.GetFileName(sourceFile);
                        string destFile = System.IO.Path.Combine(this.folder, imeFile);
                        if (!File.Exists(destFile))
                        {
                            if (File.Exists(sourceFile))
                            {
                                System.IO.File.Copy(sourceFile, destFile, true);
                            }
                            else
                            {
                                this.preskoceni += sourceFile + "\n";
                            }
                        }
                        if (moze)
                        {
                            //u taskbaru zabilježi napredak (trenutni, maksimalni)
                            this.tbManager.SetProgressValue(count, NlinMax);
                        }

                       // bar.Increment(1);//*******************************
                        pbIncDel inc = new pbIncDel(pbInc);
                        inc.Invoke();
                    }

                    fr.Close();
                    MessageBox.Show("Gotovo!");
                }
                catch (IOException greska)
                {
                    MessageBox.Show("Greška:\n\n" + greska.ToString());
                }
                finally
                {
                    enaKop btn = new enaKop(eKop);
                    btn.Invoke();
                    if (this.preskoceni != "")
                    {
                        MessageBox.Show("Preskočeni su jer ne postoje:\n\n" + this.preskoceni, "Preskočeni!");
                        preskoceni = "";
                    }
                    moze = false;
                    file = "";
                    folder = "";
                }
            }
            else
            {
                enaKop btn = new enaKop(eKop);
                btn.Invoke();
            }

        }


        //kopiraj to pozivajućui putem delegata asinkrono kopiranje
        private void kopiraj_Click(object sender, EventArgs e)
        {
            this.btnKopiraj.Enabled = false;
            delegatAsync kop = new delegatAsync(aCp);
            kop.BeginInvoke(this.napredak, null, null);

        }

        private bool validate()
        {
            if (this.file == "")
            {
                if (tbUlaz.Text == "")
                {
                    MessageBox.Show("Odaberite m3u!");
                    return false;
                }
                else {
                    this.file = tbUlaz.Text;
                }
            }
            if (this.folder == "")
            {
                if (tbIzlaz.Text == "")
                {
                    MessageBox.Show("Odaberite folder!");
                    return false;
                }
                else {
                    this.folder = tbIzlaz.Text;
                }
            }
            return true;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
