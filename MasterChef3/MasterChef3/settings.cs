using Classes;
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
    public partial class settings : Form
    {
        salle sal = new salle();
        cuisine cuis = new cuisine();
        NumericUpDown nbClient = new NumericUpDown();
        NumericUpDown numTable = new NumericUpDown();
        int clientsPlaces;
        int clientsRecales;

        public settings()
        {
            clientsPlaces = clientsRecales = 0;

            InitializeComponent();
            this.Text = "Settings";
            this.Size = new Size(400, 950);
            this.Location = new Point(0,0);

            GroupBox salleBox = new GroupBox();
            salleBox.FlatStyle = FlatStyle.Flat;
            salleBox.Text = "Restaurant management";
            salleBox.Size = new Size(300, 400);
            salleBox.Location = new Point(50, 50);
            Controls.Add(salleBox);

            Button salleShow = new Button();
            salleShow.Text = "Show salle";
            salleShow.Tag = "Salle";
            salleShow.Location = new Point(166, 300);
            salleShow.Size = new Size(100, 25);
            salleShow.Click += new System.EventHandler(this.roomShow_Click);
            salleBox.Controls.Add(salleShow);

            Button cuisineShow = new Button();
            cuisineShow.Text = "Show cuisine";
            cuisineShow.Tag = "Cuisine";
            cuisineShow.Location = new Point(33, 300);
            cuisineShow.Size = new Size(100, 25);
            cuisineShow.Click += new System.EventHandler(this.roomShow_Click);
            salleBox.Controls.Add(cuisineShow);

            nbClient.Location = new Point(50, 200);
            salleBox.Controls.Add(nbClient);

            Button addClient = new Button();
            addClient.Text = "Add Client";
            addClient.Location = new Point(200, 200);
            addClient.Click += new System.EventHandler(this.clientAdd);
            salleBox.Controls.Add(addClient);

            numTable.Location = new Point(50, 100);
            salleBox.Controls.Add(numTable);

            Button tableNumber = new Button();
            tableNumber.Text = "Table nb";
            tableNumber.Location = new Point(200, 100);
            tableNumber.Click += new System.EventHandler(this.tableState);
            salleBox.Controls.Add(tableNumber);




            GroupBox cuisineBox = new GroupBox();
            cuisineBox.FlatStyle = FlatStyle.Flat;
            cuisineBox.Text = "Time Control";
            cuisineBox.Size = new Size(300, 400);
            cuisineBox.Location = new Point(50, 500);
            Controls.Add(cuisineBox);
        }

        private void roomShow_Click (Object sender, EventArgs e)
        {
            Button clicked = (Button) sender;
            switch (clicked.Tag)
            {
                case "Salle":
                    this.sal.Show();
                    break;

                case "Cuisine":
                    this.cuis.Show();
                    break;
            }
        }

        private void clientAdd(Object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nbClient.Text))
            {
                MessageBox.Show("Entrez un nombre de clients");
            }
            else
            {
                int nc = MainController.clientsArrivage(int.Parse(nbClient.Text));
                if (nc < 0)
                {
                    clientsRecales -= nc;
                    sal.recaleLabel.Text = clientsRecales + " clients ont été recalés";
                }
                else
                {
                    clientsPlaces += nc;
                    sal.waitingQueue.Text = clientsPlaces + " clients ont été placés ce soir";
                }
            }
        }

        public void crState(String etat, String position)
        {
            sal.crLabel.Text = "Le chef de Rang est : " + position + "\n\n\nIl est en train de : " + etat;
        }

        public void serveurState(String etat, String position)
        {
            sal.serveurLabel.Text = "Le serveur est : " + position + "\n\n\nIl est en train de : " + etat;
        }

        public void ccState(String etat)
        {
            cuis.ccLabel.Text = "Le chef de Rang est est en train de : " + etat;
        }

        public void cp1State(String etat)
        {
            cuis.cp1Label.Text = "Le serveur est est en train de : " + etat;
        }

        public void cp2State(String etat)
        {
            cuis.cp2Label.Text = "Le chef de partie 2 est en train de : " + etat;
        }

        public void tableState (Object sender, EventArgs e)
        {
            int tableEtat = MainController.tableTimer(int.Parse(this.numTable.Text));
            Console.WriteLine(this.numTable.Text);
            sal.tableBox.Text = "Table N°" + this.numTable.Text;
            
            switch (tableEtat)
            {
                case 0:
                    sal.tableLabel.Text = "La table est en train de manger";
                    break;

                case -1:
                    sal.tableLabel.Text = "La table est innocupée";
                    break;

                default:
                    sal.tableLabel.Text = "La table attends depuis " + tableEtat + " secondes";
                    break;
                
            }
        }
    }
}
