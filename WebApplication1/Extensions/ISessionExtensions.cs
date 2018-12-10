using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebApplication1.Extensions
{
    public static class ISessionExtensions
    {
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
