/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
 INSERT INTO Statut (Id, nom) VALUES (1,'Etudiant'); 
 INSERT INTO Statut (Id, nom) VALUES (2, 'Professeur');
 

 INSERT INTO Individus (Id, nom, prenom) VALUES (1,  'martin','bob');
 INSERT INTO Individus (Id, nom, prenom) VALUES (2,  'matin','martin');
 INSERT INTO Individus (Id, nom, prenom) VALUES (3,  'dop','stephane');
  insert into Statut_Individu (Id_individu, Id_statut) VALUES (1, 2);
  insert into Statut_Individu (Id_individu, Id_statut) VALUES (3, 2);
  insert into Statut_Individu (Id_individu, Id_statut) VALUES (2, 1);
  insert into Individus (Id, prenom, nom) Values (4, 'Mathieu', 'Louvet'),
  (5, 'T-Bow', 'Lasou'),
  (6, 'Tristan', 'Hermant'),
  (7, 'Yasmine', 'Kertous'),
  (8, 'Bryan', 'Vigee');

