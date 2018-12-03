# MasterChef3
## Simplification du sujet

### Lieux

Le restaurant comporte 2 pièces : la salle et la cuisine

la salle est composée de 2 carrés et de deux rangs par carrés. Pour la disposition des tables voir la artie _matériel_ 

dans la cuisine il y a : 

* les plans de travails
** stockages de denrées :
** congélo
** frigo
** réserve
* la plonge


###Employés

Salle :
* 1 Maître d’hôtel
* 1 chef de rang par carré
* 2 serveurs par carré
* 1 commis de salle

Cuisine :
* 1 Chef de cuisine
* 2 chefs de parties
* 2 commis de cuisine
* 1 plongeur


### Matériel

Matos commun :
* 150 assiettes plates
* 150 assiettes entrées
* 30 assiettes creuses
* 150 assiettes dessert
* fourchettes / couteaux / cuill. soupe / cuill. café (150 de chaque)
* verres à eau / vin / champagne (150 de chaque)
* 50 tasses et assiettes pour café
* 150 serviettes
* 40 nappes

Matos salle :
* 10 tables de 2, 10 de 4, 5 de 6, 5 de 8, 2 de 10
* 150 chaises
* 40 bouteilles d’eau
* 40 corbeilles à pain

Matos cuisine :
* 5 feux de cuisines
* 10 casseroles
* 10 poêles
* 1 four
* 10 cuillères bois
* 1 mixeur
* 5 bols salades
* 2 autocuiseur
* 1 presse-agrumes
* 1 tamis
* 1 entonnoir
* 5 couteaux de cuisine
* 1 frigo de travail (capacité de 10 préparations en cours)
* 1 lave-vaisselle
* 1 machine a laver
* 1 évier pour laver le matériel de cuisine
* ...


### Processus

### Recettes

Voir http://cuisinez.free.fr/recettes.php3

Carte: 
* 10 plats / 10 entrées / 10 desserts
* Gestion stocks : 1 menus différent par jour (entrée, plat, dessert > 50 assiettes) par service et en moyenne 10 assiettes d’autres recettes par service
* Recettes : faites par cuisinier / chefs de partie
* Chef de cuisine : gère la carte (en cas d’épuisement d’un ingrédient, il décide s’il enlève la recette de la carte ou si le chef cuisinier effectue la recette).
* Recette = 1 intitulé + ingrédients pour un nombre de personnes + différentes étapes pour les réaliser + temps préparation + temps cuisson + temps repos.
* CONSEIL : 1 recette = 1 processus découpé en sous-tâches en parallèles ou non. Recettes assignées et effectuées par quelqu’un en cuisine.


### Cahier des charges

#### Fonctionnel

* Diagrammes de cas d’utilisation  
* Diagrammes d’activité de chaque poste de travail.
* Simulation graphique du fonctionnement du restaurant / temps réel. Besoin mode accéléré echelle : 1’ = 1’’ (7’ = 7h de travail → simulation). 
* Visualiser l’état de chaque personne (salariés / clients) et de chaque objet modélisé ainsi que les situations limites + mettre des alertes sur le manque de telle ou telle ressource (presque plus d’assiettes ou plus de verres du tout, …). Pour cela vous devez avoir une fenêtre de contrôle (voir les pages de contrôle des superviseurs comme Nagios ou Centreon). 
* Mode « PAUSE » = stopper tous les processus + analyser la situation en cours. 
* Modélisation/implémentation de plusieurs catégories de clients avec des comportements différents. 
* Modélisation/implémentation de tous les postes décrits dans la partie « Description de postes ».
* Modélisation/implémentation de tout le matériel décrit (et nécessaire pour la réalisation des recettes)
* Préconisations sur le dimensionnement du restaurant et des ressources : les chiffres donnés sont corrects, surdimensionnés ou sous-dimensionnés. Dans ce cas-là, vous devez donner les postes à pourvoir ou à supprimer et le matériel à garder, à supprimer ou à racheter. Egalement, on attend de vous des préconisations sur le processus global de la gestion du restaurant.
* Les temps de chaque tâche, les quantités d’objets ou des postes, le nombre de clients par type, le temps en mode accéléré, … tout doit être paramétrable dans l’application. 


#### Technique

OBLIGATOIRES | BONUS
----------------------
Diagrammes de composants et classes de l’application (ou applications). | Chaque tâche de chaque processus / thread : horodaté dans un log (en BDD ou fichier log unique)
Diagramme(s) de séquences | 2 machines Windows distinctes : cuisine et salle de restauration
Utiliser au moins 1 IPC par type (synchro, échange de données ou les deux). Threads. Utilisation des processus légers. | 2 machines distinctes : cuisine et salle de restauration : une sur Windows avec .NET et l’autre sur Linux en Java.
Pools | Possibilité de sauvegarde une situation déterminée dans un service et de pouvoir la « rejouer » plus tard. Cela peut être très utile en complément du mode PAUSE.
Sockets : échanges salle de restauration / cuisine.
Langage C# .NET
BDD de stocks en SQL Serveur, actualisée avec les livraisons + mise à jour temps-réel en fonction des commandes. 
DP (au moins 5 au choix - observer, strategy, builder, factory, decorator, singleton, …  + MVC). 
Git + TDD pour tous les membres.


### Livrables / Organisation
Sur GIT 
* Dossier « LIVRABLES FINAUX »
* Livrable « Dossier Architecture » → 5/12 à 12h
** Diagrammes UML fonctionnels + techniques
** Description DP utilisés + MVC
** MCD + script SQL (de la création)
* Dossier Final
** Toutes les sources du projet (sur la durée du projet)

Structure code
* Diagrammes composants et classes
* Diagramme de séquence
* Au moins 1 IPC par type
* Pools
* Sockets : échange salle / cuisine
* .NET
* BDD → SQL Server
* Git 
* TDD