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

namespace _05_Notepad
{
    public partial class Form1 : Form
    {
        private String currentFileName;
        private Boolean currentTextChanged;
        public Form1()
        {
            InitializeComponent();
            currentFileName = "";
            currentTextChanged = false;
        }
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!currentTextChanged ||
                MessageBox.Show("Do you want to continue?",
                                "Content is changed.",
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                richTextBoxEditor.Text = "";
                currentFileName = "";
                currentTextChanged = false;
            }
        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!currentTextChanged ||
                MessageBox.Show("Do you want to continue?",
                                "Content is changed.",
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Text files|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBoxEditor.Text = File.ReadAllText(openFileDialog.FileName);
                }
                currentFileName = openFileDialog.FileName;
                currentTextChanged = false;
            }
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFileName != "")
            {
                File.WriteAllText(currentFileName, richTextBoxEditor.Text);
                currentTextChanged = false;
            }
            else
            {
                SaveAsToolStripMenuItem_Click(null, null);
            }
        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Text files|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, richTextBoxEditor.Text);
            }
            currentFileName = saveFileDialog.FileName;
            currentTextChanged = false;
        }

        private void RichTextBoxEditor_TextChanged(object sender, EventArgs e)
        {
            currentTextChanged = true;
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOptions formOptions = new FormOptions();

            formOptions.EditorForeColor = richTextBoxEditor.ForeColor;
            formOptions.EditorBackColor = richTextBoxEditor.BackColor;
            formOptions.EditorFont = richTextBoxEditor.Font;
            if (formOptions.ShowDialog() == DialogResult.OK)
            {
                richTextBoxEditor.ForeColor = formOptions.EditorForeColor;
                richTextBoxEditor.BackColor = formOptions.EditorBackColor;
                richTextBoxEditor.Font = formOptions.EditorFont;
            }
        }
    }
}
