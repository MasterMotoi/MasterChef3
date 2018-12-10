using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class MaitreHotel
    {
        /// <summary>
        /// gives the order to the chef de rang to bring clients to their table.
        /// </summary>
        public void donnerOrdreInstallerClients(ChefRang cr, GroupeClients clients)
        {
            cr.placerClients(clients);
        }

        /// <summary>
        /// Welcomes groups of clients
        /// </summary>
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

        /// <summary>
        /// assign a table to a group of clients
        /// </summary>
        public void assignerTable(GroupeClients clients, Table[] tables)
        {
            clients.table = TableMinCapacite(tablesCapacite(clients.nombre, tablesLibres(tables)));
        }

        /// <summary>
        /// return the list of free tables in a list of tables
        /// </summary>
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
        /// <summary>
        /// returns a list of tables with a sufficient capacity
        /// </summary>
        public List<Table> tablesCapacite(int capacite, Liste<Table> tables)
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
        /// <summary>
        /// returns the table with the lowest capacity from a list of tables
        /// </summary>
        public Table TableMinCapacite(List<Table> tables)
        {
            Table tableChoisie = tables[0];

            for (int i = 1; i < tables.length; i++)
            {
                if (t.capacite < tableChoisie.capacite)
                {
                    Table tableChoisie = tables[i];
                }
            }
            return tableChoisie;
        }
    }
}
