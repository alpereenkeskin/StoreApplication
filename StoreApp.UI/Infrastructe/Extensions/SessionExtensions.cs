using System.Text.Json;

namespace StoreApp.UI.Infrastructe.Extensions
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key)
        {
            session.SetString(key, JsonSerializer.Serialize(key)); // burada key degerini JSON formatına çeviriyoruz.
        }

        public static void SetJson<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));

        }
        public static T? GetJson<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            return data is null ? default(T)
             : JsonSerializer.Deserialize<T>(data);

        }



    }

}