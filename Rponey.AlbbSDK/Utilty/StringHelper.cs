namespace Rponey.AlbbSDK.Utilty
{
    public static class StringHelper
    {
        public static T DeserializeFromJson<T>(this string text)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(text);
        }

        public static string SerializeToJson<T>(this T obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
    }
}
