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
        public Label ccLabel = new Label();
        public Label cp1Label = new Label();
        public Label cp2Label = new Label();
        public Label plAssiette = new Label();
        public Label plVerre= new Label();
        public Label plCouvert = new Label();
        public Label plCasserole = new Label();
        public Label plCouteau = new Label();
        public Label plPoele= new Label();

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

            ccLabel.Text = "Le chef de cuisine est en train de : Attendre";
            ccLabel.AutoSize = true;
            ccLabel.Location = new Point(20, 20);
            chefcuisineBox.Controls.Add(ccLabel);



            GroupBox plongeurBox = new GroupBox();
            plongeurBox.FlatStyle = FlatStyle.Flat;
            plongeurBox.Text = "Vaisselle propre";
            plongeurBox.Size = new Size(285, 285);
            plongeurBox.Location = new Point(305, 10);
            Controls.Add(plongeurBox);

            plAssiette.Text = "Assiettes : 150/150";
            plAssiette.AutoSize = true;
            plAssiette.Location = new Point(10, 25);
            plAssiette.Size = new Size(127, 90);
            plongeurBox.Controls.Add(plAssiette);

            plVerre.Text = "Verres : 150/150";
            plVerre.AutoSize = true;
            plVerre.Location = new Point(147, 25);
            plVerre.Size = new Size(127, 90);
            plongeurBox.Controls.Add(plVerre);

            plCouvert.Text = "Couverts : 600/600";
            plCouvert.AutoSize = true;
            plCouvert.Location = new Point(10, 120);
            plCouvert.Size = new Size(127, 90);
            plongeurBox.Controls.Add(plCouvert);

            plCasserole.Text = "Casseroles : 10/10";
            plCasserole.AutoSize = true;
            plCasserole.Location = new Point(147, 120);
            plCasserole.Size = new Size(127, 90);
            plongeurBox.Controls.Add(plCasserole);

            plPoele.Text = "Poeles : 10/10";
            plPoele.AutoSize = true;
            plPoele.Location = new Point(10, 215);
            plPoele.Size = new Size(127, 90);
            plongeurBox.Controls.Add(plPoele);

            plCouteau.Text = "Couteaux de cuisine : 5/5";
            plCouteau.AutoSize = true;
            plCouteau.Location = new Point(147, 215);
            plCouteau.Size = new Size(127, 90);
            plongeurBox.Controls.Add(plCouteau);



            GroupBox chefpartie1Box = new GroupBox();
            chefpartie1Box.FlatStyle = FlatStyle.Flat;
            chefpartie1Box.Text = "Chef de partie 1";
            chefpartie1Box.Size = new Size(285, 285);
            chefpartie1Box.Location = new Point(10, 305);
            Controls.Add(chefpartie1Box);

            cp1Label.Text = "Le chef de partie 1 est en train de : Attendre";
            cp1Label.AutoSize = true;
            cp1Label.Location = new Point(20, 20);
            chefpartie1Box.Controls.Add(cp1Label);



            GroupBox chefpartie2Box = new GroupBox();
            chefpartie2Box.FlatStyle = FlatStyle.Flat;
            chefpartie2Box.Text = "Chef de partie 2";
            chefpartie2Box.Size = new Size(285, 285);
            chefpartie2Box.Location = new Point(305, 305);
            Controls.Add(chefpartie2Box);

            cp2Label.Text = "Le chef de partie 2 est en train de : Attendre";
            cp2Label.AutoSize = true;
            cp2Label.Location = new Point(20, 20);
            chefpartie2Box.Controls.Add(cp2Label);
        }
    }
}
