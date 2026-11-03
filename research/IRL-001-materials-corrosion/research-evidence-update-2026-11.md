# IRL-001 — Evidence Update and Method Decision
**Date:** 2026-11-03  
**Status:** Desk-research update; no physical experiment has been performed.

## Executive decision

Keep the project focused on **low-cost, repeatable image-based corrosion documentation**. Do not claim a new corrosion sensor, validated corrosion rate, or industrial inspection tool at this stage.

The strongest route is a two-stage project:
1. A small, controlled feasibility study using identical steel specimens and a fixed smartphone imaging setup.
2. A design concept for a low-cost image-capture and record-keeping station, with a clear pathway to later validation against laboratory measurements.

## Evidence found

### 1. Smartphone image measurements have been studied
Igoe and Parisi (2016), *Characterization of the corrosion of iron using a smartphone camera*, investigated smartphone image-sensor responses to iron corrosion. The published abstract reports congruent validation tests and errors below 5% in their experimental setup. This is encouraging evidence that smartphone imaging can be useful, but it does **not** mean our phone, lighting, samples, or proposed workflow will achieve the same accuracy.

Reference: https://doi.org/10.1080/10739149.2015.1082484

### 2. Image processing can screen visible corrosion
A 2020 open-access study, *Detection of corrosion on steel structures using automated image processing*, used color analysis in HSV space and texture/roughness analysis to identify corroded regions in photographs. It highlights the importance of illumination and image quality. Its method and dataset are not automatically transferable to our small nail experiment.

Reference: https://doi.org/10.1016/j.dibe.2020.100022

### 3. Field-scale image segmentation is advancing
Savino et al. (2025) described corrosion-area segmentation on steel transmission towers using 999 field photographs and a DeepLabv3+ approach. Their abstract reports validation accuracy of 90.8%; the work also emphasizes spatial reference and photogrammetry for metric quantification. This is a much more advanced setting than our pilot and should be treated as a future benchmark, not a performance target for IRL-001.

Reference: https://doi.org/10.1111/mice.13434

### 4. Standards distinguish visual appearance from metal loss
ISO 8407:2021 describes procedures for removing corrosion products from metal specimens in order to determine mass loss without significant removal of base metal. The official ISO page confirms the standard and its current status. ASTM G1-25 likewise addresses preparation, cleaning, and evaluation of corrosion specimens, including mass-loss and pitting approaches.

References:
- https://www.iso.org/standard/71866.html
- https://store.astm.org/standards/g1

These standards make an important distinction: **visible rust coverage is not a substitute for validated mass-loss or pitting measurements**. Our first phase must call its output “visible rust-area estimate,” not corrosion rate.

## Method decision — improve the original proposal

### Change 1: Prefer identical flat coupons over ordinary nails
Nails are convenient but have curved surfaces, variable heads and tips, uncertain surface finish, and possible coatings. If feasible within the budget, use identical flat, uncoated low-carbon-steel coupons from one supplier and one batch, with documented dimensions and material description.

If suitable coupons cannot be obtained affordably, use same-package nails only as a preliminary demonstration and clearly label the study exploratory. Do not claim standardized material or industrial validity.

### Change 2: Make photography reproducible
Build a simple fixed phone stand and enclosed/hooded imaging area from reused cardboard or other safe materials. Use:
- one smartphone and fixed camera settings;
- fixed camera-to-sample distance and angle;
- diffuse, constant lighting;
- matte neutral background;
- a scale marker and a color reference in each image;
- fixed specimen orientation and ID;
- unedited original images.

The color reference helps detect lighting/white-balance drift. It does not by itself calibrate the entire measurement system.

### Change 3: Separate two questions
**Question A — material response:** Do the different exposure setups produce visibly different corrosion patterns?

**Question B — measurement repeatability:** Can the same imaging and segmentation procedure produce consistent visible-area estimates when repeated?

Do not combine these into one broad claim. First demonstrate repeatable image capture and analysis.

### Change 4: Use a smaller, clearer first experiment if resources are tight
A 5-group × 3-replicate design is possible but adds handling complexity. A more manageable feasibility design is 3 groups × 3 replicates:
- ambient/dry reference;
- freshwater wet/dry cycle;
- saline-water wet/dry cycle.

This focuses the initial comparison on saline exposure under a common cycling schedule. Continuous immersion can be a second experiment. If the full five-group design is retained, keep the original plan and document the exposure differences.

### Change 5: Do not attempt chemical cleaning or mass-loss calculations at home
Accurate mass-loss work requires suitable specimen preparation, cleaning procedures, and sufficiently precise weighing. ISO 8407 and ASTM G1 describe controlled approaches. Do not improvise acid cleaning or present a cheap kitchen scale as an adequate substitute.

## Proposed measurable outputs

1. Complete image archive with baseline and follow-up photographs.
2. A documented image-capture protocol.
3. A segmentation workflow and saved settings.
4. Visible rust-area estimates with specimen-level time series.
5. Repeatability check: independently repeat image capture/analysis on a subset and report the observed variation.
6. A limitations register and a next-phase validation plan.

## Honest conclusion at this stage

The literature supports smartphone imaging and image processing as promising approaches for corrosion documentation. It does not establish that the proposed IRL-001 workflow is already validated. The contribution of this pilot should be framed as testing the **feasibility and repeatability of a low-cost, standardized image-documentation workflow**, not claiming a new corrosion-monitoring technology.

## Source notes
This document summarizes publicly available abstracts and official standards pages. Full texts and exact experimental details should be checked before making detailed methodological claims. No experimental data were generated for this update.
