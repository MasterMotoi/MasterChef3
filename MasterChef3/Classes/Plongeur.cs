using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Classes
{
    public class Plongeur
    {
        public System.Timers.Timer aTimer;
        public int placeAssiettes;
        public int placeCouverts;
        public int placeVerres;
        public Semaphore occupe;
        public Semaphore listeMaterielLavable;

        public Plongeur()
        {
            this.placeAssiettes = 24;
            this.placeCouverts = 24;
            this.placeVerres = 24;

            this.occupe = new Semaphore(1, 1);
            this.listeMaterielLavable = new Semaphore(1, 1);

            this.aTimer = new System.Timers.Timer();
            this.aTimer.Interval = 7000;
            this.aTimer.Elapsed += OnTimedEvent;
            this.aTimer.AutoReset = true;
        }

        public void laverToutMain()
        {
            List<MaterielLavable> materielLavable = MainController.materielLavable;
            this.listeMaterielLavable.WaitOne();
            foreach(MaterielLavable ml in materielLavable)
            {
                if (ml.propre == false)
                {
                    if(ml.nom!="assiette" && ml.nom!="couvert" && ml.nom != "verre")
                    {
                        Thread thread = new Thread(() => laverMain(ml));
                        thread.Start();
                    }
                }
            }
            this.listeMaterielLavable.Release();
        }
        public void laverMain(MaterielLavable ml)
        {
            this.occupe.WaitOne();
            System.Threading.Thread.Sleep(750);
            ml.propre = true;
            this.occupe.Release();
        }

        public void laveVaisselle()
        {
            List<MaterielLavable> materielLavable = MainController.materielLavable;

            this.listeMaterielLavable.WaitOne();
            foreach (MaterielLavable ml in materielLavable)
            {
                if (ml.propre == false)
                {
                    if(ml.nom=="couvert" && this.placeCouverts > 0)
                    {
                        ml.propre = true;
                        this.placeCouverts -= 1;
                    }
                    else if (ml.nom == "assiette" && this.placeAssiettes > 0)
                    {
                        ml.propre = true;
                        this.placeAssiettes -= 1;
                    }
                    else if (ml.nom == "verre" && this.placeVerres > 0)
                    {
                        ml.propre = true;
                        this.placeVerres -= 1;
                    }
                }
            }
            this.listeMaterielLavable.Release();
        }
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            this.laveVaisselle();
        }
    }
}
