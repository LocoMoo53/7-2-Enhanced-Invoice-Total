using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceTotal
{
	public partial class frmInvoiceTotal : Form
	{
		public frmInvoiceTotal()
		{
			InitializeComponent();
		}

		private void btnCalculate_Click(object sender, EventArgs e)
		{
			try
			{
				decimal subtotal = Convert.ToDecimal(txtSubtotal.Text);
				decimal discountPercent = .2m;
				decimal discountAmount = subtotal * discountPercent;
				decimal invoiceTotal = subtotal - discountAmount;



				discountAmount = Math.Round(discountAmount, 2);
				invoiceTotal = Math.Round(invoiceTotal, 2);

				txtDiscountPercent.Text = discountPercent.ToString("p1");
				txtDiscountAmount.Text = discountAmount.ToString();
				txtTotal.Text = invoiceTotal.ToString();

				txtSubtotal.Focus();
			}

			catch
			{
				MessageBox.Show(
					"Please enter a valid number for the Subtotal field.",
					"Entry Error");
			}
		}
		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void txtSubtotal_TextChanged(object sender, EventArgs e)
		{
			string text = txtSubtotal.Text;
			if (text == "")
			{
				MessageBox.Show("Subtotal is a required field",
					"Entry Error");
				txtSubtotal.Focus();

			}

		}

		public bool IsValidData()
		{
			return
			IsWithinRange(txtSubtotal, "Subtotal", 0, 10000);
		}
		public bool IsWithinRange(TextBox textBox, string name, decimal min, decimal max)
		{
			decimal number = Convert.ToDecimal(txtSubtotal.Text);
			if (number < min || number > max)
			{
				MessageBox.Show(Name + " must be between" + min + " and" + max + ".", "Entry Error");
				textBox.Focus();
				return false;
			}
			return true;
		}
	}
}