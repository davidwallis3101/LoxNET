using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LoxNET.Serialization
{
    public class ResultConverter
    {
        public static ResultModel Deserialize(string json)
        {
            var root = JObject.Parse(json).SelectToken("LL").ToString().Replace("\r\n","");
            return JsonConvert.DeserializeObject<ResultModel>(root);
        }
    }
}