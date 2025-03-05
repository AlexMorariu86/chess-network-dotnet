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
    public partial class Rules : Form
    {
        public Rules()
        {
            InitializeComponent();
        }

        private void Rules_Load(object sender, EventArgs e)
        {
            PictureBox pr = new PictureBox();
            pr.Location = new Point(0, 0);
            pr.Size = new Size(825, 564);
            pr.Image = Image.FromFile("C:\\Users\\senon\\Desktop\\sah\\sah\\poze\\rule1.jpg");
            pr.Visible = true;
            this.Controls.Add(pr);
            
        }
        
    }
}
