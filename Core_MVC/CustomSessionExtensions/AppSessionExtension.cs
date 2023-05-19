using System.Text.Json;
namespace Core_MVC.CustomSessionExtensions
{
    public static class AppSessionExtension
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            // Serializing the Object into String and storing it in Session State
            session.SetString(key, JsonSerializer.Serialize<T>(value));
        }


        /// <summary>
        /// Read data from Session STate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetObject<T>(this ISession session, string key)
        {
            string data = session.GetString(key);
            if(data == null)
                return default(T); // Return an emty object

            // Deserialize the data from Session

            return JsonSerializer.Deserialize<T>(data);
        }
    }
}
