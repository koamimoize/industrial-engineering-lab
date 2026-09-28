using Microsoft.Data.Sqlite;

string connectionString = "Data Source=industrial-downtime.db";

InitializeDatabase();

while (true)
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("   MACHINE DOWNTIME TRACKER");
    Console.WriteLine("=================================");
    Console.WriteLine();
    Console.WriteLine("1. Add incident");
    Console.WriteLine("2. View incidents");
    Console.WriteLine("3. Machine analysis");
    Console.WriteLine("4. Exit");
    Console.WriteLine();

    Console.Write("Choose an option: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddIncident();
            break;

        case "2":
            ViewIncidents();
            break;

        case "3":
            AnalyzeMachines();
            break;

        case "4":
            return;

        default:
            Console.WriteLine("Invalid option.");
            Pause();
            break;
    }
}


// ========================================
// DATABASE INITIALIZATION
// ========================================

static void InitializeDatabase()
{
    using var connection =
        new SqliteConnection(
            "Data Source=industrial-downtime.db"
        );

    connection.Open();

    string createTableSql = """
        CREATE TABLE IF NOT EXISTS Incidents
        (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            MachineName TEXT NOT NULL,
            IncidentDate TEXT NOT NULL,
            DowntimeHours REAL NOT NULL,
            CostPerHour REAL NOT NULL,
            Description TEXT NOT NULL
        );
        """;

    using var createCommand =
        new SqliteCommand(
            createTableSql,
            connection
        );

    createCommand.ExecuteNonQuery();

    // Add IncidentDate to an existing V8 database
    // if the column does not already exist.
    try
    {
        string alterTableSql = """
            ALTER TABLE Incidents
            ADD COLUMN IncidentDate TEXT NOT NULL DEFAULT '2026-01-01';
            """;

        using var alterCommand =
            new SqliteCommand(
                alterTableSql,
                connection
            );

        alterCommand.ExecuteNonQuery();
    }
    catch (SqliteException)
    {
        // Column already exists.
    }
}


// ========================================
// ADD INCIDENT
// ========================================

static void AddIncident()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("          ADD INCIDENT");
    Console.WriteLine("=================================");
    Console.WriteLine();

    Console.Write("Machine name: ");
    string machineName = Console.ReadLine() ?? "";

    while (string.IsNullOrWhiteSpace(machineName))
    {
        Console.Write("Machine name cannot be empty. Try again: ");
        machineName = Console.ReadLine() ?? "";
    }

    Console.Write("Incident date (YYYY-MM-DD): ");
    string incidentDate = Console.ReadLine() ?? "";

    while (!DateTime.TryParse(incidentDate, out _))
    {
        Console.Write("Invalid date. Use YYYY-MM-DD: ");
        incidentDate = Console.ReadLine() ?? "";
    }

    double downtimeHours =
        ReadPositiveNumber("Downtime hours: ");

    double costPerHour =
        ReadPositiveNumber("Cost per downtime hour (€): ");

    Console.Write("Failure description: ");
    string description = Console.ReadLine() ?? "";

    while (string.IsNullOrWhiteSpace(description))
    {
        Console.Write("Description cannot be empty. Try again: ");
        description = Console.ReadLine() ?? "";
    }

    using var connection =
        new SqliteConnection(
            "Data Source=industrial-downtime.db"
        );

    connection.Open();

    string sql = """
        INSERT INTO Incidents
        (
            MachineName,
            IncidentDate,
            DowntimeHours,
            CostPerHour,
            Description
        )
        VALUES
        (
            $machineName,
            $incidentDate,
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
        "$incidentDate",
        incidentDate
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
    Console.WriteLine("Incident saved to SQLite.");
    Pause();
}


// ========================================
// VIEW INCIDENTS
// ========================================

static void ViewIncidents()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("          ALL INCIDENTS");
    Console.WriteLine("=================================");
    Console.WriteLine();

    using var connection =
        new SqliteConnection(
            "Data Source=industrial-downtime.db"
        );

    connection.Open();

    string sql = """
        SELECT
            Id,
            MachineName,
            IncidentDate,
            DowntimeHours,
            CostPerHour,
            Description
        FROM Incidents
        ORDER BY IncidentDate DESC, Id DESC;
        """;

    using var command =
        new SqliteCommand(sql, connection);

    using var reader =
        command.ExecuteReader();

    bool hasIncidents = false;

    while (reader.Read())
    {
        hasIncidents = true;

        int id = reader.GetInt32(0);
        string machineName = reader.GetString(1);
        string incidentDate = reader.GetString(2);
        double downtimeHours = reader.GetDouble(3);
        double costPerHour = reader.GetDouble(4);
        string description = reader.GetString(5);

        double incidentCost =
            downtimeHours * costPerHour;

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Machine: {machineName}");
        Console.WriteLine($"Date: {incidentDate}");
        Console.WriteLine($"Downtime: {downtimeHours:F2} h");
        Console.WriteLine($"Cost/hour: €{costPerHour:F2}");
        Console.WriteLine($"Incident cost: €{incidentCost:F2}");
        Console.WriteLine($"Description: {description}");
    }

    if (!hasIncidents)
    {
        Console.WriteLine("No incidents recorded.");
    }

    Console.WriteLine();
    Pause();
}


// ========================================
// MACHINE ANALYSIS
// ========================================

static void AnalyzeMachines()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("        MACHINE ANALYSIS");
    Console.WriteLine("=================================");
    Console.WriteLine();

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

    bool hasMachines = false;

    while (reader.Read())
    {
        hasMachines = true;

        string machineName =
            reader.GetString(0);

        int incidentCount =
            reader.GetInt32(1);

        double totalDowntime =
            reader.GetDouble(2);

        double totalCost =
            reader.GetDouble(3);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Machine: {machineName}");
        Console.WriteLine($"Failures: {incidentCount}");
        Console.WriteLine($"Total downtime: {totalDowntime:F2} h");
        Console.WriteLine($"Total cost: €{totalCost:F2}");
    }

    if (!hasMachines)
    {
        Console.WriteLine("No machine data available.");
    }

    Console.WriteLine();
    Pause();
}


// ========================================
// INPUT HELPERS
// ========================================

static double ReadPositiveNumber(string message)
{
    while (true)
    {
        Console.Write(message);

        string? input = Console.ReadLine();

        if (
            double.TryParse(
                input,
                out double value
            )
            && value > 0
        )
        {
            return value;
        }

        Console.WriteLine(
            "Please enter a number greater than 0."
        );
    }
}


static void Pause()
{
    Console.WriteLine();
    Console.WriteLine("Press ENTER to continue...");
    Console.ReadLine();
}