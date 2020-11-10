using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myProactive
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Developed by: " + Environment.NewLine + "" + Environment.NewLine +
				"rafal.adamczyk@dsv.com" + Environment.NewLine + Environment.NewLine +
				"EDI Support Team®", "myEDI", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void deployComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void button_go_Click(object sender, EventArgs e)
		{
			OutlookEmails outlook = new OutlookEmails();
			outlook.ReadMailItems();
		}
	}
}
