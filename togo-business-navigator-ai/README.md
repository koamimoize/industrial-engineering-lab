# Togo Business Navigator AI — MVP 0.1

**Energy Edition · Diaspora togolaise**

Assistant d'orientation qui transforme la description d'un projet énergétique au Togo en parcours administratif structuré, sourcé et vérifiable.

## Public cible
Membres de la diaspora togolaise qui souhaitent préparer un projet énergétique au Togo depuis l'étranger.

## Problème
Les informations administratives sont dispersées. Le porteur de projet doit identifier les administrations, comprendre les conditions, rassembler les documents et ordonner les démarches.

## Promesse du MVP
À partir d'une description simple du projet, proposer :
1. les démarches potentiellement pertinentes ;
2. les conditions et pièces à vérifier ;
3. l'administration compétente et ses coordonnées lorsqu'elles sont publiées ;
4. les liens officiels ;
5. les questions encore nécessaires pour confirmer le parcours.

Le MVP **n'effectue aucune démarche à la place de l'utilisateur** et ne garantit ni autorisation, ni raccordement, ni financement.

## Périmètre initial
- Projet solaire résidentiel ou hors réseau ;
- Projet énergétique commercial ou industriel ;
- Demande de raccordement électrique ;
- Réclamation/intervention liée à la CEET ;
- Orientation vers les interlocuteurs officiels.

## Structure
- `data/` : fiches de services et sources structurées.
- `docs/` : architecture, règles de fiabilité et feuille de route.
- `prompts/` : instructions du moteur IA.
- `examples/` : scénarios de test.

## Statuts de fiabilité
- `verified_from_user_supplied_page` : informations transcrites depuis une page officielle fournie dans le projet ; à recontrôler avant mise en production.
- `needs_verification` : information incomplète ou procédure à confirmer.
- `not_applicable` : procédure non adaptée au profil décrit.

## Principe fondamental
Chaque réponse doit distinguer :
- obligation confirmée par une source ;
- démarche potentiellement nécessaire ;
- question à poser à l'administration.

Les liens sont des références. Ils ne constituent pas une intégration technique avec les administrations.

## Démarrage
Lire `docs/architecture.md`, puis `data/energy_services.json` et `prompts/assistant_system_prompt.md`.
