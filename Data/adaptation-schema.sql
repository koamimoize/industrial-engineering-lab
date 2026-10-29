-- Core OS adaptation monitoring schema.
-- This schema stores evidence about workflow quality; it does not itself run agents.

PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS AdaptationRuns (
    RunId INTEGER PRIMARY KEY AUTOINCREMENT,
    StartedAtUtc TEXT NOT NULL DEFAULT (strftime('%Y-%m-%dT%H:%M:%fZ', 'now')),
    ComponentName TEXT NOT NULL,
    ComponentVersion TEXT NOT NULL DEFAULT 'v1',
    WorkflowName TEXT NOT NULL,
    TaskType TEXT NOT NULL,
    ExpectedOutcome TEXT,
    ActualOutcome TEXT,
    OutcomeVerified INTEGER NOT NULL DEFAULT 0 CHECK (OutcomeVerified IN (0, 1)),
    UserVerdict TEXT CHECK (UserVerdict IN ('accepted', 'corrected', 'rejected', 'not_reviewed')),
    CorrectionCount INTEGER NOT NULL DEFAULT 0 CHECK (CorrectionCount >= 0),
    DurationSeconds REAL CHECK (DurationSeconds IS NULL OR DurationSeconds >= 0),
    EvidenceReference TEXT,
    Notes TEXT
);

CREATE INDEX IF NOT EXISTS IX_AdaptationRuns_ComponentDate
    ON AdaptationRuns (ComponentName, StartedAtUtc);

CREATE INDEX IF NOT EXISTS IX_AdaptationRuns_WorkflowTaskDate
    ON AdaptationRuns (WorkflowName, TaskType, StartedAtUtc);

CREATE TABLE IF NOT EXISTS PreferenceSignals (
    PreferenceId INTEGER PRIMARY KEY AUTOINCREMENT,
    PreferenceKey TEXT NOT NULL,
    PreferredValue TEXT NOT NULL,
    Scope TEXT NOT NULL DEFAULT 'global',
    SourceType TEXT NOT NULL CHECK (SourceType IN ('explicit', 'observed', 'confirmed')),
    Confidence REAL NOT NULL DEFAULT 1.0 CHECK (Confidence >= 0.0 AND Confidence <= 1.0),
    ObservationCount INTEGER NOT NULL DEFAULT 1 CHECK (ObservationCount >= 1),
    IsActive INTEGER NOT NULL DEFAULT 1 CHECK (IsActive IN (0, 1)),
    FirstObservedAtUtc TEXT NOT NULL DEFAULT (strftime('%Y-%m-%dT%H:%M:%fZ', 'now')),
    LastObservedAtUtc TEXT NOT NULL DEFAULT (strftime('%Y-%m-%dT%H:%M:%fZ', 'now')),
    EvidenceReference TEXT,
    Notes TEXT
);

CREATE INDEX IF NOT EXISTS IX_PreferenceSignals_KeyScope
    ON PreferenceSignals (PreferenceKey, Scope, IsActive);

CREATE TABLE IF NOT EXISTS FeedbackEvents (
    FeedbackId INTEGER PRIMARY KEY AUTOINCREMENT,
    RunId INTEGER NOT NULL,
    FeedbackType TEXT NOT NULL CHECK (FeedbackType IN ('positive', 'correction', 'rejection', 'preference', 'outcome')),
    Details TEXT NOT NULL,
    CreatedAtUtc TEXT NOT NULL DEFAULT (strftime('%Y-%m-%dT%H:%M:%fZ', 'now')),
    FOREIGN KEY (RunId) REFERENCES AdaptationRuns (RunId) ON DELETE CASCADE
);

CREATE INDEX IF NOT EXISTS IX_FeedbackEvents_Run
    ON FeedbackEvents (RunId, CreatedAtUtc);

CREATE TABLE IF NOT EXISTS AdaptationExperiments (
    ExperimentId INTEGER PRIMARY KEY AUTOINCREMENT,
    ComponentName TEXT NOT NULL,
    Hypothesis TEXT NOT NULL,
    MetricName TEXT NOT NULL,
    BaselineVersion TEXT NOT NULL,
    CandidateVersion TEXT NOT NULL,
    BaselineValue REAL,
    CandidateValue REAL,
    SampleSizeBaseline INTEGER NOT NULL DEFAULT 0 CHECK (SampleSizeBaseline >= 0),
    SampleSizeCandidate INTEGER NOT NULL DEFAULT 0 CHECK (SampleSizeCandidate >= 0),
    Status TEXT NOT NULL DEFAULT 'proposed'
        CHECK (Status IN ('proposed', 'running', 'passed', 'failed', 'inconclusive', 'rolled_back')),
    Decision TEXT,
    CreatedAtUtc TEXT NOT NULL DEFAULT (strftime('%Y-%m-%dT%H:%M:%fZ', 'now')),
    ReviewedAtUtc TEXT,
    EvidenceReference TEXT
);

CREATE TABLE IF NOT EXISTS LessonsLearned (
    LessonId INTEGER PRIMARY KEY AUTOINCREMENT,
    Scope TEXT NOT NULL,
    Lesson TEXT NOT NULL,
    EvidenceCount INTEGER NOT NULL DEFAULT 0 CHECK (EvidenceCount >= 0),
    Confidence REAL NOT NULL DEFAULT 0.0 CHECK (Confidence >= 0.0 AND Confidence <= 1.0),
    Status TEXT NOT NULL DEFAULT 'provisional'
        CHECK (Status IN ('provisional', 'validated', 'rejected', 'superseded')),
    CreatedAtUtc TEXT NOT NULL DEFAULT (strftime('%Y-%m-%dT%H:%M:%fZ', 'now')),
    LastReviewedAtUtc TEXT,
    EvidenceReference TEXT
);

-- Example read-only component comparison. Interpret results only with sample sizes.
CREATE VIEW IF NOT EXISTS AdaptationComponentSummary AS
SELECT
    ComponentName,
    ComponentVersion,
    COUNT(*) AS TotalRuns,
    SUM(CASE WHEN UserVerdict = 'accepted' THEN 1 ELSE 0 END) AS AcceptedRuns,
    SUM(CASE WHEN UserVerdict = 'corrected' THEN 1 ELSE 0 END) AS CorrectedRuns,
    SUM(CASE WHEN UserVerdict = 'rejected' THEN 1 ELSE 0 END) AS RejectedRuns,
    SUM(CASE WHEN OutcomeVerified = 1 THEN 1 ELSE 0 END) AS VerifiedRuns,
    ROUND(AVG(CorrectionCount), 2) AS AvgCorrectionsPerRun,
    ROUND(AVG(DurationSeconds), 2) AS AvgDurationSeconds
FROM AdaptationRuns
GROUP BY ComponentName, ComponentVersion;
