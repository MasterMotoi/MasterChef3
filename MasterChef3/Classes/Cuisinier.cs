using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Classes
{
    public class Cuisinier
    {
        public string nom { set; get; }
        public string type { get; set; }
        public List<Recette> recettesAEffectuer;
        public Semaphore prepare;
        public string etat;
        public System.Timers.Timer aTimer;
        public int tempsCuisine;

        public Cuisinier(string type)
        {
            tempsCuisine = 0;
            this.aTimer = new System.Timers.Timer();
            this.aTimer.Interval = 1000;
            this.aTimer.Elapsed += OnTimedEvent;
            this.aTimer.AutoReset = true;
            this.aTimer.Enabled = true;
            this.etat = "ne fait rien";
            this.recettesAEffectuer = new List<Recette>();
            this.type = type;
            this.prepare = new Semaphore(1, 1);
        }

        public void deposerPlat(Comptoir comptoir, Recette recette)
        {
            this.etat = "depose un " + recette.nom + " sur le comptoir";
            comptoir.recettes.Add(recette);
        }

        public void preparerRecette(Recette recette)
        {
            tempsCuisine = 0;
            Thread thread = new Thread(() => {
                this.prepare.WaitOne();
                this.etat = "prepare un " + recette.nom;
                int temps = (recette.tempsPreparation + recette.tempsCuisson + recette.tempsRepos);
                //System.Threading.Thread.Sleep(temps);
                while (tempsCuisine < temps)
                {
                    Console.Write("");
                }
                this.deposerPlat(MainController.comptoir, recette);
                this.prepare.Release();
                this.etat = "ne fait rien";
            });
            thread.Start();
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            this.tempsCuisine++;
        }

    }
}
