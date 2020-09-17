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

namespace _2_lab_encryption
{
    public partial class MainForm : Form
    {
        private string fileName;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            if (radioButtonPlayfair.Checked == true)
            {
                ICipher userData = new PlayfairCipher();
                textBoxOutput.Text = userData.Encode(textBoxInput.Text, textBoxKeyword.Text);

                if (textBoxKeyword.Text == string.Empty)
                    MessageBox.Show("There is no keyword in input string. Keyword set to default value.", "Warning!");
            }
            else if (radioButtonVigenere.Checked == true)
            {
                ICipher userData = new VigenereCipher();
                textBoxOutput.Text = userData.Encode(textBoxInput.Text, textBoxKeyword.Text);

                if (textBoxKeyword.Text == string.Empty)
                    MessageBox.Show("There is no keyword in input string. Keyword set to default value.", "Warning!");
            }
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            if (radioButtonPlayfair.Checked == true)
            {
                ICipher userData = new PlayfairCipher();
                textBoxOutput.Text = userData.Decode(textBoxInput.Text, textBoxKeyword.Text);
            }
            else if (radioButtonVigenere.Checked == true)
            {
                ICipher userData = new VigenereCipher();
                textBoxOutput.Text = userData.Decode(textBoxInput.Text, textBoxKeyword.Text);
            }
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.FileName;
                textBoxInput.Clear();
                textBoxInput.Text = File.ReadAllText(fileName);
            }
        }

        private void buttonSaveFile_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fileName = sfd.FileName;
                File.WriteAllText(fileName, textBoxOutput.Text);
            }
        }
    }
}
