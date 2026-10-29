# Core OS — Adaptation Monitor (V1 design)

## Purpose

Make adaptation observable. The system must show which component or workflow is improving, which preferences it has learned, what evidence supports each claim, and whether changes improve outcomes.

## Current-state warning

The current repository is a .NET console application for machine downtime tracking. It does not yet contain autonomous agents or a running self-improvement loop. This document and the SQLite schema define the first monitoring layer; they do not claim that automatic learning is already running.

## What every run records

Each run should record:
- component/workflow name and version;
- task category and timestamp;
- expected result and observed result;
- whether the result was independently verified;
- whether the user accepted, corrected, or rejected it;
- number of material corrections;
- elapsed time, where measurable;
- evidence reference and notes.

Do not store secrets or unnecessary sensitive content in logs. Prefer short summaries and references.

## How to tell whether a component adapts

Compare the same task categories across versions and time windows. Report:
1. **Preference adherence**: explicit preferences followed / applicable cases reviewed.
2. **Acceptance rate**: accepted outputs / outputs reviewed.
3. **Correction burden**: material corrections per task.
4. **Verified success rate**: tasks meeting predefined success criteria / tasks evaluated.
5. **Time per comparable task**: median elapsed time, only where reliable timing exists.
6. **Regression rate**: tasks that got worse after a change.
7. **Evidence coverage**: evaluations with a verified outcome / evaluations recorded.

Always show sample size and date range. Do not claim improvement from one successful example. Prefer a minimum of 10 comparable evaluated runs before displaying a directional trend; label smaller samples as preliminary. A metric that has no data must display “Not measured”, never 0%.

## Adaptation workflow

1. Capture explicit feedback and repeated corrections.
2. Propose a candidate preference or workflow change.
3. Keep explicit user preferences separate from inferred preferences.
4. Test a candidate against representative tasks and existing tests.
5. Compare the candidate with the baseline using the same success criteria.
6. Promote only when the evidence supports improvement and no important regression appears.
7. Record the decision, evidence, version, and rollback path.

## Preference confidence

- **Explicit**: directly stated by the user; apply within the stated scope.
- **Observed**: inferred from repeated behavior; provisional and reversible.
- **Confirmed**: user has reviewed and confirmed an inferred preference.

Never turn a single behavior into a permanent preference. Ask only when the preference materially affects an important decision.

## Human approval boundary

The system may automatically summarize, classify, evaluate, draft, run local tests, and propose internal plan updates. It must request approval before sending messages, publishing, spending money, making commitments, changing critical data, or deploying self-modifications.

## Dashboard output

The adaptation report should show:
- best-improving components/workflows and the evidence;
- components with regressions or too little data;
- newly detected preferences with confidence and source;
- changes tested, accepted, rejected, or awaiting review;
- next experiment and success criterion;
- last successful run and any execution errors.

## First implementation sequence

1. Add the SQLite schema in `Data/adaptation-schema.sql`.
2. Instrument workflow executions to write run and feedback records.
3. Build a read-only report from those records.
4. Add controlled experiments and candidate-vs-baseline comparisons.
5. Add scheduled execution only after the run loop and error handling are tested.
