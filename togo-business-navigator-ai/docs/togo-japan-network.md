# Togo–Japan Network — Industrial OS module

## Purpose
Searchable relationship and opportunity register transcribed from the API-ZF networking sheet for the Japanese business delegation, updated 17 July 2026.

## Dataset
- JSON: `data/japan_togo_mission_2026.json`
- Japanese organizations: 12
- Togolese organization entries: 75
- Source: [API-ZF networking sheet (PDF)](https://backoffice.apizf.org/wp-content/uploads/2026/07/Fiche-de-re%cc%81seautage_Mission-JETRO-17_07_26.pdf)
- Provenance: transcription supplied by the user.

## Industrial OS module
- Module ID: `togo-japan-network`
- Label: Togo–Japan Network
- Filters: sector, Japanese organization, verification status.
- Workflows: sector mapping, partner discovery, industrial needs qualification, outreach tracking.

## Interpretation and quality rules
1. The source is a networking schedule, not a list of signed agreements.
2. A Togolese company listed under a Japanese delegation member was proposed for networking; this does not prove a meeting, partnership, contract or investment.
3. Contact details are transcribed from the supplied text and must be verified before outreach.
4. Opportunity ideas are hypotheses to qualify, not confirmed needs or open tenders.
5. Missing data is left empty; do not infer contacts or company capabilities.

## Recommended workflow
1. Filter Togolese organizations by sector (manufacturing, mining, energy, agro-industry, packaging, logistics).
2. Match the organization's declared interest to a relevant Japanese organization.
3. Qualify the real need: equipment, maintenance, production, quality, cold chain, warehouse or logistics.
4. Record outreach date, outcome, evidence URL, next action and owner in a CRM layer.
5. Promote only qualified, evidenced leads into the active opportunity pipeline.

## Next improvements
- Verify company legal names, contacts, websites and current operating status.
- Add location, industrial capabilities and equipment profiles.
- Add CRM fields: lead status, last contacted date, next action, evidence URL and owner.
- Connect the dataset to the live dashboard navigation and cards after identifying the dashboard source folder.
