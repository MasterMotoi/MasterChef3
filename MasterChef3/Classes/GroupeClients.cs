using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;

namespace Classes
{
    public class GroupeClients
    {
        public System.Timers.Timer aTimer;
        public int nombre { get; set; }
        public Table table { get; set; }
        public bool place { set; get; }
        public bool commandeTransmise { get; set; }
        public Commande commande { get; set; }
        public bool accueilli { set; get; }
        public int temps { set; get; }
        public bool timeractif;
        public string etat;
        public int note;

        /// <summary>
        /// initiate a new client group with the number of persons inside.
        /// </summary>
        public GroupeClients(int nombre=2)
        {
            note = 0;
            this.commande = new Commande(this);
            this.temps = 0;
            this.aTimer = new System.Timers.Timer();
            this.aTimer.Interval = 1000;
            this.aTimer.Elapsed += OnTimedEvent;
            this.aTimer.AutoReset = true;
            this.aTimer.Enabled = false;
            this.timeractif = false;

            this.table = new Table(0, 0);
            this.nombre = nombre;
            this.commandeTransmise = false;
            this.etat = "";
        }

        public void choisirCommande(ChefRang cr)
        {
            etat = "En train de choisir la commande";
            System.Threading.Thread.Sleep(5000);
            etat = "Attendent pour passer commande";
            this.aTimer.Enabled = true;
            this.timeractif = true;
            this.genererCommande(this.nombre, MainController.recettes);
            cr.prendreCommande(this);
            etat = "Ont passé commande";
        }
        /// <summary>
        /// changes the command of the client group regarding the number of remaining recipes
        /// </summary>
        public int changerRecettes(List<Recette> recettesExistantes)
        {
            Random rand = new Random();
            int recettes_changees = 0;
            for (int i = 0; i < this.commande.recettes.Count; i++)
            {
                if (this.commande.recettes[i].restants==0){
                    this.commande.recettes[i] = this.genererRecette(recettesExistantes, rand);
                    recettes_changees++;
                }
            }
            return recettes_changees;
        }

        public void seFaireServir(Recette recette, Serveur serveur)
        {
            etat = "Reçoit la nourriture";
            this.commande.recettes.Remove(recette);
            if(!ilResteDesRecettesDeCeType(recette.type))
            {
                this.manger();
                serveur.lancerLaSuite(this);
            }
        }

        public bool ilResteDesRecettesDeCeType(string type)
        {
            foreach(Recette r in this.commande.recettes)
            {
                if (r.type == type)
                {
                    return true;
                }
            }
            return false;
        }

        public void manger()
        {
            etat = "Mangent";
            this.aTimer.Enabled = false;
            this.timeractif = false;
            this.temps = 0;
            new Thread(fonctionQuiAttendLeTempsDeManger).Start();
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            this.temps++;
        }

        public void fonctionQuiAttendLeTempsDeManger()
        {
            System.Threading.Thread.Sleep(15000);
            this.aTimer.Enabled = true;
            this.timeractif = true;
            etat = "Attendent leur plat suivant";
        }
        /// <summary>
        /// changes the command of the client group regarding if the chef de cuisine accepted it or not
        /// </summary>
        public bool changerCommande(List<Recette> recettesExistantes)
        {
            Random rand = new Random();
            bool commande_changee = false;
            for (int i = 0; i < this.commande.recettes.Count; i++)
            {
                if (!(this.commande.recettesValidees.Contains(this.commande.recettes[i])))
                {
                    this.commande.recettes[i] = this.genererRecette(recettesExistantes, rand);
                    commande_changee=true;
                }
            }
            return commande_changee;
        }

        /// <summary>
        /// create a random command, excluding unavailable recipes
        /// </summary>
        public void genererCommande(int nombreRecettes,List<Recette> recettesExistantes)
        {
            Commande commande = new Commande(this);
            Random r = new Random();
            for (int i = 0; i < nombreRecettes; i++)
            {
                commande.recettes.Add(this.genererRecette(recettesExistantes, r));
                note += commande.recettes[commande.recettes.Count - 1].prix;
            }
            this.commande=commande;

        }
       
        /// <summary>
        /// generate a random recipe using a list of recipes, excluding unavailable ones.
        /// </summary>
        public Recette genererRecette(List<Recette> recettesExistantes, Random rand)
        {
            List<Recette> recettesDisponibles = new List<Recette>();
            foreach (Recette r in recettesExistantes)
            {
                if (r.restants>0)
                {
                    recettesDisponibles.Add(r);
                }
            }
            
            return recettesDisponibles[rand.Next(0, recettesDisponibles.Count - 1)];
        }

        public void payer()
        {
            MainController.caisse =+ note;
            this.table.occupee = false;
            MainController.clients.Remove(this);
        }
    }
}
