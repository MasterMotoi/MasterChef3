CREATE TABLE boisson(
        id_boisson  Int  Auto_increment  NOT NULL ,
        nom_boisson Varchar (50) NOT NULL ,
        prix_boisson    Decimal NOT NULL
	,CONSTRAINT boisson_PK PRIMARY KEY (id_boisson)
)ENGINE=InnoDB;


CREATE TABLE reservation(
        id_reservation      Int  Auto_increment  NOT NULL ,
        nom_reservation     Varchar (50) NOT NULL ,
        horaire_reservation Datetime NOT NULL ,
        table_reservation   Decimal NOT NULL ,
        id_table            Int NOT NULL
	,CONSTRAINT reservation_PK PRIMARY KEY (id_reservation)
)ENGINE=InnoDB;


CREATE TABLE commande(
        id_commande Int  Auto_increment  NOT NULL ,
        id_table    Int NOT NULL
	,CONSTRAINT commande_PK PRIMARY KEY (id_commande)
)ENGINE=InnoDB;



CREATE TABLE personnel(
        id_personnel     Int  Auto_increment  NOT NULL ,
        nom_personnel    Varchar (50) NOT NULL ,
        prenom_personnel Varchar (50) NOT NULL ,
        metier_personnel Varchar (50) NOT NULL ,
        type_personnel   Varchar (50) NOT NULL
	,CONSTRAINT personnel_PK PRIMARY KEY (id_personnel)
)ENGINE=InnoDB;



CREATE TABLE recette(
        id_recette          Int  Auto_increment  NOT NULL ,
        nom_recette Varchar (50) NOT NULL ,
        prix_recette        Decimal NOT NULL ,
        type_recette        Varchar (50) NOT NULL ,
        preparateur_recette Varchar (50) NOT NULL ,
        quantite_recette    Decimal NOT NULL ,
        stockage_recette    Varchar (50) NOT NULL ,
        temps_preparation   Time NOT NULL ,
        temps_repos         Time NOT NULL ,
        temps_cuisson       Time NOT NULL
	,CONSTRAINT recette_PK PRIMARY KEY (id_recette)
)ENGINE=InnoDB;



CREATE TABLE ingredient(
        id_ingredient       Int  Auto_increment  NOT NULL ,
        nom_ingredient Varchar (50) NOT NULL ,
        stockage_ingredient Varchar (50) NOT NULL ,
        quantite_ingredient Decimal NOT NULL ,
        date_peremption     Datetime NOT NULL
	,CONSTRAINT ingredient_PK PRIMARY KEY (id_ingredient)
)ENGINE=InnoDB;



CREATE TABLE composer(
        id_recette    Int NOT NULL ,
        id_ingredient Int NOT NULL
	,CONSTRAINT composer_PK PRIMARY KEY (id_recette,id_ingredient)
)ENGINE=InnoDB;



CREATE TABLE constituer(
        id_boisson  Int NOT NULL ,
        id_recette  Int NOT NULL ,
        id_commande Int NOT NULL
	,CONSTRAINT constituer_PK PRIMARY KEY (id_boisson,id_recette,id_commande)
)ENGINE=InnoDB;



CREATE TABLE preparer(
        id_recette   Int NOT NULL ,
        id_personnel Int NOT NULL
	,CONSTRAINT preparer_PK PRIMARY KEY (id_recette,id_personnel)
)ENGINE=InnoDB;



CREATE TABLE materiel(
        id_materiel         Int  Auto_increment  NOT NULL ,
        nom_materiel        Varchar (50) NOT NULL ,
        nombre_materiel     Decimal NOT NULL ,
        type_materiel       Varchar (50) NOT NULL ,
        lavable             Bool NOT NULL ,
        id_materiel_lavable Int NOT NULL
	,CONSTRAINT materiel_PK PRIMARY KEY (id_materiel)
)ENGINE=InnoDB;



CREATE TABLE materiel_lavable(
        id_materiel_lavable Int  Auto_increment  NOT NULL ,
        machine             Varchar (50) NOT NULL ,
        propre              Bool NOT NULL ,
        id_materiel         Int NOT NULL ,
        id_personnel        Int NOT NULL
	,CONSTRAINT materiel_lavable_PK PRIMARY KEY (id_materiel_lavable)
)ENGINE=InnoDB;



CREATE TABLE etre(
		id_materiel Int Auto_increment NOT NULL , 
		id_materiel_lavable Int NOT NULL 
	,CONSTRAINT etre_PK PRIMARY KEY (id_materiel,id_materiel_lavable) 
)ENGINE=InnoDB;


CREATE TABLE necessiter( 
		id_recette Int Auto_increment NOT NULL , 
		id_materiel Int NOT NULL 
	,CONSTRAINT necessiter_PK PRIMARY KEY (id_recette,id_materiel) 
)ENGINE=InnoDB;


CREATE TABLE commander( 
		id_commande Int Auto_increment NOT NULL , 
		id_table Int NOT NULL 
	,CONSTRAINT commander_PK PRIMARY KEY (id_commande,id_table) 
)ENGINE=InnoDB;


CREATE TABLE mobiliser( 
		id_table Int Auto_increment NOT NULL , 
		id_reservation Int NOT NULL 
	,CONSTRAINT mobiliser_PK PRIMARY KEY (id_table,id_reservation) 
)ENGINE=InnoDB;


CREATE TABLE tablee(
        id_tablee Int  Auto_increment  NOT NULL ,
        carre_tablee Decimal NOT NULL ,
        rang_tablee Decimal NOT NULL ,
        capacite_tablee Decimal NOT NULL ,
        occupation_tablee Bool NOT NULL ,
        numero_tablee Decimal NOT NULL
        ,CONSTRAINT tablee_PK PRIMARY KEY (id_tablee)
)ENGINE=InnoDB;

