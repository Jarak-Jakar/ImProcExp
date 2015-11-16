using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImProcExp
{
    public partial class RotationDialog : Form
    {
        public RotationDialog()
        {
            InitializeComponent();
        }

        private void ClockwiseAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Visible = false;
            angle = Int32.Parse(ClockwiseDegreesText.Text);
            return;
        }

        private void ClockwiseCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Visible = false;
            return;
        }

        public void ShowClockwise()
        {
            ClockwisePanel.Visible = true;
            return;
        }

        public void HideClockwise()
        {
            ClockwisePanel.Visible = false;
            return;
        }
    }
}
