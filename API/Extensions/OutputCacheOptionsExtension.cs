using API.Enums;
using Microsoft.AspNetCore.OutputCaching;

namespace API.Extensions
{
    internal static class OutputCacheOptionsExtension
    {
        internal static void AddPolicyEnum(this OutputCacheOptions o, CachePolicy policy, Action<OutputCachePolicyBuilder> build)
        {
            o.AddPolicy(nameof(policy), build);
        }
    }
}
