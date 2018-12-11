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

        /// <summary>
        /// initiate a new client group with the number of persons inside.
        /// </summary>
        public GroupeClients(int nombre=2)
        {
            this.temps = 0;
            this.aTimer = new System.Timers.Timer();
            this.aTimer.Interval = 1000;
            this.aTimer.Elapsed += OnTimedEvent;
            this.aTimer.AutoReset = true;
            this.aTimer.Enabled = false;

            this.nombre = nombre;
            this.commandeTransmise = false;
        }

        /// <summary>
        /// changes the command of the client group regarding the number of remaining recipes
        /// </summary>
        public int changerRecettes(List<Recette> recettesExistantes)
        {
            int recettes_changees = 0;
            for (int i = 0; i < this.commande.recettes.Count; i++)
            {
                if (this.commande.recettes[i].restants==0){
                    this.commande.recettes[i] = this.genererRecette(recettesExistantes);
                    recettes_changees++;
                }
            }
            return recettes_changees;
        }

        public void seFaireServir(Recette recette, Serveur serveur)
        {
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
            this.aTimer.Enabled = false;
            this.temps = 0;
            new Thread(fonctionQuiAttendLeTempsDeManger).Start();
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine(this.temps);
            this.temps++;
        }

        public void fonctionQuiAttendLeTempsDeManger()
        {
            System.Threading.Thread.Sleep(15000);
            this.aTimer.Enabled = true;
        }
        /// <summary>
        /// changes the command of the client group regarding if the chef de cuisine accepted it or not
        /// </summary>
        public bool changerCommande(List<Recette> recettesExistantes)
        {
            bool commande_changee = false;
            for (int i = 0; i < this.commande.recettes.Count; i++)
            {
                if (!(this.commande.recettesValidees.Contains(this.commande.recettes[i])))
                {
                    this.commande.recettes[i] = this.genererRecette(recettesExistantes);
                    commande_changee=true;
                }
            }
            return commande_changee;
        }

        /// <summary>
        /// create a random command, excluding unavailable recipes
        /// </summary>
        public Commande genererCommande(int nombreRecettes,List<Recette> recettesExistantes)
        {
            Commande commande = new Commande(this);
            for (int i = 0; i < nombreRecettes; i++)
            {
                commande.recettes.Add(this.genererRecette(recettesExistantes));
            }
            return commande;
        }

        /// <summary>
        /// generate a random recipe using a list of recipes, excluding unavailable ones.
        /// </summary>
        public Recette genererRecette(List<Recette> recettesExistantes)
        {
            List<Recette> recettesDisponibles = new List<Recette>();
            foreach (Recette r in recettesExistantes)
            {
                if (r.restants>0)
                {
                    recettesDisponibles.Add(r);
                }
            }

            Random random = new Random();
            return recettesDisponibles[random.Next(0, recettesDisponibles.Count - 1)];
        }
    }
}
