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
        public string etat;
        public string position;

        public Serveur()
        {
            this.etat = "Attendre";
            this.position = "A l'accueil";
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
            if (groupesClients.Count == 0)
            {
                return null;
            }
            return aServir;
        }
        public List<GroupeClients> clientsQuiOntUneTable(List<GroupeClients> lgc)
        {
            List<GroupeClients> result = new List<GroupeClients>();
            foreach(GroupeClients gc in lgc)
            {
                if(gc.table != null)
                {
                    result.Add(gc);
                }
            }
            return result;
        }
        public void faireQuelqueChose()
        {
            this.Debarrasser(MainController.tables);
            List<GroupeClients> lgc = clientsQuiOntUneTable(MainController.clients);
            if (lgc.Count != 0)
            {
                this.Servir(lgc, MainController.comptoir);
            }
        }
        public void amener(GroupeClients aServir)
        {
            if ((this.recettes_portees.Count)> 0)
            {
                foreach(Recette r in this.recettes_portees)
                {
                    aServir.seFaireServir(r, this);
                }
                this.recettes_portees = new List<Recette>();
            }
        }

        public void lancerLaSuite(GroupeClients clients)
        {
            if (clients.commande.recettes.Count == 0)
            {
                clients.payer();
            }
            else
            {
                this.etat = "Dis au cuisine de lancer la suite";
                this.position = "De la table " + clients.table.numero;
                ChefCuisine chefCuisine = MainController.chefCuisine;
                chefCuisine.dispatcherRecettes(clients.commande);
            }
        }

        public void Servir(List<GroupeClients> clients, Comptoir comptoir)
        {
            GroupeClients aServir = clientsAServir(clients);
            if (aServir != null)
            {
                this.etat = "En train de servir";
                this.position = "A la table "+aServir.table.numero;
                foreach (Recette r in comptoir.recettes)
                {
                    if (aServir.commande.recettes.Contains(r))
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
        }

        public void Debarrasser(List<Table> tables)
        {
            foreach(Table t in tables)
            {
                if(t.occupee==false && t.propre == false)
                {
                    this.etat = "En train de débarasser";
                    this.position = "A la table " + t.numero;
                    t.propre = true;
                    t.dressee = false;
                }
            }
        }
    }
}
