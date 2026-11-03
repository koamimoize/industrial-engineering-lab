# BDA 2026 — Concept Brief
## RustTrace: Low-Cost Corrosion Imaging and Monitoring Station

**Project status:** Early-stage design concept. Not built, tested, or validated.  
**Linked research:** IRL-001 — Low-Cost Materials Degradation Research  
**Proposed positioning:** Accessible industrial inspection support for small workshops, maintenance teams, training centers, and educational laboratories.

## 1. The problem

Small workshops and maintenance teams may rely on visual inspection notes and inconsistent phone photographs to document corrosion. Images taken under different lighting, angles, distances, and camera settings are difficult to compare over time. A low-cost, repeatable image-capture workflow could improve documentation and help prioritize follow-up inspection.

This concept does not claim to replace qualified inspectors, non-destructive testing, or standards-based corrosion assessment.

## 2. Proposed solution

RustTrace is a compact imaging station that helps a user capture comparable photographs of a metal surface and maintain a traceable inspection record.

### Core modules
1. **Capture enclosure:** small hood or foldable enclosure to reduce ambient-light variation.
2. **Fixed phone mount:** repeatable camera distance and angle using a user's smartphone.
3. **Diffuse lighting:** low-voltage LED lighting with repeatable positioning.
4. **Reference card:** scale marker and color reference included in every image.
5. **Sample/asset identifier:** QR code or printed ID linked to an inspection record.
6. **Digital record:** date, location/asset ID, environment notes, image, visible-area estimate, operator notes, and follow-up status.
7. **Analysis layer:** initially transparent image thresholding/segmentation with manual review; machine learning only after a properly labelled and validated dataset exists.

## 3. User workflow

1. Identify the component or test coupon.
2. Place it in the marked imaging position.
3. Capture an image using the fixed setup.
4. Review the image-quality check (focus, lighting, reference card visible).
5. Compare with previous images.
6. Save the record and flag changes for human review.

## 4. What is novel in the proposed design?

The novelty is **not** the claim that smartphone corrosion imaging has never been done. Prior research already exists. The design opportunity is to integrate repeatable low-cost image capture, a visible calibration reference, traceable records, and a simple operator workflow into a compact station aimed at resource-constrained maintenance settings.

This differentiation must be tested against existing products and prior art before any novelty claim is made.

## 5. Target users and context

- Small manufacturing and repair workshops.
- Agricultural processing equipment maintainers.
- Technical schools and vocational training centers.
- Small infrastructure operators.
- Educational laboratories and student research groups.

Potential relevance to Togo and other resource-constrained environments should be validated through interviews; it is not assumed as proven market demand.

## 6. Design requirements

| Requirement | Initial target |
|---|---|
| Cost | Low-cost, repairable, locally replaceable components |
| Portability | Compact, foldable or tabletop |
| Capture consistency | Fixed distance, angle, and lighting |
| Traceability | Unique asset/sample ID and timestamp |
| Transparency | User can inspect image and segmentation overlay |
| Connectivity | Offline-first; export records when internet is available |
| Maintainability | Replaceable LEDs, mount, and simple enclosure |
| Safety | Low-voltage lighting; no chemical handling required |

## 7. Prototype plan

**Prototype 0 — Digital mock-up:** drawings, dimensions, exploded view, workflow, bill of materials.

**Prototype 1 — Basic physical rig:** cardboard/wood/3D-printed enclosure, phone holder, diffuse LED source, printed scale/color reference.

**Prototype 2 — Software demonstrator:** upload image, define sample region, estimate visible rust-area percentage, save image and metadata, display comparison over time.

A smartphone is used as the camera and computing interface in the first version. A dedicated camera, environmental sensors, and embedded electronics are optional later modules, not required for the first proof of concept.

## 8. Validation plan

- Repeat photographs of the same specimen without changing the setup.
- Quantify variation in the image-derived rust-area estimate.
- Repeat the process under intentionally changed lighting to test robustness.
- Compare manual labels from two reviewers on a small image set.
- If possible, compare image estimates with a qualified laboratory reference method in a later phase.

No accuracy percentage should be advertised until these tests are completed.

## 9. Risks and mitigations

- **Lighting drift:** fixed enclosure, diffuse light, reference card, quality checks.
- **Surface geometry:** begin with flat coupons; treat complex shapes as a later challenge.
- **False segmentation:** manual review and clear uncertainty display.
- **Overclaiming:** label output as visible corrosion-area estimate, not corrosion rate.
- **Connectivity:** offline-first local records and export.
- **Adoption uncertainty:** interview maintenance technicians and workshop owners before finalizing the design.

## 10. BDA submission work still required

- Verify the correct category and student eligibility in the official 2026 guide.
- Search prior art and competing inspection products.
- Prepare concept drawings and a clear industrial use case.
- Build a demonstrator if required by the competition's evaluation stage.
- Produce a short video showing the user workflow.
- Confirm exact required files, prototype delivery, deadlines, and rights/ownership terms.

## 11. Honest status statement

As of 3 November 2026, RustTrace is a concept proposal supported by a literature-informed research direction. No physical prototype, user validation, or corrosion measurement performance has yet been demonstrated.
