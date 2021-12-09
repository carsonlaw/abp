namespace Volo.Match
{
    public static class MatchDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Match";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Match";
    }
}
