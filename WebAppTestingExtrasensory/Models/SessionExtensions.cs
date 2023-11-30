using Newtonsoft.Json;

namespace WebAppTestingExtrasensory.Models
{
    public static class SessionExtensions
    {
        public static string GetSessionName(this ISession session, string v)
        {
            return session.Id;
        }

        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
