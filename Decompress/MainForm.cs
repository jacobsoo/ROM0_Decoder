using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Decompress
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;
            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                foreach (string fileLoc in filePaths)
                {
                    txtFile.Text = fileLoc;
                    loadROM();
                }
            }
        }

        private void loadROM()
        {
            dataBox.Text = "FileName:" + txtFile.Text + "\n\n";
            ROM romHeader = new ROM();
            ROM_Header rom_Header = romHeader.getROMHeader(txtFile.Text);
            Decomp decom = new Decomp();
            byte[] data = new byte[rom_Header.data.Length - 12];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = rom_Header.data[i + 12];
            }
            byte[] unpacked = decom.unpack(data);
            byte[] password = new byte[64];
            for (int i = 0; i < 64; i++)
            {
                password[i] = unpacked[i + 20];
                if (password[i] == 0)
                    break;
            }
            byte[] dyndnspassword = new byte[32];
            for (int i = 0; i < 32; i++)
            {
                dyndnspassword[i] = unpacked[839 + i];
                if (dyndnspassword[i] == 0)
                    break;
            }
            byte[] dyndnsusername = new byte[32];
            for (int i = 0; i < 32; i++)
            {
                dyndnsusername[i] = unpacked[849 + 32 + i];
                if (dyndnsusername[i] == 0)
                    break;
            }
            byte[] dyndnsemail = new byte[64];
            for (int i = 0; i < 64; i++)
            {
                dyndnsemail[i] = unpacked[849 + 32 + 32 + i];
                if (dyndnsemail[i] == 0)
                    break;
            }
            byte[] dyndnshost = new byte[16];
            for (int i = 0; i < 16; i++)
            {
                dyndnshost[i] = unpacked[849 + 32 + 32 + 64 + i];
                if (dyndnshost[i] == 0)
                    break;
            }

            byte[] unknownEmail = new byte[32];
            for (int i = 0; i < unknownEmail.Length; i++)
            {
                unknownEmail[i] = unpacked[0x2822 + i];
                if (unknownEmail[i] == 0)
                    break;
            }
            byte[] unknownPassword = new byte[32];
            for (int i = 0; i < unknownPassword.Length; i++)
            {
                unknownPassword[i] = unpacked[0x2822 + 32 + i];
                if (unknownPassword[i] == 0)
                    break;
            }

            dataBox.Text = dataBox.Text + "Password:" + System.Text.ASCIIEncoding.ASCII.GetString(password);
            dataBox.Text = dataBox.Text + "\n\nDynDNS Settings" + "\n";
            dataBox.Text = dataBox.Text + "\nUsername:" + System.Text.ASCIIEncoding.ASCII.GetString(dyndnsusername);
            dataBox.Text = dataBox.Text + "\nPassword:" + System.Text.ASCIIEncoding.ASCII.GetString(dyndnspassword);
            dataBox.Text = dataBox.Text + "\nEmail:" + System.Text.ASCIIEncoding.ASCII.GetString(dyndnsemail);
            dataBox.Text = dataBox.Text + "\nHost:" + System.Text.ASCIIEncoding.ASCII.GetString(dyndnshost);
            dataBox.Text = dataBox.Text + "\n\nUnknown Email" + "\n";
            dataBox.Text = dataBox.Text + "\nEmail:" + System.Text.ASCIIEncoding.ASCII.GetString(unknownEmail);
            dataBox.Text = dataBox.Text + "\nPassword:" + System.Text.ASCIIEncoding.ASCII.GetString(unknownPassword);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = openFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFile.Text = openFile.FileName;

                loadROM();
            }
        }

    }
}
