using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecDetailWebScraper
{
    public partial class FormSetSearchWord : Form
    {
        public FormDetailScraper DetailScraper { get; set; }

        public FormSetSearchWord()
        {
            InitializeComponent();
        }

        private void txtSearchWord_TextChanged(object sender, EventArgs e)
        {
            this.btnOK.Enabled = this.txtSearchWord.Text.Trim() != String.Empty;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            List<String> args = new List<String>();
            args.Add(this.txtSearchWord.Text);

            DetailScraper.Args = args;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSetSearchWord_FormClosed(object sender, FormClosedEventArgs e)
        {
            DetailScraper.ShowSetSearchWord = false;
        }
    }
}
