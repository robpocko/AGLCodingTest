using System.Collections.Generic;
using System.Threading.Tasks;
using AGLTest.HttpConnect;
using AGLTest.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AGLTest.UnitTests
{
	[TestClass]
	public class HttpConnectTests
	{
		private const string URL = "http://agl-developer-test.azurewebsites.net/people.json";

		[TestMethod]
		public async Task TestMethod1()
		{
			List<PersonAPI> people = await PeopleConnector.Fetch(URL);
			Assert.AreEqual(6, people.Count);
		}
	}
}
