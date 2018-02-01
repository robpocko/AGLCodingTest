using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace AGLTest.Model
{
	[DataContract]
    public class PersonAPI
    {
		[DataMember]
		public string name { get; set; }

		[DataMember]
		public string gender { get; set; }

		[DataMember]
		public int age { get; set; }

		[DataMember]
		public List<PetAPI> pets { get; set; }

		internal string ToJson()
		{
			using (MemoryStream stream = new MemoryStream())
			{
				DataContractJsonSerializer serializer =	new DataContractJsonSerializer(typeof(PersonAPI));

				serializer.WriteObject(stream, this);

				stream.Position = 0;

				StreamReader sr = new StreamReader(stream);

				return sr.ReadToEnd();
			}
		}
	}
}
