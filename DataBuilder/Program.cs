using System.Xml;

namespace DataBuilder
{
    class Program
    {
        private const int NUMBER_OF_ITEMS = 4;

        static void Main(string[] args)
        {
            Data.BaseEquipment[] baseClasses = new Data.BaseEquipment[NUMBER_OF_ITEMS];

            for(int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                baseClasses[i] = new Data.BaseEquipment();
            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create("baseEquipments.xml", settings))
            {
                Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate.IntermediateSerializer.Serialize(writer, baseClasses, null);
            }
        }
    }
}
