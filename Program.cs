Console.WriteLine("=== INDUSTRIAL MAINTENANCE CALCULATOR ===");
Console.WriteLine();

double heuresArret = LireNombrePositif(
    "Heures d'arrêt par incident : "
);

double coutParHeure = LireNombrePositif(
    "Coût par heure (€) : "
);

double incidentsParMois = LireNombrePositif(
    "Nombre d'incidents par mois : "
);

// Calculs
double coutParIncident = heuresArret * coutParHeure;
double coutMensuel = coutParIncident * incidentsParMois;
double coutAnnuel = coutMensuel * 12;

// Résultats
Console.WriteLine();
Console.WriteLine("=== RÉSULTATS ===");
Console.WriteLine();

Console.WriteLine($"Coût par incident : {coutParIncident:N2} €");
Console.WriteLine($"Coût mensuel estimé : {coutMensuel:N2} €");
Console.WriteLine($"Coût annuel estimé : {coutAnnuel:N2} €");


// Fonction de validation
static double LireNombrePositif(string message)
{
    while (true)
    {
        Console.Write(message);

        if (double.TryParse(Console.ReadLine(), out double valeur))
        {
            if (valeur > 0)
            {
                return valeur;
            }
        }

        Console.WriteLine("Erreur : entre un nombre supérieur à 0.");
        Console.WriteLine();
    }
}