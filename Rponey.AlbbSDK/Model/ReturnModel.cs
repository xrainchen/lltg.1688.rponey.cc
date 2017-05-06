using Newtonsoft.Json;

namespace Rponey.AlbbSDK.Model
{
    public class ReturnModel
    {
        [JsonProperty(PropertyName = "result")]
        public ResultModel Result { get; set; }
    }

    public class ResultModel
    {
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }


        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }
    }
}
