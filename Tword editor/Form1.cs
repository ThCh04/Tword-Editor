using System.IO;
namespace Tword_editor
{
    public partial class Form1 : Form
    {
        String into;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            

            if (file.ShowDialog() == DialogResult.OK)
            {
                into = file.FileName;

                using (StreamReader read = new StreamReader(into))
                {
                    richTextBox1.Text = read.ReadToEnd();
                }
            }

            this.Text = "Text Editor";

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = " Texto | *.txt ";

            if(into != null)
            {
                using(StreamWriter write = new StreamWriter(into))
                {
                    write.Write(richTextBox1.Text);
                }
            }
            else
            {
                if(save.ShowDialog() == DialogResult.OK)
                {
                    into = save.FileName;
                    using (StreamWriter write = new StreamWriter(save.FileName))
                    {
                        write.Write(richTextBox1.Text);
                    }
                }
            }

            this.Text = "Text Editor";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                toolStripButton1_Click(sender, e);

            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                toolStripButton1_Click(sender, e);

            }

            if (e.KeyCode == Keys.O && Control.ModifierKeys == Keys.Control)
            {
                toolStripButton2_Click(sender, e);

            }

            if (e.KeyCode == Keys.G && Control.ModifierKeys == Keys.Control)
            {
                toolStripButton3_Click(sender, e);

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.Text = "Tword Editor*";  
        }
    }
}