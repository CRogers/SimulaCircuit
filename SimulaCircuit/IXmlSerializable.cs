using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SimulaCircuit
{
    public interface IXmlSerializable<T>
    {
    }

    public static class IXmlSerializableExtensions
    {
        private static Dictionary<Type,XmlSerializer> xmls = new Dictionary<Type, XmlSerializer>();

        public static void Serialise<T>(this IXmlSerializable<T> ixmls, string file)
        {
            using (Stream fs = File.Create(file))
                MakeXmls<T>().Serialize(fs, ixmls);
        }

        public static T Deserialise<T>(this IXmlSerializable<T> ixmls, string file)
        {
            using (Stream fs = File.OpenRead(file))
                return (T)MakeXmls<T>().Deserialize(fs);
        }

        private static XmlSerializer MakeXmls<T>()
        {
            var t = typeof (T);

            if(xmls == null)
                return xmls[t] = new XmlSerializer(t);

            return xmls[t];
        }
    }
}
