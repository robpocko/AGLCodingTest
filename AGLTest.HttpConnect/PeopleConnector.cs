using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using AGLTest.Model;

namespace AGLTest.HttpConnect
{
	public class PeopleConnector
	{
		public static async Task<List<PersonAPI>> Fetch(string url)
		{
			using (HttpClient client = new HttpClient())
			{
				var response = await client.GetStringAsync(url);

				DataContractJsonSerializer js =
					new DataContractJsonSerializer(typeof(List<PersonAPI>));
				MemoryStream ms =
					new MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(response));

				return (List<PersonAPI>)js.ReadObject(ms);
			}
		}
	}
}
