using System.Collections.Generic;
using AGLTest.BusFacade;
using AGLTest.Model;
using AGLTest.Model.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AGLTest.UnitTests
{
	[TestClass]
	public class BusFacaceTests
	{
		[TestMethod]
		public void TestMethod1()
		{
			List<PersonPetListItem> pets = PetBF.GetPetsByGender(ConstructSet1(), "Cat");
			Assert.AreEqual(3, pets.Count);
			Assert.AreEqual("Charlie", pets[0].PetName);
			Assert.AreEqual("Clara", pets[1].PetName);
			Assert.AreEqual("Slinky", pets[2].PetName);
			Assert.AreEqual("Male", pets[0].Gender);
			Assert.AreEqual("Male", pets[1].Gender);
			Assert.AreEqual("Male", pets[2].Gender);

			pets = PetBF.GetPetsByGender(ConstructSet1(), "Dog");
			Assert.AreEqual(1, pets.Count);
			Assert.AreEqual("Poppy", pets[0].PetName);
			Assert.AreEqual("Male", pets[0].Gender);

			pets = PetBF.GetPetsByGender(ConstructSet1(), "Fish");
			Assert.AreEqual(1, pets.Count);
			Assert.AreEqual("Nemo", pets[0].PetName);
			Assert.AreEqual("Male", pets[0].Gender);

			pets = PetBF.GetPetsByGender(ConstructSet1(), "Bird");
			Assert.IsNotNull(pets);
			Assert.AreEqual(0, pets.Count);
		}

		[TestMethod]
		public void TestMethod2()
		{
			List<PersonPetListItem> pets = PetBF.GetPetsByGender(ConstructSet2(), "Cat");
			Assert.AreEqual(4, pets.Count);
			Assert.AreEqual("Female", pets[0].Gender);
			Assert.AreEqual("Slinky", pets[0].PetName);
			Assert.AreEqual("Charlie", pets[1].PetName);
			Assert.AreEqual("Clara", pets[2].PetName);
			Assert.AreEqual("Slinky", pets[3].PetName);
			Assert.AreEqual("Male", pets[1].Gender);
			Assert.AreEqual("Male", pets[2].Gender);
			Assert.AreEqual("Male", pets[3].Gender);

			pets = PetBF.GetPetsByGender(ConstructSet2(), "Dog");
			Assert.AreEqual(2, pets.Count);
			Assert.AreEqual("Poppy", pets[0].PetName);
			Assert.AreEqual("Female", pets[0].Gender);
			Assert.AreEqual("Poppy", pets[1].PetName);
			Assert.AreEqual("Male", pets[1].Gender);

			pets = PetBF.GetPetsByGender(ConstructSet2(), "Fish");
			Assert.AreEqual(2, pets.Count);
			Assert.AreEqual("Nemo", pets[0].PetName);
			Assert.AreEqual("Female", pets[0].Gender);
			Assert.AreEqual("Nemo", pets[1].PetName);
			Assert.AreEqual("Male", pets[1].Gender);
		}

		[TestMethod]
		public void TestMethod3()
		{
			List<PersonPetListItem> pets = PetBF.GetPetsByGender(new List<PersonAPI>(), "Cat");
			Assert.IsNotNull(pets);
			Assert.AreEqual(0, pets.Count);
		}

		[TestMethod]
		public void TestMethod4() 
		{
			List<PersonAPI> pets = null;
			Assert.IsNull(PetBF.GetPetsByGender(pets, "Cat"));
		}

		private List<PersonAPI> ConstructSet1()
		{
			return new List<PersonAPI>
			{
				new PersonAPI {
					name = "Rob", gender = "Male", age = 25,
					pets = new List<PetAPI>
					{
						new PetAPI { name = "Poppy", type = "Dog"},
						new PetAPI { name = "Slinky", type = "Cat"},
						new PetAPI { name = "Charlie", type = "Cat"},
						new PetAPI { name = "Clara", type = "Cat"},
						new PetAPI { name = "Nemo", type = "Fish"}
					}
				}
			};
		}

		private List<PersonAPI> ConstructSet2()
		{
			List<PersonAPI> people = ConstructSet1();
			people.Add(new PersonAPI {
				name = "Janette", gender = "Female", age = 21,
				pets = new List<PetAPI>
					{
						new PetAPI { name = "Poppy", type = "Dog"},
						new PetAPI { name = "Slinky", type = "Cat"},
						new PetAPI { name = "Nemo", type = "Fish"}
					}
			});
			return people;
		}
	}
}
