using System.IO;
using System.Text;
using log4net.ObjectRenderer;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace log4net.Util.Serializer
{
    public class JsonDotNetSerializer : ISerializer
    {
        public RendererMap Map { get; set; }

        public object Serialize(object obj)
        {
            object result;

            if (obj != null)
            {
                using (var writer = new StringWriter(new StringBuilder()))
                using (var jsonWriter = new RendererMapJsonTextWriter(Map, writer) { CloseOutput = false })
                {
                    jsonWriter.WriteValue(obj);

                    result = writer.GetStringBuilder().ToString();
                }
            }
            else
            {
                result = JsonConvert.SerializeObject(obj);
            }

            return result;
        }
    }
}
