using System.ComponentModel.DataAnnotations;

namespace BlackJack.API.Entity;

public class Partie
{
  [Key] public int ID_partie { get; set; }
  public decimal Mise { get; set; }
  public string Resultat { get; set; }
  public int ID_joueur { get; set; }
  public DateTime Date { get; set; }
}

/*
 *
 *Requette pour générer une liste de partit Vérifié que l'id du joueur existe bien en bdd
 * -- Définir la date de début (5 jours avant aujourd'hui)
   SET @date_start = CURDATE() - INTERVAL 5 DAY;
   
   -- Boucle pour insérer des données pour chaque jour des 5 derniers jours
   -- Remarque : Les commandes suivantes doivent être adaptées en fonction des capacités de ton SGBD pour la génération de données.
   -- Ici, on fait des inserts pour chaque jour.
   
   -- 1. Pour le jour 1 (5 jours avant aujourd'hui)
   INSERT INTO `Partie` (`Mise`, `Resultat`, `ID_joueur`, `Date`)
   SELECT
       FLOOR(RAND() * 1000) + 1 AS Mise,
       CASE
           WHEN RAND() < 0.5 THEN 'win'
           ELSE 'Loose'
       END AS Resultat,
       '10' AS ID_joueur,
       @date_start AS Date
   FROM
       (SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1) AS X
   LIMIT 20;
   
   -- 2. Pour le jour 2 (4 jours avant aujourd'hui)
   INSERT INTO `Partie` (`Mise`, `Resultat`, `ID_joueur`, `Date`)
   SELECT
       FLOOR(RAND() * 1000) + 1 AS Mise,
       CASE
           WHEN RAND() < 0.5 THEN 'win'
           ELSE 'Loose'
       END AS Resultat,
       '10' AS ID_joueur,
       DATE_ADD(@date_start, INTERVAL 1 DAY) AS Date
   FROM
       (SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1) AS X
   LIMIT 20;
   
   -- 3. Pour le jour 3 (3 jours avant aujourd'hui)
   INSERT INTO `Partie` (`Mise`, `Resultat`, `ID_joueur`, `Date`)
   SELECT
       FLOOR(RAND() * 1000) + 1 AS Mise,
       CASE
           WHEN RAND() < 0.5 THEN 'win'
           ELSE 'Loose'
       END AS Resultat,
       '10' AS ID_joueur,
       DATE_ADD(@date_start, INTERVAL 2 DAY) AS Date
   FROM
       (SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1) AS X
   LIMIT 20;
   
   -- 4. Pour le jour 4 (2 jours avant aujourd'hui)
   INSERT INTO `Partie` (`Mise`, `Resultat`, `ID_joueur`, `Date`)
   SELECT
       FLOOR(RAND() * 1000) + 1 AS Mise,
       CASE
           WHEN RAND() < 0.5 THEN 'win'
           ELSE 'Loose'
       END AS Resultat,
       '10' AS ID_joueur,
       DATE_ADD(@date_start, INTERVAL 3 DAY) AS Date
   FROM
       (SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1) AS X
   LIMIT 20;
   
   -- 5. Pour le jour 5 (1 jour avant aujourd'hui)
   INSERT INTO `Partie` (`Mise`, `Resultat`, `ID_joueur`, `Date`)
   SELECT
       FLOOR(RAND() * 1000) + 1 AS Mise,
       CASE
           WHEN RAND() < 0.5 THEN 'win'
           ELSE 'Loose'
       END AS Resultat,
       '10' AS ID_joueur,
       DATE_ADD(@date_start, INTERVAL 4 DAY) AS Date
   FROM
       (SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
        UNION ALL SELECT 1 UNION ALL SELECT 1) AS X
   LIMIT 20;
   
 */