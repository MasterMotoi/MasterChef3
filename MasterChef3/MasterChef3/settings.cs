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
using System.Threading;

namespace MasterChef3
{
    public partial class settings : Form
    {
        salle sal = new salle();
        cuisine cuis = new cuisine();
        detailsTable tab = new detailsTable();
        NumericUpDown nbClient = new NumericUpDown();
        NumericUpDown numTable = new NumericUpDown();
        public Label elapsedTime = new Label();
        public Label caisseLabel;
        int clientsPlaces;
        int clientsRecales;
        int tempsEcoule;

        public settings()
        {
            this.tempsEcoule = 0;
            MainController.initTime();

            clientsPlaces = clientsRecales = 0;

            InitializeComponent();
            this.Text = "Settings";
            this.Size = new Size(400, 650);
            this.Location = new Point(0,0);

            GroupBox salleBox = new GroupBox();
            salleBox.FlatStyle = FlatStyle.Flat;
            salleBox.Text = "Restaurant management";
            salleBox.Size = new Size(300, 250);
            salleBox.Location = new Point(50, 50);
            Controls.Add(salleBox);

            Button salleShow = new Button();
            salleShow.Text = "Show salle";
            salleShow.Tag = "Salle";
            salleShow.Location = new Point(166, 150);
            salleShow.Size = new Size(100, 25);
            salleShow.Click += new System.EventHandler(this.roomShow_Click);
            salleBox.Controls.Add(salleShow);

            Button cuisineShow = new Button();
            cuisineShow.Text = "Show cuisine";
            cuisineShow.Tag = "Cuisine";
            cuisineShow.Location = new Point(33, 150);
            cuisineShow.Size = new Size(100, 25);
            cuisineShow.Click += new System.EventHandler(this.roomShow_Click);
            salleBox.Controls.Add(cuisineShow);

            nbClient.Location = new Point(50, 100);
            salleBox.Controls.Add(nbClient);

            Button addClient = new Button();
            addClient.Text = "Add Client";
            addClient.Location = new Point(200, 100);
            addClient.Click += new System.EventHandler(this.clientAdd);
            salleBox.Controls.Add(addClient);

            numTable.Location = new Point(50, 50);
            salleBox.Controls.Add(numTable);

            Button tableDetails = new Button();
            tableDetails.Text = "Details";
            tableDetails.Location = new Point(200, 50);
            tableDetails.Click += new System.EventHandler(this.getTableDetail);
            salleBox.Controls.Add(tableDetails);

            caisseLabel = new Label();
            caisseLabel.Text = "Argent en caisse : 0";
            caisseLabel.AutoSize = true;
            caisseLabel.Location = new Point(50, 200);
            salleBox.Controls.Add(caisseLabel);




            GroupBox cuisineBox = new GroupBox();
            cuisineBox.FlatStyle = FlatStyle.Flat;
            cuisineBox.Text = "Other Control";
            cuisineBox.Size = new Size(300, 200);
            cuisineBox.Location = new Point(50, 350);
            Controls.Add(cuisineBox);

            Button pause = new Button();
            pause.Text = "Pause";
            pause.Location = new Point(50, 100);
            pause.Click += new System.EventHandler(this.timeManagement);
            cuisineBox.Controls.Add(pause);

            Button start = new Button();
            start.Text = "Start";
            start.Location = new Point(150, 100);
            start.Click += new System.EventHandler(this.timeManagement);
            cuisineBox.Controls.Add(start);

            Button fastForward = new Button();
            fastForward.Text = "Fast";
            fastForward.Location = new Point(150, 50);
            fastForward.Click += new System.EventHandler(this.timeManagement);
            cuisineBox.Controls.Add(fastForward);

            Button slowForward = new Button();
            slowForward.Text = "Slow";
            slowForward.Location = new Point(50, 50);
            slowForward.Click += new System.EventHandler(this.timeManagement);
            cuisineBox.Controls.Add(slowForward);

            majTime(this.tempsEcoule);
            elapsedTime.Location = new Point(50, 150);
            elapsedTime.AutoSize = true;
            cuisineBox.Controls.Add(elapsedTime);
        }

        private void majTime(int temps)
        {
            elapsedTime.Text=(temps+" secondes écoulées depuis le début du service");
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

        public void getTableDetail (Object sender, EventArgs e)
        {
            List<string> details = MainController.getTableDetails(int.Parse(numTable.Text));
            tab.Show();
            tab.Text = "Details Table " + numTable.Text;
            tab.numTable.Text = "Table N°" + numTable.Text;

            if (details != null)
            {
                tab.nbClients.Text = details[0];
                tab.statut.Text = details[1];
                tab.commande.Text = "Détail de la commande : \n\n";
                for (int i = 2; i < details.Count; i++)
                {
                    tab.commande.Text += details[i]+"\n";
                }
            }
        }
        public void majDetailsTable()
        {
            List<string> details = MainController.getTableDetails(int.Parse(numTable.Text));
            tab.Text = "Details Table " + numTable.Text;
            tab.numTable.Text = "Table N°" + numTable.Text;

            if (details != null)
            {
                tab.nbClients.Text = details[0];
                tab.statut.Text = details[1];
                tab.commande.Text = "Détail de la commande : \n\n";
                for (int i = 2; i < details.Count; i++)
                {
                    tab.commande.Text += details[i] + "\n";
                }
            }
            else
            {
                tab.nbClients.Text = "Inoccupée";
                tab.statut.Text = "En attente";
                tab.commande.Text = "Pas de comande";
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

        public void timeManagement (Object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            switch (clicked.Text)
            {
                case "Pause":
                    MainController.arreterTimers();
                    this.refreshTimer.Enabled = false;
                    break;

                case "Start":
                    MainController.reprendreTimers();
                    this.refreshTimer.Enabled = true; 
                    break;

                case "Fast":
                    MainController.fastForward();
                    this.refreshTimer.Interval /= 10;
                    break;

                case "Slow":
                    MainController.slowMo();
                    this.refreshTimer.Interval *= 10;
                    break;
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

        public void caisseState(int nombre)
        {
            caisseLabel.Text = "Argent en caisse : " + nombre;
        }

        public void tableState ()
        {
            int tableEtat = MainController.tableTimer(int.Parse(this.numTable.Text));
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

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            tableState();
            crState(MainController.getPositionCr(0), MainController.getPositionCr(666));
            serveurState(MainController.getPositionServeur(0), MainController.getPositionServeur(666));
            this.tempsEcoule++;
            majTime(this.tempsEcoule);
            ccState(MainController.getCcState());
            cp1State(MainController.getCpState(0));
            cp2State(MainController.getCpState(1));
            majDetailsTable();
            caisseState(MainController.gratterLaYoutubeMoney());
        }
    }
}