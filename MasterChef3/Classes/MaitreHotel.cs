using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class MaitreHotel
    {
        public MaitreHotel()
        {

        }

        public bool donnerOrdreInstallerClients(ChefRang cr, GroupeClients clients)
        {
            if (assignerTable(clients, MainController.tables))
            {
                cr.placerClients(clients);
                return true;
            }
            return false;
        }
        
        public List<GroupeClients> acueillir(GroupeClients clients)
        {
            List<GroupeClients> nouveauxGroupes = new List<GroupeClients>();

            while (clients.nombre > 10)
            {
                GroupeClients nouveauGroupe = new GroupeClients(10);
                nouveauGroupe.accueilli = true;
                nouveauxGroupes.Add(nouveauGroupe);
                clients.nombre -= 10;
            }
            clients.accueilli = true;
            return nouveauxGroupes;
        }
        
        public bool assignerTable(GroupeClients clients, List<Table> tables)
        {
            clients.table = TableMinCapacite(tablesCapacite(clients.nombre, tablesLibres(tables)));
            if (clients.table == null)
            {
                return false;
            }
            return true;
        }
        
        public List<Table> tablesLibres(List<Table> tables)
        {
            List<Table> listeTablesLibres = new List<Table>();
            foreach (Table t in tables)
            {
                if (t.occupee == false)
                {
                    listeTablesLibres.Add(t);
                }
            }
            return listeTablesLibres;
        }
        
        public List<Table> tablesCapacite(int capacite, List<Table> tables)
        {
            List<Table> listeTablesCapacite = new List<Table>();
            foreach (Table t in tables)
            {
                if (t.capacite >= capacite)
                {
                    listeTablesCapacite.Add(t);
                }
            }
            return listeTablesCapacite;
        }
        
        public Table TableMinCapacite(List<Table> tables)
        {
            if (tables.Count == 0)
            {
                return null;
            }
            Table tableChoisie = tables[0];

            for (int i = 1; i < tables.Count; i++)
            {
                if (tables[i].capacite < tableChoisie.capacite)
                {
                    tableChoisie = tables[i];
                }
            }
            return tableChoisie;
        }
    }
}
