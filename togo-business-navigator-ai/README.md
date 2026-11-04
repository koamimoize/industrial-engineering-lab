# Togo Business Navigator AI — MVP 0.1

**Energy Edition · Diaspora togolaise**

Assistant d'orientation qui transforme la description d'un projet énergétique au Togo en parcours administratif structuré, sourcé et vérifiable.

## Public cible
Membres de la diaspora togolaise qui souhaitent préparer un projet au Togo depuis l'étranger.

## Périmètre initial
- Projet solaire résidentiel ou hors réseau ;
- Projet énergétique commercial ou industriel ;
- Demande de raccordement électrique ;
- Réclamation/intervention liée à la CEET ;
- Orientation vers les interlocuteurs officiels.

## Modules
- **Energy Navigator** : procédures et services du secteur énergie.
- **AMU Family Assistant** : assistant familial AMU-TNS pour préparer les soins à domicile et à l'hôpital, rechercher des prestataires, consulter les extraits de référentiels et estimer un reste à charge.

### AMU Family Assistant
Dossier : `amu-family-assistant/`

- Interface web responsive : `amu-family-assistant/index.html`
- Données initiales : `amu-family-assistant/data/amu_tns_seed.json`
- Logique d'orientation et calculs : `amu-family-assistant/app.js`
- Documentation : `docs/amu-family-assistant.md`

Pour le lancement, lire `docs/amu-family-assistant.md`. Le prototype doit être servi en HTTP(S), par exemple avec `python -m http.server 8000` depuis le dossier de l'application.

## Fiabilité et limites
Le MVP **n'effectue aucune démarche à la place de l'utilisateur** et ne garantit ni autorisation, ni financement, ni remboursement. Les données AMU sont des extraits fournis par l'utilisateur, pas les catalogues complets de la CNSS. La présence d'un prestataire dans les extraits ne confirme pas sa convention active. Le module santé ne pose pas de diagnostic et ne remplace pas un professionnel de santé.

Chaque réponse doit distinguer :
- obligation ou information confirmée par une source ;
- démarche potentiellement nécessaire ;
- question à poser à l'administration ;
- estimation illustrative et ses hypothèses.

Les liens sont des références. Ils ne constituent pas une intégration technique avec les administrations.

## Démarrage
Lire `docs/architecture.md`, puis `data/energy_services.json`, `prompts/assistant_system_prompt.md` et `docs/amu-family-assistant.md`.

### Togo–Japan Network (Industrial OS)
Dossier: `data/japan_togo_mission_2026.json`
Documentation: `docs/togo-japan-network.md`

- 12 Japanese organizations and 75 Togolese organization entries transcribed from the API-ZF networking sheet dated 17 July 2026.
- Includes stated interests, proposed networking links, sectors and published contact details where supplied.
- The source is a networking schedule, not proof of meetings, contracts or partnerships. Contact details and company status require verification.
