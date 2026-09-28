using Microsoft.Data.Sqlite;

string connectionString = "Data Source=industrial-downtime.db";

InitializeDatabase();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("========================================");
    Console.WriteLine("      MACHINE DOWNTIME TRACKER");
    Console.WriteLine("========================================");

    Console.WriteLine();
    Console.WriteLine("1. Add incident");
    Console.WriteLine("2. View incidents");
    Console.WriteLine("3. Machine analysis");
    Console.WriteLine("4. Exit");

    Console.WriteLine();

    Console.Write("Choose an option : ");

    string choice = Console.ReadLine() ?? "";

    Console.WriteLine();

    if (choice == "1")
    {
        AddIncident();
    }
    else if (choice == "2")
    {
        ViewIncidents();
    }
    else if (choice == "3")
    {
        AnalyzeMachines();
    }
    else if (choice == "4")
    {
        Console.WriteLine("Goodbye.");
        break;
    }
    else
    {
        Console.WriteLine("Invalid option.");
    }
}


static void InitializeDatabase()
{
    using var connection =
        new SqliteConnection(
            "Data Source=industrial-downtime.db"
        );

    connection.Open();

    string sql = """
        CREATE TABLE IF NOT EXISTS Incidents
        (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            MachineName TEXT NOT NULL,
            DowntimeHours REAL NOT NULL,
            CostPerHour REAL NOT NULL,
            Description TEXT NOT NULL
        );
        """;

    using var command =
        new SqliteCommand(sql, connection);

    command.ExecuteNonQuery();
}


static void AddIncident()
{
    Console.WriteLine("ADD INCIDENT");
    Console.WriteLine("----------------------------------------");

    Console.Write("Machine name : ");
    string machineName = Console.ReadLine() ?? "Unknown";

    double downtimeHours =
        ReadPositiveNumber("Downtime (hours) : ");

    double costPerHour =
        ReadPositiveNumber(
            "Cost per downtime hour (€) : "
        );

    Console.Write("Failure description : ");
    string description =
        Console.ReadLine() ?? "Unknown";

    using var connection =
        new SqliteConnection(
            "Data Source=industrial-downtime.db"
        );

    connection.Open();

    string sql = """
        INSERT INTO Incidents
        (
            MachineName,
            DowntimeHours,
            CostPerHour,
            Description
        )
        VALUES
        (
            $machineName,
            $downtimeHours,
            $costPerHour,
            $description
        );
        """;

    using var command =
        new SqliteCommand(sql, connection);

    command.Parameters.AddWithValue(
        "$machineName",
        machineName
    );

    command.Parameters.AddWithValue(
        "$downtimeHours",
        downtimeHours
    );

    command.Parameters.AddWithValue(
        "$costPerHour",
        costPerHour
    );

    command.Parameters.AddWithValue(
        "$description",
        description
    );

    command.ExecuteNonQuery();

    Console.WriteLine();
    Console.WriteLine(
        "Incident saved to SQLite."
    );
}


static void ViewIncidents()
{
    using var connection =
        new SqliteConnection(
            "Data Source=industrial-downtime.db"
        );

    connection.Open();

    string sql = """
        SELECT
            Id,
            MachineName,
            DowntimeHours,
            CostPerHour,
            Description
        FROM Incidents
        ORDER BY Id;
        """;

    using var command =
        new SqliteCommand(sql, connection);

    using var reader =
        command.ExecuteReader();

    Console.WriteLine("INCIDENT HISTORY");
    Console.WriteLine("----------------------------------------");

    bool hasIncidents = false;

    while (reader.Read())
    {
        hasIncidents = true;

        int id = reader.GetInt32(0);

        string machineName =
            reader.GetString(1);

        double downtimeHours =
            reader.GetDouble(2);

        double costPerHour =
            reader.GetDouble(3);

        string description =
            reader.GetString(4);

        double cost =
            downtimeHours * costPerHour;

        Console.WriteLine();

        Console.WriteLine(
            $"Incident #{id}"
        );

        Console.WriteLine(
            $"Machine        : {machineName}"
        );

        Console.WriteLine(
            $"Downtime       : {downtimeHours:N2} h"
        );

        Console.WriteLine(
            $"Cost per hour  : {costPerHour:N2} €"
        );

        Console.WriteLine(
            $"Estimated cost : {cost:N2} €"
        );

        Console.WriteLine(
            $"Description    : {description}"
        );

        Console.WriteLine(
            "----------------------------------------"
        );
    }

    if (!hasIncidents)
    {
        Console.WriteLine(
            "No incidents recorded."
        );
    }
}


static void AnalyzeMachines()
{
    using var connection =
        new SqliteConnection(
            "Data Source=industrial-downtime.db"
        );

    connection.Open();

    string sql = """
        SELECT
            MachineName,
            COUNT(*) AS IncidentCount,
            SUM(DowntimeHours) AS TotalDowntime,
            SUM(DowntimeHours * CostPerHour) AS TotalCost
        FROM Incidents
        GROUP BY MachineName
        ORDER BY TotalDowntime DESC;
        """;

    using var command =
        new SqliteCommand(sql, connection);

    using var reader =
        command.ExecuteReader();

    Console.WriteLine("MACHINE ANALYSIS");
    Console.WriteLine(
        "----------------------------------------"
    );

    bool hasMachines = false;

    while (reader.Read())
    {
        hasMachines = true;

        string machineName =
            reader.GetString(0);

        long incidentCount =
            reader.GetInt64(1);

        double totalDowntime =
            reader.GetDouble(2);

        double totalCost =
            reader.GetDouble(3);

        Console.WriteLine();

        Console.WriteLine(machineName);

        Console.WriteLine(
            $"Incidents       : {incidentCount}"
        );

        Console.WriteLine(
            $"Downtime        : {totalDowntime:N2} h"
        );

        Console.WriteLine(
            $"Downtime cost   : {totalCost:N2} €"
        );
    }

    if (!hasMachines)
    {
        Console.WriteLine(
            "No incidents available for analysis."
        );
    }
}


static double ReadPositiveNumber(
    string message)
{
    while (true)
    {
        Console.Write(message);

        if (double.TryParse(
            Console.ReadLine(),
            out double value))
        {
            if (value > 0)
            {
                return value;
            }
        }

        Console.WriteLine(
            "Error: enter a number greater than 0."
        );
    }
}