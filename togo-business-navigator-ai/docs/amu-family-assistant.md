# AMU Family Assistant — prototype v1

## Objectif
Interface web responsive intégrée à Togo Business Navigator AI pour aider un foyer à :
- préparer une consultation à domicile sans établir de diagnostic ;
- repérer des signes d'alerte nécessitant une aide médicale immédiate ;
- rechercher un prestataire dans les extraits chargés ;
- consulter les actes et produits transcrits ;
- effectuer une estimation arithmétique sur une base de remboursement et un taux confirmés ;
- préparer les questions à poser au prestataire et à la CNSS.

## Fichiers
- `index.html` : interface.
- `styles.css` : présentation responsive.
- `app.js` : filtres, orientation prudente, calculateur.
- `data/amu_tns_seed.json` : données initiales et sources.

## Lancement local
Depuis le dossier `togo-business-navigator-ai/amu-family-assistant/`, lancer un serveur statique, par exemple :
```bash
python -m http.server 8000
```
Puis ouvrir `http://localhost:8000`.

L'application utilise `fetch()` pour charger le JSON : elle doit être servie via HTTP(S), pas ouverte directement en `file://`.

## Publication GitHub Pages
Le dossier peut être publié avec GitHub Pages si le dépôt est configuré pour servir la branche et le répertoire appropriés. Si Pages sert la racine du dépôt, l'URL de ce module sera :
`https://koamimoize.github.io/industrial-engineering-lab/togo-business-navigator-ai/amu-family-assistant/`
Cette URL ne sera active qu'après activation/configuration de GitHub Pages et publication de la branche concernée.

## Périmètre des données v1
Les enregistrements de `amu_tns_seed.json` sont des transcriptions d'extraits fournis par l'utilisateur :
- 20 actes médicaux ;
- 30 prestataires ;
- 20 produits médicaux ;
- une grille partielle de séjours, avec taux affiché de 90 % et tarifs par établissement/période.

Ils ne sont pas le catalogue complet : les pages transmises indiquaient 1 689 actes et 1 912 produits. Le nombre de prestataires présents dans le référentiel complet n'a pas été établi ici.

## Fiabilité et sécurité
- Le statut « remboursable » repris du référentiel n'est pas une garantie de remboursement dans chaque situation.
- La présence d'un établissement dans les extraits ne prouve pas que sa convention est active ni qu'un acte précis y est disponible.
- Le taux de 90 % est limité à la grille de séjour affichée dans les extraits. Le taux de 80 % ne doit être utilisé que lorsqu'il est applicable et confirmé.
- Les tarifs de séjour sont reproduits tels qu'affichés. L'unité exacte et l'application par tranche restent à confirmer dans le simulateur officiel.
- Le calculateur exige que l'utilisateur saisisse une base totale de remboursement connue. Il ne reconstitue pas automatiquement la liquidation CNSS.
- Le moteur d'orientation maison est un ensemble de règles prudentes, pas un modèle médical ni une IA clinique.
- Aucun diagnostic, prescription, classement clinique des établissements ou garantie de remboursement n'est fourni.
- En présence de signes d'urgence, l'utilisateur doit obtenir immédiatement une aide médicale et ne pas attendre l'outil.
- Ne stocke aucune donnée personnelle dans cette version.

## Situation familiale à confirmer
La cotisation TNS annuelle de 102 000 FCFA est affichée dans les informations CNSS consultées par l'utilisateur. L'affiliation du conjoint résidant en Italie comme ayant droit, sans cotisation supplémentaire, n'est pas confirmée. Obtenir une réponse écrite de la CNSS avant paiement.

## Sources officielles
- Portail TNS CNSS : https://tns.cnss.tg/
- Référentiels AMU-TNS : https://tns.cnss.tg/referamu/
- Outils officiels : https://tns.cnss.tg/referamu/outils
- Contact TNS : tns@cnss.tg · 8323

## Évolutions recommandées
1. Importer les référentiels complets via un export/API autorisé ou une collecte validée.
2. Ajouter date de vérification, source par ligne et historique de changement.
3. Vérifier les conventions actives, adresses, contacts et services réellement disponibles.
4. Ajouter les résultats exacts des simulateurs officiels avec leurs hypothèses.
5. Faire valider le parcours clinique et les messages de sécurité par des professionnels de santé au Togo.
6. Ajouter un vrai moteur IA explicatif/RAG uniquement sur des sources validées, avec citations et limites explicites.
7. Ajouter une PWA installable et un mode hors ligne après contrôle de la synchronisation des données.
