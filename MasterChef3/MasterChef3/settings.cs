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
        TextBox nbClient = new TextBox();

        public settings()
        {
            InitializeComponent();
            this.Text = "Settings";
            this.Size = new Size(400, 950);
            this.Location = new Point(0,0);

            GroupBox salleBox = new GroupBox();
            salleBox.FlatStyle = FlatStyle.Flat;
            salleBox.Text = "Salle management";
            salleBox.Size = new Size(300, 400);
            salleBox.Location = new Point(50, 50);
            Controls.Add(salleBox);

            Button salleShow = new Button();
            salleShow.Text = "Show";
            salleShow.Tag = "Salle";
            salleShow.Location = new Point(200, 300);
            salleShow.Click += new System.EventHandler(this.roomShow_Click);
            salleBox.Controls.Add(salleShow);

            nbClient.Location = new Point(50, 200);
            salleBox.Controls.Add(nbClient);

            Button addClient = new Button();
            addClient.Text = "Add Client";
            addClient.Location = new Point(200, 200);
            addClient.Click += new System.EventHandler(this.clientAdd);
            salleBox.Controls.Add(addClient);




            GroupBox cuisineBox = new GroupBox();
            cuisineBox.FlatStyle = FlatStyle.Flat;
            cuisineBox.Text = "Cuisine management";
            cuisineBox.Size = new Size(300, 400);
            cuisineBox.Location = new Point(50, 500);
            Controls.Add(cuisineBox);

            Button cuisineShow = new Button();
            cuisineShow.Text = "Show";
            cuisineShow.Tag = "Cuisine";
            cuisineShow.Location = new Point(200, 300);
            cuisineShow.Click += new System.EventHandler(this.roomShow_Click);
            cuisineBox.Controls.Add(cuisineShow);
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
                int clients = int.Parse(nbClient.Text);
                sal.clientArrival(clients);
            }
        }
    }
}
