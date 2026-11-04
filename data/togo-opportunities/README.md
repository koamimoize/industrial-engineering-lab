# Togo Industrial Opportunity Database (TIOD)

Base de veille réglementaire et commerciale pour **Industrial Engineering Lab**.

## Objectif
Relier les services administratifs togolais aux secteurs industriels, aux obligations réglementaires et aux besoins potentiels des entreprises. Cette base est un outil de recherche et de qualification commerciale : elle ne remplace ni un avis juridique, ni une autorisation, ni une confirmation écrite de l'administration.

## Périmètre initial
1. Industrie, mines, machines et maintenance
2. Énergie et installations électriques
3. Agro-industrie et qualité
4. Drones, électronique et IoT
5. Entrepreneuriat et investissement
6. Construction et immobilier

## Structure
- `services.csv` : catalogue des procédures et administrations compétentes.
- `opportunities.csv` : hypothèses de besoins clients et services envisageables.
- `schema.sql` : schéma SQLite pour importer et enrichir les données.
- `README.md` : règles de gestion, niveaux de confiance et workflow.

## Sources officielles de départ
- Portail particuliers : https://service-public.gouv.tg/service-online
- Portail professionnels : https://service-public.gouv.tg/service-online-pro
- Services de drones civils (fiche détaillée) : https://service-public.gouv.tg/service/66b16f2177009817c7075599/habitat-transport/services-de-drones-civils
- Données géominières au public (fiche détaillée) : https://service-public.gouv.tg/service/69386796f4c5f0a07b76bd42/education-formation/mise-a-disposition-des-donnees-geominieres-au-public
- Certificat d'urbanisme : https://service-public.gouv.tg/service/6850973ea0b2360e90265b1d/habitat-transport/3fxyd7ju3535
- Permis de construire : https://service-public.gouv.tg/service/62914b0e7c2fb6ce503263e4/urbanisme-transport/obtention-du-permis-de-construire
- Raccordement moyenne tension : https://service-public.gouv.tg/service/693877abf4c5f0a07b7e02a5/urbanisme-transport/demande-de-branchement-ou-de-raccordement-au-reseau-electriq

## Règles de fiabilité
- `source_status=fiche_detaillee_partagee` : contenu de la fiche officielle détaillée fournie dans le travail.
- `source_status=catalogue_officiel` : intitulé repéré dans le catalogue officiel, mais fiche détaillée non encore examinée.
- `source_status=a_verifier` : hypothèse, autorité, compétence ou lien à confirmer.
- Ne jamais inventer les frais, délais, pièces, critères d'éligibilité ou autorisations requises.
- Les URL du catalogue sont des points d'entrée officiels, pas des liens directs vers chaque procédure.
- Une autorisation administrative ne signifie pas qu'Industrial Engineering Lab est habilité à réaliser l'activité réglementée.
- Distinguer systématiquement : (1) procédure administrative, (2) besoin technique du client, (3) prestation que le Lab peut légalement et techniquement proposer.

## Workflow de mise à jour
1. Ouvrir la fiche officielle depuis le portail.
2. Enregistrer l'intitulé exact, l'URL, l'administration fournisseur, les personnes éligibles, les documents, le coût, le délai et la date de vérification.
3. Si la fiche est ambiguë, contacter l'administration et consigner la réponse écrite.
4. Identifier les entreprises qui pourraient être concernées par le besoin technique sous-jacent.
5. Valider la demande client avant de construire une offre.
6. Réviser les fiches réglementaires au moins tous les 90 jours, et avant toute démarche réelle.

## Import rapide dans SQLite
Depuis la racine du dépôt :
```bash
sqlite3 togo-industrial-opportunities.db < data/togo-opportunities/schema.sql
```
Les CSV sont prévus pour un import ultérieur avec `.mode csv` et `.import`.

## Priorités commerciales initiales
- Maintenance et suivi numérique d'équipements agro-industriels.
- Maintenance et fiabilité d'installations solaires et électriques (dans le périmètre des compétences et habilitations).
- Sourcing de pièces et équipements industriels.
- Inspection / documentation technique, en partenariat avec des opérateurs autorisés lorsque requis.
- Pré-diagnostic documentaire de projets industriels et d'investissement, sans se substituer aux professionnels agréés.
