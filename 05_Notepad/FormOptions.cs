using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05_Notepad
{
    public partial class FormOptions : Form
    {
        public Color EditorForeColor
        {
            get { return buttonForeColor.BackColor; }
            set { buttonForeColor.BackColor = value; }
        }
        public Color EditorBackColor
        {
            get { return buttonBackColor.BackColor; }
            set { buttonBackColor.BackColor = value; }
        }
        public Font EditorFont
        {
            get { return buttonFont.Font; }
            set { buttonFont.Font = value; }
        }

        public FormOptions()
        {
            InitializeComponent();
        }
        private void ButtonForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            colorDialog.Color = buttonForeColor.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonForeColor.BackColor = colorDialog.Color;
            }
        }
        private void ButtonBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            colorDialog.Color = buttonBackColor.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonBackColor.BackColor = colorDialog.Color;
            }
        }

        private void ButtonFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            fontDialog.Font = buttonFont.Font;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                buttonFont.Font = fontDialog.Font;
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


    }
}
