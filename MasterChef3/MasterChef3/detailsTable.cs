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
    public partial class detailsTable : Form
    {
        public Label numTable;
        public Label nbClients;
        public Label avencRepas;
        public Label statut;
        public Label commande;

        public detailsTable()
        {
            this.Size = new Size(200, 600);
            this.Text = "Detail Table 1";
            InitializeComponent();

            numTable = new Label();
            numTable.Text = "Table N°1";
            numTable.Location = new Point(50, 50);
            numTable.AutoSize = true;
            this.Controls.Add(numTable);

            nbClients = new Label();
            nbClients.Text = "0 Clients";
            nbClients.Location = new Point(50, 100);
            nbClients.AutoSize = true;
            this.Controls.Add(nbClients);

            avencRepas = new Label();
            avencRepas.Text = "Table Vide";
            avencRepas.Location = new Point(50, 150);
            avencRepas.AutoSize = true;
            this.Controls.Add(avencRepas);

            statut = new Label();
            statut.Text = "En attente";
            statut.Location = new Point(50, 200);
            statut.AutoSize = true;
            this.Controls.Add(statut);

            commande = new Label();
            commande.Text = "Pas de comande";
            commande.Location = new Point(50, 250);
            commande.AutoSize = true;
            this.Controls.Add(commande);
        }
    }
}
