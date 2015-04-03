using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using theBrent.FitLibrary;

namespace theBrent.FitExplorer
{
    public partial class formMain : Form
    {
        private string fileName;
        public formMain()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialogOpenFitFile.ShowDialog() == DialogResult.OK)
            {
                this.fileName = this.openFileDialogOpenFitFile.FileName;
                treeView1.Nodes.Clear();

                FileStream s = new FileStream(this.fileName, FileMode.Open);
                byte[] b = new byte[s.Length];
                s.Read(b, 0, b.Length);
                s.Close();

                FitFile fitFile = new FitFile(b);

                TreeNode top = new TreeNode();
                top.Text = Path.GetFileName(this.fileName) + "(" + fitFile.FileType.ToString() + ")";
                foreach (DataMessage d in fitFile.DataMessages)
                {
                    TreeNode n = new TreeNode();
                    n.Text = d.GlobalMessageNumber.ToString() + "(" + d.GlobalMessageNumber + ")";
                    top.Nodes.Add(n);
                }
                treeView1.Nodes.Add(top);
            }
        }

        private void testConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new formTest();
            form.Show();
        }
    }
}
