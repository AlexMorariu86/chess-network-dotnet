using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static sah.Piece;

namespace sah
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {

			
			playBtn.Image = Image.FromFile("C:\\Users\\senon\\Desktop\\sah\\sah\\poze\\Play.jpg");
            rulesBtn.Image = Image.FromFile("C:\\Users\\senon\\Desktop\\sah\\sah\\poze\\RULES.jpg");
            exitBtn.Image = Image.FromFile("C:\\Users\\senon\\Desktop\\sah\\sah\\poze\\exit.jpg");
        }
        private void button1_Click(object sender, EventArgs e)
        {
			//Game game = new Game();
			//game.Show();
			ServerOrClient serverOrClient = new ServerOrClient();
			serverOrClient.Show();
		}
     

        private void rulesBtn_Click(object sender, EventArgs e)
        {
            Rules rule = new Rules();
            rule.Show();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
