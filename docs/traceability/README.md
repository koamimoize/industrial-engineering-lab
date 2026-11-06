# IEL Traceability Engine v0.1

Prototype statique de rapprochement opérationnel pour le Challenge 002.

## Ouvrir
- GitHub Pages (si activé) : https://koamimoize.github.io/industrial-engineering-lab/traceability/
- Source : [index.html](./index.html)

## Périmètre v0.1
- Registre d'événements synthétiques : réception, transfert, sortie, production, consommation, expédition.
- Détection déterministe des doublons, lots manquants, lots sans réception amont et sorties entraînant un stock négatif.
- Filtres, journal d'anomalies, KPI et export CSV.
- Six tests de validation embarqués.

## Lancer localement
Ouvrir `index.html` dans un navigateur moderne. Aucun serveur, package ou compte n'est requis.

## Limites connues
- Les données sont entièrement fictives : aucune observation d'entreprise réelle.
- Le stock est un solde calculé par SKU et emplacement, sans unité de mesure, emplacement multi-site, inventaire physique ni règles FIFO/FEFO.
- Les opérations de production ne font pas encore de lien formel entre lots d'intrants et lots de produits finis (genealogy / bill of materials).
- Les événements sont supposés triés chronologiquement et ne disposent pas encore d'un mécanisme de correction ou d'annulation.
- Le moteur n'est ni un ERP ni une preuve de conformité.

## Prochaine phase
1. Définir le modèle d'événement avec l'utilisateur opérationnel.
2. Ajouter la généalogie lot entrant → ordre de fabrication → lot sortant.
3. Ajouter les unités, inventaires, retours, rebuts et ajustements autorisés.
4. Importer un échantillon anonymisé et validé par l'entreprise avant toute conclusion.
