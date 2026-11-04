PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS services (
  service_id TEXT PRIMARY KEY,
  sector TEXT NOT NULL,
  service_name TEXT NOT NULL,
  authority_or_provider TEXT,
  authority_confidence TEXT,
  service_purpose TEXT,
  industrial_relevance TEXT,
  eligibility_or_scope TEXT,
  official_url TEXT,
  source_status TEXT NOT NULL,
  verification_needed TEXT,
  priority TEXT,
  last_verified_on TEXT,
  notes TEXT
);

CREATE TABLE IF NOT EXISTS opportunities (
  opportunity_id TEXT PRIMARY KEY,
  sector TEXT NOT NULL,
  opportunity_title TEXT NOT NULL,
  potential_customer TEXT,
  problem_to_validate TEXT,
  possible_lab_offer TEXT,
  regulatory_dependency TEXT,
  delivery_model TEXT,
  priority TEXT,
  validation_status TEXT,
  next_action TEXT,
  customer_interviews INTEGER DEFAULT 0,
  evidence_notes TEXT,
  last_updated_on TEXT
);

CREATE TABLE IF NOT EXISTS authorities (
  authority_id TEXT PRIMARY KEY,
  authority_name TEXT NOT NULL,
  mandate_or_role TEXT,
  official_website TEXT,
  public_contact TEXT,
  verification_status TEXT DEFAULT 'a_verifier',
  last_verified_on TEXT
);

CREATE TABLE IF NOT EXISTS service_authorities (
  service_id TEXT NOT NULL,
  authority_id TEXT NOT NULL,
  role_description TEXT,
  PRIMARY KEY (service_id, authority_id),
  FOREIGN KEY (service_id) REFERENCES services(service_id),
  FOREIGN KEY (authority_id) REFERENCES authorities(authority_id)
);

CREATE TABLE IF NOT EXISTS evidence_log (
  evidence_id INTEGER PRIMARY KEY AUTOINCREMENT,
  record_type TEXT NOT NULL CHECK (record_type IN ('service','opportunity','authority')),
  record_id TEXT NOT NULL,
  source_url TEXT NOT NULL,
  source_title TEXT,
  evidence_summary TEXT,
  confidence TEXT DEFAULT 'a_verifier',
  checked_on TEXT NOT NULL,
  follow_up_required TEXT
);

CREATE INDEX IF NOT EXISTS idx_services_sector ON services(sector);
CREATE INDEX IF NOT EXISTS idx_services_status ON services(source_status);
CREATE INDEX IF NOT EXISTS idx_opportunities_sector ON opportunities(sector);
CREATE INDEX IF NOT EXISTS idx_opportunities_priority ON opportunities(priority);
