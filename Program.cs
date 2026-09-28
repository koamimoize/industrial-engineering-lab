Console.WriteLine("========================================");
Console.WriteLine("   INDUSTRIAL MAINTENANCE CALCULATOR");
Console.WriteLine("========================================");
Console.WriteLine();

Console.WriteLine("INPUTS");
Console.WriteLine("----------------------------------------");

double heuresArret = LireNombrePositif(
    "Downtime per incident (h) : "
);

double coutParHeure = LireNombrePositif(
    "Cost per downtime hour (€) : "
);

double incidentsParMois = LireNombrePositif(
    "Incidents per month : "
);

double heuresFonctionnementPrevues = LireNombrePositif(
    "Scheduled operating hours/year : "
);

double reductionArret = LirePourcentage(
    "Improvement scenario (%) : "
);


// ========================================
// CURRENT SCENARIO
// ========================================

double coutParIncident =
    heuresArret * coutParHeure;

double coutMensuel =
    coutParIncident * incidentsParMois;

double coutAnnuel =
    coutMensuel * 12;

double heuresArretAnnuel =
    heuresArret * incidentsParMois * 12;


// Validation industrielle
if (heuresArretAnnuel >= heuresFonctionnementPrevues)
{
    Console.WriteLine();
    Console.WriteLine("ERROR");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine(
        "Annual downtime cannot be greater than"
    );
    Console.WriteLine(
        "or equal to scheduled operating hours."
    );

    return;
}


double heuresFonctionnementReelles =
    heuresFonctionnementPrevues -
    heuresArretAnnuel;

double disponibilite =
    (heuresFonctionnementReelles /
    heuresFonctionnementPrevues) * 100;


// ========================================
// IMPROVED SCENARIO
// ========================================

double heuresArretAmeliorees =
    heuresArret *
    (1 - reductionArret / 100);

double coutAnnuelAmeliore =
    heuresArretAmeliorees *
    coutParHeure *
    incidentsParMois *
    12;

double heuresArretAnnuelAmeliorees =
    heuresArretAmeliorees *
    incidentsParMois *
    12;

double heuresFonctionnementAmeliorees =
    heuresFonctionnementPrevues -
    heuresArretAnnuelAmeliorees;

double disponibiliteAmelioree =
    (heuresFonctionnementAmeliorees /
    heuresFonctionnementPrevues) * 100;

double economieAnnuelle =
    coutAnnuel -
    coutAnnuelAmeliore;


// ========================================
// RESULTS
// ========================================

Console.WriteLine();
Console.WriteLine("RESULTS");
Console.WriteLine("----------------------------------------");

Console.WriteLine();
Console.WriteLine("CURRENT SCENARIO");
Console.WriteLine(
    $"Annual downtime       : {heuresArretAnnuel:N2} h"
);
Console.WriteLine(
    $"Annual downtime cost  : {coutAnnuel:N2} €"
);
Console.WriteLine(
    $"Availability          : {disponibilite:N2} %"
);

Console.WriteLine();
Console.WriteLine("IMPROVED SCENARIO");
Console.WriteLine(
    $"Downtime reduction    : {reductionArret:N2} %"
);
Console.WriteLine(
    $"Annual downtime       : {heuresArretAnnuelAmeliorees:N2} h"
);
Console.WriteLine(
    $"Annual downtime cost  : {coutAnnuelAmeliore:N2} €"
);
Console.WriteLine(
    $"Availability          : {disponibiliteAmelioree:N2} %"
);

Console.WriteLine();
Console.WriteLine("----------------------------------------");
Console.WriteLine(
    $"POTENTIAL ANNUAL SAVINGS : {economieAnnuelle:N2} €"
);
Console.WriteLine("========================================");


// ========================================
// INPUT FUNCTIONS
// ========================================

static double LireNombrePositif(string message)
{
    while (true)
    {
        Console.Write(message);

        if (double.TryParse(
            Console.ReadLine(),
            out double valeur))
        {
            if (valeur > 0)
            {
                return valeur;
            }
        }

        Console.WriteLine(
            "Error: enter a number greater than 0."
        );
        Console.WriteLine();
    }
}


static double LirePourcentage(string message)
{
    while (true)
    {
        Console.Write(message);

        if (double.TryParse(
            Console.ReadLine(),
            out double valeur))
        {
            if (valeur >= 0 && valeur <= 100)
            {
                return valeur;
            }
        }

        Console.WriteLine(
            "Error: enter a percentage between 0 and 100."
        );
        Console.WriteLine();
    }
}