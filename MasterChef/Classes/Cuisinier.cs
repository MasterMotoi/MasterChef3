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

        public Cuisinier(string type)
        {
            this.type = type;
            this.prepare = new Semaphore(1, 1);
        }

        public void deposerPlat(Comptoir comptoir, Recette recette)
        {
            comptoir.recettes.Add(recette);
        }

        public void preparerRecette(Recette recette)
        {
            int temps = (recette.tempsPreparation + recette.tempsCuisson + recette.tempsRepos)*1000;

            Thread thread = new Thread(() => {
                this.prepare.WaitOne();
                System.Threading.Thread.Sleep(temps);
                this.prepare.Release();
            });
            thread.Start();
        }
        
    }
}
