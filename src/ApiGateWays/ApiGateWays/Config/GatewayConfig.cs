namespace ApiGateWays.Config
{
    public record DownStreamServiceConfig
    {
        public string ApiPath { get; set; } = "";
        public string? ClientId { get; init; } = "";
        public string? ClientSecret { get; init; } = "";
        public string? Scope { get; init; } = "";
    }

    public record GateWayConfig
    {
        public string Url { get; init; } = "";
        public int SessionTimeoutInMin { get; init; }
        public string ApiPath { get; init; } = "";
        public string Authority { get; init; } = "";
        public string ExternalAuthority { get; init; } = "";
        public string ClientId { get; init; } = "";
        public string ClientSecret { get; init; } = "";
        public string Scope { get; init; } = "";
        public string LogoutUrl { get; init; } = "";
        public List<DownStreamServiceConfig> DownStreamServiceConfigs { get; init; } = new();
    }
}
