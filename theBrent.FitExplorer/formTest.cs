using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using theBrent.FitLibrary;

namespace theBrent.FitExplorer
{
    public partial class formTest : Form
    {
        public formTest()
        {
            InitializeComponent();
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            if (this.openFitFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                treeViewFitFile.Nodes.Clear();
                this.textBoxFileName.Text = this.openFitFileDialog.FileName;

                FileStream s = new FileStream(this.openFitFileDialog.FileName, FileMode.Open);
                byte[] b = new byte[s.Length];
                s.Read(b, 0, b.Length);
                s.Close();
                FitFile f = new FitFile(b);
                TreeNode top = new TreeNode();
                top.Text = f.FileType.ToString();
                foreach (DataMessage d in f.DataMessages)
                {
                    TreeNode n = new TreeNode();
                    n.Text = d.GlobalMessageNumber.ToString();
                    foreach (FitField ff in d.Fields)
                    {
                        TreeNode nf = new TreeNode();
                        if (ff.FieldName != null)
                        {
                            nf.Text = ff.FieldName;
                        }
                        else
                        {
                            nf.Text = "(Unknown field) " + ff.FieldDefinitionNumber.ToString();
                        }
                        nf.Text += " (" + ff.GetType().ToString() + ")";
                        nf.Text += " = " + ff.GetDynamicValue();
                        n.Nodes.Add(nf);
                    }
                    top.Nodes.Add(n);
                }
                treeViewFitFile.Nodes.Add(top);

            }
        }

    }
}
