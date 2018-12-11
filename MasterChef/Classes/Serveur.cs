using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Serveur
    {
        public List<Recette> recettes_portees;

        public Serveur()
        {
            this.recettes_portees = new List<Recette>();
        }

        public GroupeClients clientsAServir(List<GroupeClients> groupesClients)
        {
            int tempsMax = 0;
            GroupeClients aServir = new GroupeClients();
            foreach(GroupeClients gc in groupesClients)
            {
                if (gc.temps > tempsMax)
                {
                    tempsMax = gc.temps;
                    aServir = gc;
                }
            }
            return aServir;
        }

        public void amener(GroupeClients aServir)
        {
            if ((this.recettes_portees.Count)> 0)
            {
                foreach(Recette r in this.recettes_portees)
                {
                    aServir.seFaireServir(r, this);
                }
            }
        }

        public void lancerLaSuite(GroupeClients clients)
        {
            ChefCuisine chefCuisine = Donnees.chefcuisine;
            chefCuisine.dispatcherRecettes(clients.commande);
        }

        public void Servir(List<GroupeClients> clients, Comptoir comptoir)
        {
            GroupeClients aServir = clientsAServir(clients);
            foreach(Recette r in comptoir.recettes)
            {
                if(aServir.commande.recettes.Contains(r))
                {
                    if (this.recettes_portees.Count < 5)
                    {
                        this.recettes_portees.Add(r);
                    }
                    else
                    {
                        this.amener(aServir);
                        break;
                    }
                }
            }
        }

        public void Debarrasser(List<Table> tables)
        {
            foreach(Table t in tables)
            {
                if(t.occupee==false && t.propre == false)
                {
                    t.propre = true;
                    t.dressee = false;
                }
            }
        }
    }
}
