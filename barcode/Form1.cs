using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using ZXing;
namespace barcode
{
	public partial class Form1 : Form
	{
		SoundPlayer player;

		public Form1()
		{
			player = new SoundPlayer();
			InitializeComponent();
		}
	
		private void Form1_Load(object sender, EventArgs e)
		{

		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			textBox1.ResetText();
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Image file(*.png,*.jpg,*.jpeg)|*.png,*.jpg,*.jpeg";
			if (dialog.ShowDialog()==DialogResult.OK)
			{
				pictureBox1.Image = Image.FromFile(dialog.FileName);
			}
		}
		public string decoded;

		private void button4_Click(object sender, EventArgs e)
		{
			BarcodeReader reader = new BarcodeReader();
			Result result = reader.Decode((Bitmap)pictureBox1.Image);
			if (result!=null)
			{
				decoded = result.ToString();
				if (decoded != null)
				{
					player.Play();
					textBox1.Text = decoded;
				}
				else
				{
					MessageBox.Show("Error");
					player.Stop();
				}
			}
			
		}
	}
}
