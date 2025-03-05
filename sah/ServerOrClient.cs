using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sah
{
	public partial class ServerOrClient : Form
	{
		public ServerOrClient()
		{
			InitializeComponent();
		}

		private void btnServer_Click(object sender, EventArgs e)
		{
			Game game = new Game(1);
			game.Show();
		}

		private void btnClient_Click(object sender, EventArgs e)
		{
			Game game = new Game(2);
			game.Show();
		}
	}
}
