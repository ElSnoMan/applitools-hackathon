namespace Acme.Configuration
{
    public class Config
    {
        public DriverSettings Driver { get; set; }

        public ApplitoolsSettings Applitools { get; set; }

        public EnvironmentSettings Environment { get; set; }
    }

    public class DriverSettings
    {
        public int WaitSeconds { get; set; }
    }

    public class ApplitoolsSettings
    {
        public string AppName { get; set; }
    }

    public class EnvironmentSettings
    {
        public string V1 { get; set; }

        public string V1Home { get; set; }

        public string V2 { get; set; }

        public string V2Home { get; set; }
    }
}
