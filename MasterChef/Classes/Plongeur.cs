using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Plongeur
    {
        public System.Timers.Timer aTimer;
        public int placeAssietes;
        public int placeCouverts;
        public int placeVerres;
        public Plongeur()
        {
            this.placeAssietes = 24;
            this.placeCouverts = 24;
            this.placeVerres = 24;

            this.aTimer = new System.Timers.Timer();
            this.aTimer.Interval = 1000;
            this.aTimer.Elapsed += OnTimedEvent;
            this.aTimer.AutoReset = true;
        }
        public void laver()
        {
            List<MaterielLavable> materielLavable = Donnees.materielLavable;
            //attendre 7 minutes
            foreach (MaterielLavable ml in materielLavable)
            {
                if (ml.propre == false)
                {
                    if(ml.nom=="couvert" && this.placeCouverts > 0)
                    {
                        ml.propre = true;
                    }
                }
                ml.propre = true;
            }
        }
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            this.laver();
        }
    }
}
