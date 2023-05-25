namespace FreeERP;

public static class FreeERPDbProperties
{
    public static string DbTablePrefix { get; set; } = "FreeERP";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "FreeERP";
}
