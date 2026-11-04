# Architecture — MVP 0.1

## 1. Parcours utilisateur

1. L'utilisateur décrit son projet depuis la diaspora.
2. Le formulaire conversationnel collecte les informations manquantes.
3. Le moteur classe le projet : résidentiel, commercial, industriel ou service énergétique.
4. Le moteur recherche les fiches officielles pertinentes.
5. Il construit une feuille de route avec étapes, documents, administrations, coûts/délais publiés et incertitudes.
6. L'utilisateur vérifie les informations auprès des organismes avant toute dépense ou engagement.

## 2. Questions minimales à collecter

- Pays de résidence et moyen de contact préféré (facultatif).
- Ville/préfecture au Togo où le projet sera réalisé.
- Type de projet : solaire domestique, mini-réseau, installation commerciale/industrielle, raccordement CEET, maintenance/installation ou autre.
- Le porteur agit-il comme particulier ou entreprise ?
- Terrain/local déjà disponible ?
- Puissance estimée ou équipements envisagés, si connus.
- Projet neuf, extension ou régularisation ?

Ne jamais demander de numéro d'identité, mot de passe, coordonnées bancaires ou documents sensibles dans le prototype.

## 3. Architecture logique

Sources officielles
→ collecte et validation humaine
→ catalogue JSON versionné
→ moteur de recherche/règles
→ modèle IA pour expliquer et ordonner
→ parcours utilisateur avec citations et liens.

GitHub héberge le code, les fiches et l'historique. Il ne synchronise pas automatiquement les administrations. Une API, un flux de données autorisé ou une mise à jour manuelle est nécessaire pour actualiser les fiches.

## 4. Modèle de données d'une procédure

- id
- title
- authority
- applies_to
- eligibility
- required_documents
- steps
- fees
- processing_time
- official_url
- verification_status
- last_checked
- notes

Les champs inconnus restent `null` ou `unknown`. Ne pas compléter par supposition.

## 5. Sécurité et responsabilité

- Pas de conseil juridique définitif.
- Pas de garantie d'obtention d'autorisation, de raccordement ou de financement.
- Afficher la source officielle et la date de contrôle.
- Signaler les divergences entre profil utilisateur et conditions de la procédure.
- Demander confirmation à l'administration lorsque les conditions sont ambiguës.
- Ne pas automatiser les paiements ou soumissions administratives dans le MVP.

## 6. Architecture technique progressive

**Prototype :** fichiers JSON + interface web simple + recherche déterministe.

**Étape suivante :** base PostgreSQL/Supabase, authentification facultative, journal des parcours.

**IA :** génération augmentée par recherche (RAG) sur les seules fiches validées. Le modèle ne doit pas inventer les frais, délais ou documents.

**Mises à jour :** validation humaine des changements de pages officielles avant publication.
