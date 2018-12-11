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
    public partial class salle : Form
    {
        public GroupBox tableBox = new GroupBox();
        public Label tableLabel = new Label();
        public Label crLabel = new Label();
        public Label serveurLabel = new Label();
        public Label waitingQueue = new Label();
        public salle()
        {
            InitializeComponent();
            this.Text = "Salle";
            this.Size = new Size(615, 635);
            this.Location = new Point(0, 500);

            tableBox.FlatStyle = FlatStyle.Flat;
            tableBox.Text = "Table N°1";
            tableBox.Size = new Size(285, 285);
            tableBox.Location = new Point(10, 10);
            Controls.Add(tableBox);

            tableLabel.Text = "La table est en train de manger";
            tableLabel.AutoSize = true;
            tableLabel.Location = new Point(20, 20);
            tableBox.Controls.Add(tableLabel);



            GroupBox crBox = new GroupBox();
            crBox.FlatStyle = FlatStyle.Flat;
            crBox.Text = "Chef de rang";
            crBox.Size = new Size(285, 285);
            crBox.Location = new Point(305, 10);
            Controls.Add(crBox);

            crLabel.Text = "Le chef de Rang est : à l'accueil\n\n\nIl est en train de : Attendre";
            crLabel.AutoSize = true;
            crLabel.Location = new Point(20, 20);
            crBox.Controls.Add(crLabel);



            GroupBox serveurBox = new GroupBox();
            serveurBox.FlatStyle = FlatStyle.Flat;
            serveurBox.Text = "Serveur";
            serveurBox.Size = new Size(285, 285);
            serveurBox.Location = new Point(10, 305);
            Controls.Add(serveurBox);

            serveurLabel.Text = "Le serveur est : à l'accueil\n\n\nIl est en train de : Attendre";
            serveurLabel.AutoSize = true;
            serveurLabel.Location = new Point(20, 20);
            serveurBox.Controls.Add(serveurLabel);



            GroupBox mhBox = new GroupBox();
            mhBox.FlatStyle = FlatStyle.Flat;
            mhBox.Text = "Maître d'hôtel";
            mhBox.Size = new Size(285, 285);
            mhBox.Location = new Point(305, 305);
            Controls.Add(mhBox);

            waitingQueue.Text = "Clients en attente d'être placés : 0";
            waitingQueue.Tag = "waitingTitle";
            waitingQueue.AutoSize = true;
            waitingQueue.Location = new Point(20, 20);
            mhBox.Controls.Add(waitingQueue);
        }

        public void clientArrival(String number)
        {
            waitingQueue.Text = "Clients en attente d'être placés : " + number;
        }
    }
}