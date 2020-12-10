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
                if (textBoxKeyword.Text != string.Empty)
                {
                    ICipher userData = new PlayfairCipher();
                    textBoxOutput.Text = userData.Encode(textBoxInput.Text, textBoxKeyword.Text);
                }
                else
                    MessageBox.Show("There is no keyword in input string. Enter keyword.", "Warning!");
            }
            else if (radioButtonVigenere.Checked == true)
            {
                if (textBoxKeyword.Text != string.Empty)
                {
                    ICipher userData = new VigenereCipher();
                    textBoxOutput.Text = userData.Encode(textBoxInput.Text, textBoxKeyword.Text);
                }
                else
                    MessageBox.Show("There is no keyword in input string. Enter keyword", "Warning!");
            }
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            
            if (radioButtonPlayfair.Checked == true)
            {
                if (textBoxKeyword.Text != string.Empty)
                {
                    ICipher userData = new PlayfairCipher();
                    textBoxOutput.Text = userData.Decode(textBoxInput.Text, textBoxKeyword.Text);
                }
                else
                    MessageBox.Show("There is no keyword in input string. Enter keyword.", "Warning!");
            }
            else if (radioButtonVigenere.Checked == true)
            {
                if (textBoxKeyword.Text != string.Empty)
                {
                    ICipher userData = new VigenereCipher();
                    textBoxOutput.Text = userData.Decode(textBoxInput.Text, textBoxKeyword.Text);
                }
                else
                    MessageBox.Show("There is no keyword in input string. Enter keyword.", "Warning!");
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
            MessageBox.Show("Saving output data", "Notification");
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fileName = sfd.FileName;
                File.WriteAllText(fileName, textBoxOutput.Text);
            }

            MessageBox.Show("Saving input data", "Notitfication");
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fileName = sfd.FileName;
                File.WriteAllText(fileName, textBoxInput.Text);
            }
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program developed by Krupsky Artemy, student of 484 gr.\nThe program encrypt/decrypt text.\nWorks only with latin alphabet", "About program");
        }
    }
}
