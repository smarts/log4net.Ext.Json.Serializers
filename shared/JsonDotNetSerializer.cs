using log4net.ObjectRenderer;
using Newtonsoft.Json;

namespace log4net.Util.Serializer
{
    public class JsonDotNetSerializer : ISerializer, ISerializerFactory
    {
        public bool IncludeNullValues { get; set; }

        public object Serialize(object obj)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = IncludeNullValues ?
                    NullValueHandling.Include :
                    NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(obj, settings);
        }

        public ISerializer GetSerializer(object obj, RendererMap map)
        {
            return this;
        }
    }
}