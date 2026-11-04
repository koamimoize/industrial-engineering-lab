const DATA_URL = "./data/amu_tns_seed.json";
let db = null;
let activeCatalog = "acts";

const $ = (id) => document.getElementById(id);
const money = (n) => new Intl.NumberFormat("fr-FR").format(Math.round(n)) + " FCFA";
const escapeHtml = (value) => String(value ?? "").replace(/[&<>"']/g, (c) => ({"&":"&amp;","<":"&lt;",">":"&gt;",'"':"&quot;","'":"&#39;"}[c]));

async function loadData() {
  try {
    const response = await fetch(DATA_URL);
    if (!response.ok) throw new Error("Impossible de charger le jeu de données.");
    db = await response.json();
    $("hero-count").textContent = db.acts.length + db.providers.length + db.products.length;
    $("act-count").textContent = db.acts.length;
    $("provider-count").textContent = db.providers.length;
    $("product-count").textContent = db.products.length;
    populateFilters();
    renderProviders();
    renderCatalogue();
    renderStayTable();
  } catch (error) {
    $("hero-count").textContent = "—";
    document.querySelectorAll(".panel").forEach((p) => {
      if (p.id === "dashboard") p.insertAdjacentHTML("beforeend", '<div class="card notice-card"><div class="notice-icon">!</div><div><h3>Base de données non chargée</h3><p>Ouvre l’application depuis un serveur web (GitHub Pages ou serveur local), pas directement en fichier local.</p></div></div>');
    });
  }
}

function activateTab(id) {
  document.querySelectorAll(".tab").forEach((b) => b.classList.toggle("active", b.dataset.tab === id));
  document.querySelectorAll(".panel").forEach((p) => p.classList.toggle("active", p.id === id));
  window.scrollTo({top: 0, behavior: "smooth"});
}
document.querySelectorAll(".tab").forEach((b) => b.addEventListener("click", () => activateTab(b.dataset.tab)));
document.querySelectorAll("[data-go]").forEach((b) => b.addEventListener("click", () => activateTab(b.dataset.go)));

function populateFilters() {
  const regions = [...new Set(db.providers.map(p => p.region))].sort();
  const types = [...new Set(db.providers.map(p => p.type))].sort();
  $("region-filter").innerHTML += regions.map(v => '<option value="' + escapeHtml(v) + '">' + escapeHtml(v) + '</option>').join("");
  $("type-filter").innerHTML += types.map(v => '<option value="' + escapeHtml(v) + '">' + escapeHtml(v) + '</option>').join("");
}

function renderProviders() {
  if (!db) return;
  const query = $("provider-search").value.trim().toLocaleLowerCase("fr");
  const region = $("region-filter").value;
  const type = $("type-filter").value;
  const matches = db.providers.filter(p => {
    const text = [p.code,p.name,p.type,p.sector,p.prefecture,p.region].join(" ").toLocaleLowerCase("fr");
    return (!query || text.includes(query)) && (!region || p.region === region) && (!type || p.type === type);
  });
  $("provider-result-count").textContent = matches.length + " résultat(s)";
  renderRecommendation(matches, region, type);\n  $("provider-list").innerHTML = matches.length ? matches.map(p => `
    <article class="provider-card">
      <h3>${escapeHtml(p.name)}</h3>
      <p>Code : ${escapeHtml(p.code)} · ${escapeHtml(p.type)}</p>
      <p>${escapeHtml(p.prefecture)} · ${escapeHtml(p.region)}</p>
      <div class="provider-meta"><span>${escapeHtml(p.sector)}</span><span>Niveau ${escapeHtml(p.level)}</span></div>
      <p class="small muted" style="margin-top:10px">${escapeHtml(p.verification)}</p>
    </article>`).join("") : '<article class="card"><p>Aucun résultat dans les extraits chargés. Élargis la recherche ou consulte le référentiel officiel.</p></article>';
}
["provider-search","region-filter","type-filter"].forEach(id => $(id).addEventListener(id === "provider-search" ? "input" : "change", renderProviders));

function renderRecommendation(matches, region, type) {
  const target = $("recommendation-content");
  if (!region) {
    target.textContent = "Sélectionne d'abord la région où la personne souhaite recevoir les soins.";
    return;
  }
  if (!matches.length) {
    target.textContent = "Aucun prestataire de cette sélection dans les extraits chargés. Consulte le référentiel complet ou élargis les filtres.";
    return;
  }
  const sorted = [...matches].sort((a,b) => {
    const rank = (p) => {
      const t = p.type.toLowerCase();
      if (type) return t === type.toLowerCase() ? 3 : 0;
      if (/urgence|chu|chr|hôpital/.test(t)) return 3;
      if (/usp|cms|cabinet|infirmerie/.test(t)) return 2;
      if (/pharmacie|laboratoire/.test(t)) return 1;
      return 0;
    };
    return rank(b)-rank(a) || a.name.localeCompare(b.name,"fr");
  }).slice(0,3);
  target.innerHTML = '<b>Candidats à contacter dans ' + escapeHtml(region) + ' :</b><ol>' +
    sorted.map(p => '<li><b>' + escapeHtml(p.name) + '</b> — ' + escapeHtml(p.type) + ', ' + escapeHtml(p.prefecture) + '</li>').join("") +
    '</ol><p class="small muted">Sélection fondée sur la région et la catégorie administrative. Ce classement technique ne signifie pas « meilleur hôpital ». Appelle chaque centre pour confirmer le service recherché, l'adresse, la convention AMU-TNS et la disponibilité.</p>';
}

function renderCatalogue() {
  if (!db) return;
  const isActs = activeCatalog === "acts";
  const query = $("catalog-search").value.trim().toLocaleLowerCase("fr");
  const status = $("status-filter").value;
  const records = (isActs ? db.acts : db.products).filter(r => {
    const text = Object.values(r).join(" ").toLocaleLowerCase("fr");
    return (!query || text.includes(query)) && (!status || r.status.toLowerCase() === status.toLowerCase());
  });
  $("catalog-head").innerHTML = isActs
    ? "<tr><th>Code</th><th>Acte</th><th>Chapitre</th><th>Statut</th></tr>"
    : "<tr><th>Code</th><th>Produit</th><th>DCI</th><th>Prix public</th><th>Base remb.</th><th>Statut</th></tr>";
  $("catalog-body").innerHTML = records.map(r => isActs
    ? `<tr><td><b>${escapeHtml(r.code)}</b></td><td>${escapeHtml(r.label)}</td><td>${escapeHtml(r.chapter)}</td><td><span class="status">${escapeHtml(r.status)}</span></td></tr>`
    : `<tr><td><b>${escapeHtml(r.code)}</b></td><td>${escapeHtml(r.name)}</td><td>${escapeHtml(r.dci)}</td><td>${money(r.public_price_xof)}</td><td>${money(r.reimbursement_base_xof)}</td><td><span class="status ${r.status === "TPC" ? "tpc" : ""}">${escapeHtml(r.status)}</span></td></tr>`
  ).join("") || '<tr><td colspan="6">Aucun résultat dans les données chargées.</td></tr>';
}
document.querySelectorAll("[data-catalog]").forEach(b => b.addEventListener("click", () => {
  activeCatalog = b.dataset.catalog;
  document.querySelectorAll("[data-catalog]").forEach(x => x.classList.toggle("active", x === b));
  $("catalog-search").value = "";
  $("status-filter").value = "";
  renderCatalogue();
}));
$("catalog-search").addEventListener("input", renderCatalogue);
$("status-filter").addEventListener("change", renderCatalogue);

function renderStayTable() {
  if (!db) return;
  $("stay-table").innerHTML = db.stay_reference.rooms.map(row => `
    <tr><td>${escapeHtml(row.room)}</td><td>${escapeHtml(row.provider)}</td><td>${money(row.periods[0].amount_xof)}</td><td>${money(row.periods[1].amount_xof)}</td><td>${money(row.periods[2].amount_xof)}</td></tr>`
  ).join("");
}

$("orient-btn").addEventListener("click", () => {
  const person = $("person").value;
  const symptom = $("symptom").value;
  const duration = $("duration").value;
  const redFlag = $("redflag").checked;
  const notes = $("notes").value.trim();
  const result = $("home-result");
  if (redFlag) {
    result.innerHTML = '<div class="orientation urgent"><h4>Priorité : obtenir une aide médicale immédiate</h4><p>Tu as indiqué un signe grave ou une aggravation rapide. N’attends pas une orientation numérique. Contacte les services d’urgence locaux ou rends-toi au service d’urgence le plus proche. Si possible, fais-toi accompagner.</p></div>';
    return;
  }
  if (!symptom) {
    result.innerHTML = '<div class="orientation"><h4>Choisis un motif</h4><p>Sélectionne le motif principal pour obtenir une liste de prochaines étapes non diagnostiques.</p></div>';
    return;
  }
  let urgency = "Prends contact avec un professionnel de santé ou un centre de soins pour déterminer le délai adapté. Si l’état s’aggrave ou si un signe grave apparaît, demande une aide urgente.";
  if (symptom === "Symptôme lié à la grossesse") urgency = "Pour tout symptôme nouveau pendant une grossesse, contacte rapidement la sage-femme, la maternité ou le professionnel qui suit la grossesse. Saignement, douleur intense, malaise, convulsions ou difficulté respiratoire : urgence immédiate.";
  if (symptom === "Douleur / gêne respiratoire") urgency = "Une gêne respiratoire peut nécessiter une évaluation rapide. Si elle est importante, soudaine, accompagnée de douleur thoracique, lèvres bleutées ou malaise : urgence immédiate.";
  if (symptom === "Fièvre" || symptom === "Diarrhée / vomissements") urgency = "Surveille l'évolution et demande conseil à un professionnel, surtout si la personne est un nourrisson, une femme enceinte, âgée ou fragile, ou si elle ne peut pas boire, urine très peu, devient confuse ou très faible.";
  result.innerHTML = `<div class="orientation"><h4>Prochaines étapes suggérées — ${escapeHtml(person)}</h4><p><b>Motif :</b> ${escapeHtml(symptom)} · <b>Durée :</b> ${escapeHtml(duration)}</p><p>${escapeHtml(urgency)}</p><ol><li>Note l'heure de début et l'évolution du symptôme.</li><li>Prépare les médicaments pris, allergies et antécédents utiles.</li><li>Avant un soin programmé, confirme la convention AMU du centre et la prise en charge de l'acte.</li><li>Ne commence, n'arrête ou ne modifie pas un médicament sans avis d'un professionnel.</li></ol>${notes ? '<p><b>Notes à communiquer au soignant :</b> ' + escapeHtml(notes) + '</p>' : ''}<p class="small muted"><b>Limite :</b> cette suggestion est fondée sur des règles de sécurité générales. Elle ne diagnostique pas et ne remplace pas une évaluation clinique.</p></div>`;
});

$("calculate-btn").addEventListener("click", () => {
  const base = Number($("base-amount").value);
  const rate = Number($("rate").value);
  const actualRaw = $("actual-amount").value;
  const actual = actualRaw === "" ? null : Number(actualRaw);
  const out = $("calc-result");
  if (!Number.isFinite(base) || base <= 0) {
    out.textContent = "Saisis une base totale de remboursement positive et confirmée.";
    return;
  }
  if (rate === 0) {
    out.textContent = "Le taux n'est pas confirmé. Consulte le référentiel ou la CNSS avant de calculer.";
    return;
  }
  const amu = base * rate;
  const copay = base - amu;
  const difference = actual === null ? null : Math.max(0, actual - amu);
  out.innerHTML = `<div>Base saisie : <b>${money(base)}</b></div><div>Part AMU théorique (${Math.round(rate*100)} %) : <strong>${money(amu)}</strong></div><div>Part patient sur la base : <b>${money(copay)}</b></div>${difference === null ? "" : '<div>Reste indicatif sur facture réelle : <b>' + money(difference) + '</b></div>'}<p class="small muted">Estimation arithmétique seulement. Elle suppose que la base et le taux saisis sont effectivement applicables. Le calcul final de la CNSS et les frais non couverts peuvent différer.</p>`;
});

loadData();