Console.WriteLine("=== Industrial Maintenance Calculator ===");

Console.Write("Heures d'arrêt par incident : ");

if (double.TryParse(Console.ReadLine(), out double heuresArret))
{
    Console.Write("Coût par heure (€) : ");

    if (double.TryParse(Console.ReadLine(), out double coutParHeure))
    {
        Console.Write("Nombre d'incidents par mois : ");

        if (int.TryParse(Console.ReadLine(), out int incidentsParMois))
        {
            double coutParIncident = heuresArret * coutParHeure;
            double coutMensuel = coutParIncident * incidentsParMois;
            double coutAnnuel = coutMensuel * 12;

            Console.WriteLine();
            Console.WriteLine("=== Résultats ===");
            Console.WriteLine($"Coût par incident : {coutParIncident} €");
            Console.WriteLine($"Coût mensuel estimé : {coutMensuel} €");
            Console.WriteLine($"Coût annuel estimé : {coutAnnuel} €");
        }
        else
        {
            Console.WriteLine("Erreur : nombre d'incidents invalide.");
        }
    }
    else
    {
        Console.WriteLine("Erreur : coût par heure invalide.");
    }
}
else
{
    Console.WriteLine("Erreur : nombre d'heures invalide.");
}