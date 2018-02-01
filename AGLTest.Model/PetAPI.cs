using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace AGLTest.Model
{
	[DataContract]
    public class PetAPI
    {
		[DataMember]
		public string name { get; set; }

		[DataMember]
		public string type { get; set; }

		internal string ToJson()
		{
			using (MemoryStream stream = new MemoryStream())
			{
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PetAPI));

				serializer.WriteObject(stream, this);

				stream.Position = 0;

				StreamReader sr = new StreamReader(stream);

				return sr.ReadToEnd();
			}
		}
	}
}
