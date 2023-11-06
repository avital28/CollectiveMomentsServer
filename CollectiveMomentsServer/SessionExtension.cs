using System.Text.Json.Serialization;
using System.Text.Json;

namespace CollectiveMomentsServer
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };

            session.SetString(key, JsonSerializer.Serialize(value, options));
        }
    }
}
