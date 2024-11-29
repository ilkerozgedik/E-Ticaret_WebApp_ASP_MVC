using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;

namespace RegisterLoginApp_ASP_MVC.Extensions
{
    public static class SessionExtensions
    {
        // Session'a nesne eklemek için yardımcı metod
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            var json = JsonConvert.SerializeObject(value);  // Nesneyi JSON formatına çevir
            session.SetString(key, json);  // JSON verisini string olarak session'a kaydet
        }

        // Session'dan nesne almak için yardımcı metod
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var json = session.GetString(key);  // JSON formatındaki string veriyi al
            return json == null ? default(T) : JsonConvert.DeserializeObject<T>(json);  // JSON'u nesneye dönüştür
        }
    }
}
