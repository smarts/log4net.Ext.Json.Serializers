using System.IO;
using log4net.ObjectRenderer;
using log4net.Util.Serializer;

namespace Newtonsoft.Json.Serialization
{
    public class RendererMapJsonTextWriter : JsonTextWriter
    {
        private readonly RendererMap rendererMap;

        private readonly TextWriter textWriter;

        public RendererMapJsonTextWriter(RendererMap rendererMap, TextWriter textWriter) :
            base(textWriter)
        {
            this.textWriter = textWriter;

            this.rendererMap = rendererMap;
        }

        public override void WriteValue(object value)
        {
            if (value == null)
            {
                base.WriteValue(value);
            }
            else
            {
                var renderer = this.rendererMap.Get(value);

                if (renderer == null)
                {
                    base.WriteValue(value);
                }
                else
                {
                    Render(value, renderer);
                }
            }
        }

        private void Render(object value, IObjectRenderer renderer)
        {
            var serializer = renderer as ISerializer;

            if (serializer == null)
            {
                renderer.RenderObject(this.rendererMap, value, this.textWriter);
            }
            else
            {
                Serialize(value, serializer);
            }
        }

        private void Serialize(object value, ISerializer serializer)
        {
            this.textWriter.Write(serializer.Serialize(value));
        }
    }
}
