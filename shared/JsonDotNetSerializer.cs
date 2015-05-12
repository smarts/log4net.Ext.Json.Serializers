using log4net.ObjectRenderer;
using Newtonsoft.Json;

namespace log4net.Util.Serializer
{
    public class JsonDotNetSerializer : ISerializer, ISerializerFactory
    {

        public object Serialize(object obj)
        {
            var settings = new JsonSerializerSettings
            {
            };

            return JsonConvert.SerializeObject(obj, settings);
        }

        public ISerializer GetSerializer(object obj, RendererMap map)
        {
            return this;
        }
    }
}