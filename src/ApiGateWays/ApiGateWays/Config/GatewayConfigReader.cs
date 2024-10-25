namespace ApiGateWays.Config
{
    public static class GatewayConfigReader
    {
        public static GateWayConfig GetGateWayConfig(this IConfiguration configuration)
        {
            var result = new GateWayConfig
            {
                Url = configuration.GetValue("Gateway: Url", ""),
                SessionTimeoutInMin=configuration.GetValue("Gateway:SessionTimeoutInMin",60),
                ApiPath=configuration.GetValue("Gateway: ApiPath","/api/"),
                Authority=configuration.GetValue<string>("OpenIdConnect: Authority"),
                ExternalAuthority=configuration.GetValue<string>("OpenIdConnect: ExternalAuthority"),
                ClientId=configuration.GetValue<string>("OpenIdConnect: ClientId"),
                ClientSecret=configuration.GetValue<string>("OpenIdConnect: ClientSecret"),
                Scope=configuration.GetValue("OpenIdConnect: Scope",""),
                LogoutUrl=configuration.GetValue("OpenIdConnect: LogoutUrl",""),
                DownStreamServiceConfigs=configuration.GetSection("OpenIdConnect: DownStreamServices").Get<List<DownStreamServiceConfig>>()
            };
            return result;
        }
    }
}
