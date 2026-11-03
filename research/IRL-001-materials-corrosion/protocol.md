# IRL-001 — Experimental Protocol (Version 0.1)

**Status:** Draft protocol; validate material suitability before starting.  
**Study duration:** 14 days after baseline.  
**Replicates:** 3 specimens per group (15 total).

## 1. Objective
Compare the visible development of corrosion on nominally uncoated carbon-steel nails under five defined exposure setups. Assess whether standardized smartphone images can provide a repeatable estimate of visible rust-covered area.

## 2. Research question and hypotheses
**Question:** How do the selected moisture and saline-exposure setups influence visible corrosion development over 14 days?

- H1 (exploratory): wet/dry cycling and continuous wet exposure may produce different visible corrosion patterns.
- H2 (exploratory): saline-water exposure may produce more visible corrosion than freshwater exposure under otherwise similar setups.
- H3 (exploratory): the photographic workflow may allow consistent documentation of visible surface changes.

These are hypotheses to test, not established conclusions.

## 3. Materials
- 15 nails from the same package/batch, nominally uncoated and not galvanized.
- Five clean, clearly labelled containers or compartments.
- Clean water and table salt (sodium chloride).
- Identical inert supports (for example, clean plastic lids or non-reactive holders).
- Measuring cup/syringe for repeatable liquid volumes.
- Smartphone camera, fixed background, ruler or scale marker, and consistent lighting.
- Gloves and eye protection.
- Optional thermometer/hygrometer. Use only if available and record actual readings.
- ImageJ/Fiji software for image analysis.

Do not use acids, bleach, chemical rust removers, improvised electrical circuits, or a homemade salt-spray chamber.

## 4. Specimen selection and preparation
1. Use nails from one package and record the package description and purchase details.
2. Check visually for zinc/galvanized coating, paint, oil, or other surface treatment. If uncertain, record uncertainty; do not claim the nails are confirmed carbon steel.
3. Reject visibly damaged or obviously different specimens and document the reason.
4. Assign IDs N01–N15. Do not polish or chemically clean the nails.
5. Photograph each specimen at baseline using the image procedure below.
6. Randomly allocate three nails to each group where practical. Record the allocation.

Because nails are not standardized coupons, describe the material as **nominally uncoated steel nails** unless composition is independently verified.

## 5. Exposure groups

| Group | Setup | Replicates |
|---|---|---:|
| A — Ambient control | Stored dry, without deliberately added water | 3 |
| B — Freshwater cycles | Repeated wet/dry cycle: 8 h wet, 16 h dry | 3 |
| C — Saltwater cycles | Same wet/dry schedule as B, using saline water | 3 |
| D — Freshwater continuous | Kept continuously wet with freshwater | 3 |
| E — Saltwater continuous | Kept continuously wet with saline water | 3 |

### Solution preparation
For a controlled concentration, weigh salt and water using a suitable scale. A 3.5% w/v solution means 3.5 g sodium chloride brought to a final solution volume of 100 mL. If no scale or suitable measuring equipment is available, use a repeatable measured recipe and explicitly label the concentration **approximate/unknown**. Do not report it as 3.5%.

Use the same solution volume per specimen where applicable. Record actual volumes and any replenishment.

### Exposure setup notes
- Keep containers labelled and separated to avoid mix-ups.
- Use identical supports and container geometry as far as possible.
- For wet/dry groups, apply a measured volume for 8 hours, then allow 16 hours of drying. Repeat consistently.
- For continuous-wet groups, maintain a documented wet condition and record any evaporation or replenishment.
- Keep all groups in the same general room, away from food, children, pets, and electronics.
- Record room conditions only when measured.

The continuous-wet and wet/dry arrangements may differ in oxygen transport and liquid contact as well as moisture duration. This is a limitation of the exploratory setup.

## 6. Photography procedure
At baseline (Day 0), then on Days 1, 3, 5, 7, 10, and 14 if practical:
1. Photograph each nail separately, using the same phone and camera settings where possible.
2. Use the same distance, angle, background, lighting, and orientation.
3. Include a scale marker in the same plane as the nail.
4. Avoid filters, automatic enhancement, and edits to original files.
5. Save original images with filenames such as N01_D00_YYYY-MM-DD.jpg.
6. Keep original files in a raw folder; store cropped or analyzed copies separately.
7. Record the actual observation time and any deviations.

## 7. Image analysis
Use ImageJ/Fiji to estimate the visible rust-covered area on the photographed visible surface.

For each image:
- Define the visible nail region consistently.
- Apply the same documented color/threshold method across all images.
- Manually inspect the mask and correct obvious segmentation errors using a consistent rule.
- Save the processed image and analysis settings.
- If a reliable separation between rust and background cannot be made, mark the result as not measurable rather than forcing a value.

**Visible rust area (%) = (estimated rust-covered pixels / total visible specimen pixels) × 100**

This is an image-based surface indicator only. It does not measure metal loss, penetration depth, or an engineering corrosion rate.

## 8. Data recording
Use data-template.csv. Record specimen ID and group; observation date/time; actual temperature and relative humidity only if measured; liquid type and volume; visible rust-area estimate if measurable; image filename; observations and protocol deviations.

Do not replace missing measurements with estimates. Use NA and explain why.

## 9. Analysis plan
- Plot each specimen's visible rust-area estimate against elapsed time.
- Summarize each group using individual trajectories and descriptive statistics (for example, median and range).
- Show all three replicate values; do not hide outliers.
- Avoid claims of statistical significance with this small exploratory sample.
- Discuss confounding factors, material uncertainty, lighting/segmentation uncertainty, and exposure differences.

## 10. Safety and disposal
Wear gloves and eye protection when handling wet or rusty specimens. Avoid touching eyes or mouth; wash hands after handling. Keep liquids away from electrical devices. Do not consume the solutions or use the containers for food. Dispose of small quantities of saltwater according to local household guidance; do not pour concentrated solutions onto plants or soil. Seek local guidance if any unusual coating or chemical contamination is suspected.

## 11. Stop conditions
Stop and reassess if containers leak, specimens have an unknown chemical coating, unexpected reactions occur, or safe separation/storage cannot be maintained.

## 12. Reporting
The final report must separate literature-based background; actual methods performed; actual observations and measurements; limitations and uncertainties; and future design ideas.

Do not write results or conclusions before collecting and analyzing the data.
