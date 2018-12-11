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
        public Label waitingQueue = new Label();

        public salle()
        {
            InitializeComponent();
            this.Text = "Salle";
            this.Size = new Size(615, 635);
            this.Location = new Point(0, 500);

            GroupBox tableBox = new GroupBox();
            tableBox.FlatStyle = FlatStyle.Flat;
            tableBox.Text = "Tables";
            tableBox.Size = new Size(285, 285);
            tableBox.Location = new Point(10, 10);
            Controls.Add(tableBox);



            GroupBox crBox = new GroupBox();
            crBox.FlatStyle = FlatStyle.Flat;
            crBox.Text = "Chef de rang";
            crBox.Size = new Size(285, 285);
            crBox.Location = new Point(305, 10);
            Controls.Add(crBox);



            GroupBox serveurBox = new GroupBox();
            serveurBox.FlatStyle = FlatStyle.Flat;
            serveurBox.Text = "Serveur";
            serveurBox.Size = new Size(285, 285);
            serveurBox.Location = new Point(10, 305);
            Controls.Add(serveurBox);



            GroupBox mhBox = new GroupBox();
            mhBox.FlatStyle = FlatStyle.Flat;
            mhBox.Text = "Maître d'hôtel";
            mhBox.Size = new Size(285, 285);
            mhBox.Location = new Point(305, 305);
            Controls.Add(mhBox);

            Label waitingQueue= new Label();
            waitingQueue.Text = "Aucun clients en attente d'être placés";
            waitingQueue.Tag = "waitingTitle";
            waitingQueue.AutoSize = true;
            waitingQueue.Location = new Point(20, 20);
            mhBox.Controls.Add(waitingQueue);
        }

        public void clientArrival(int number)
        {
            waitingQueue.Text = " clients attendent d'être placés";
        }

        private void refresh_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}