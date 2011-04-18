using System.IO;
using System.Xml.Serialization;

namespace SimulaCircuit
{
    public class XmlSerializable<T>
    {
        private static XmlSerializer xmls = new XmlSerializer(typeof(T));

        public void Serialise(string file)
        {
            using(Stream fs = File.Create(file))
                xmls.Serialize(fs, this);
        }

        public static T Deserialise(string file)
        {
            using (Stream fs = File.OpenRead(file))
                return (T)xmls.Deserialize(fs);
        }
    }
}
