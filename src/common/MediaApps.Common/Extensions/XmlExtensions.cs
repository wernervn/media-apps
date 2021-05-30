using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MediaApps.Common.Extensions
{
    /// <summary>
    /// Xml extension methods
    /// </summary>
    public static class XmlExtensions
    {
        /// <summary>
        /// Default encoding - a UTF-8 encoder without BOM
        /// </summary>
        public static readonly Encoding DefaultEncoding = new UTF8Encoding(false);

        /// <summary>
        /// Strip out the auto-generated namespaces
        /// </summary>
        private static readonly XmlSerializerNamespaces Namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

        /// <summary>
        /// Converts an object to its Xml representation
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">Object to be serialized</param>
        /// <returns>String containing xml representation of object</returns>
        public static string ToXml<T>(this T obj) where T : new() => obj.ToXml(DefaultEncoding);

        /// <summary>
        /// Converts an object to its Xml representation
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">Object to be serialized</param>
        /// <param name="settings">Serialization settings to be used</param>
        /// <returns>String containing xml representation of object</returns>
        public static string ToXml<T>(this T obj, XmlWriterSettings settings) where T : new()
        {
            string xml;

            using (var memoryStream = new MemoryStream())
            using (var xmlWriter = XmlWriter.Create(memoryStream, settings))
            {
                var x = new XmlSerializer(obj.GetType());
                x.Serialize(xmlWriter, obj, Namespaces);

                memoryStream.Position = 0; // rewind the stream before reading back.

                var sr = new StreamReader(memoryStream);
                xml = sr.ReadToEnd();
            }
            return xml;
        }

        /// <summary>
        /// Converts an object to its Xml representation
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">Object to be serialized</param>
        /// <param name="encoding">Encoding to be used</param>
        /// <returns>String containing xml representation of object</returns>
        public static string ToXml<T>(this T obj, Encoding encoding) where T : new()
        {
            var settings = new XmlWriterSettings { Encoding = encoding, OmitXmlDeclaration = true };
            return obj.ToXml(settings);
        }

        /// <summary>
        /// Deserialize an object
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="data">Xml representation of object</param>
        /// <returns>Object generated from xml</returns>
        public static T FromXml<T>(this string data) where T : new()
        {
            var s = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(data.StripUtf8Bom()))
            {
                return (T)s.Deserialize(reader);
            }
        }

        /// <summary>
        /// Strips namespaces from an Xml Document
        /// </summary>
        /// <param name="document"></param>
        public static void StripNamespace(this XDocument document)
        {
            if (document.Root is null)
            {
                return;
            }

            foreach (var element in document.Root.DescendantsAndSelf())
            {
                element.Name = element.Name.LocalName;
                element.ReplaceAttributes(GetAttributesWithoutNamespace(element));
            }
        }

        private static IEnumerable GetAttributesWithoutNamespace(XElement xElement)
        {
            return xElement.Attributes()
                .Where(x => !x.IsNamespaceDeclaration)
                .Select(x => new XAttribute(x.Name.LocalName, x.Value));
        }
    }

}
