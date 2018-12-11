using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterChef3
{
    public partial class cuisine : Form
    {
        public cuisine()
        {
            InitializeComponent();
            this.Text = "Cuisine";
            this.Size = new Size(615, 635);

            GroupBox chefcuisineBox = new GroupBox();
            chefcuisineBox.FlatStyle = FlatStyle.Flat;
            chefcuisineBox.Text = "Chef de cuisine";
            chefcuisineBox.Size = new Size(285, 285);
            chefcuisineBox.Location = new Point(10, 10);
            Controls.Add(chefcuisineBox);

            GroupBox plongeurBox = new GroupBox();
            plongeurBox.FlatStyle = FlatStyle.Flat;
            plongeurBox.Text = "Plongeur";
            plongeurBox.Size = new Size(285, 285);
            plongeurBox.Location = new Point(305, 10);
            Controls.Add(plongeurBox);

            GroupBox chefpartie1Box = new GroupBox();
            chefpartie1Box.FlatStyle = FlatStyle.Flat;
            chefpartie1Box.Text = "Chef de partie 1";
            chefpartie1Box.Size = new Size(285, 285);
            chefpartie1Box.Location = new Point(10, 305);
            Controls.Add(chefpartie1Box);

            GroupBox chefpartie2Box = new GroupBox();
            chefpartie2Box.FlatStyle = FlatStyle.Flat;
            chefpartie2Box.Text = "Chef de partie 2";
            chefpartie2Box.Size = new Size(285, 285);
            chefpartie2Box.Location = new Point(305, 305);
            Controls.Add(chefpartie2Box);
        }
    }
}
