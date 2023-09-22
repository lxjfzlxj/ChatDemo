using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CommonPlace.Tools
{
	public class SerializeTool
	{
		public static string ToSerialize<T>(T obj)
		{
			StringWriter sw = new StringWriter();
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			serializer.Serialize(sw, obj);
			string objString = sw.ToString();
			return objString;
		}
		public static T ToDeserialize<T>(string objString)
		{
			T obj;
			using (StringReader sr = new StringReader(objString))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(T));
				obj = (T)serializer.Deserialize(sr);
			}
			return obj;
		}
	}
}
