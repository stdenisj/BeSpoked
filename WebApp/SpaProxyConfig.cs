using Microsoft.Extensions.Primitives;
using Yarp.ReverseProxy.Configuration;

namespace BeSpoked.Api;

public static class SpaProxyConfig  {
    public static IReverseProxyBuilder LoadSpaConfig(
        this IReverseProxyBuilder builder
    ) {
        var routes = new []{ new RouteConfig() {
            ClusterId = "spa-cluster",
            RouteId = "spa-route",
            Match = new RouteMatch() {
                Path = "{**catch-all}"
            }
        }};
        var clusters = new []{ new ClusterConfig() {
            ClusterId = "spa-cluster",
            Destinations = new Dictionary<string, DestinationConfig>() {
                { "react", new DestinationConfig() {
                    Address = "http://localhost:5173"
                }}
            }
        } };
        builder.Services.AddSingleton<IProxyConfigProvider>(new InMemoryConfigProvider(routes, clusters));
        return builder;
    }
    
    private class InMemoryConfigProvider : IProxyConfigProvider
    {
        private volatile InMemoryConfig _config;

        public InMemoryConfigProvider(IReadOnlyList<RouteConfig> routes, IReadOnlyList<ClusterConfig> clusters)
        {
            _config = new InMemoryConfig(routes, clusters);
        }

        public IProxyConfig GetConfig() => _config;

        public void Update(IReadOnlyList<RouteConfig> routes, IReadOnlyList<ClusterConfig> clusters)
        {
            var oldConfig = _config;
            _config = new InMemoryConfig(routes, clusters);
            oldConfig.SignalChange();
        }

        private class InMemoryConfig : IProxyConfig
        {
            private readonly CancellationTokenSource _cts = new ();

            public InMemoryConfig(IReadOnlyList<RouteConfig> routes, IReadOnlyList<ClusterConfig> clusters)
            {
                Routes = routes;
                Clusters = clusters;
                ChangeToken = new CancellationChangeToken(_cts.Token);
            }

            public IReadOnlyList<RouteConfig> Routes { get; }

            public IReadOnlyList<ClusterConfig> Clusters { get; }

            public IChangeToken ChangeToken { get; }

            internal void SignalChange()
            {
                _cts.Cancel();
            }
        }
    }
}