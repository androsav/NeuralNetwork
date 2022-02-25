using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestNN
{
	public partial class AskForLabelForm : Form
	{
		public static int label;
		public AskForLabelForm()
		{
			InitializeComponent();
		}

		private void enterButton_Click(object sender, EventArgs e)
		{
			label = Convert.ToInt32(labelTextBox.Text);
			MainForm.lab = label;
			labelTextBox.Text = null;
			MainForm.askForLabelForm.Close();
		}
	}
}
