using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
		private readonly Controller _controller = new Controller();

        public Form1()
        {
            InitializeComponent();
        }

		private async void buttonDb_Click(object sender, EventArgs e)
		{
			labelResponse.Text = await _controller.CallDbAsync();
		}

		private async void buttonService_Click(object sender, EventArgs e)
		{
			labelResponse.Text = await _controller.CallServiceAsync();
		}
	}
}
