using System;
using System.Collections.Generic;
using System.Linq;
using AGLTest.Model;
using AGLTest.Model.Lists;

namespace AGLTest.BusFacade
{
    public class PetBF
    {
		public static List<PersonPetListItem> GetPetsByGender(List<PersonAPI> people, string animalType)
		{
			if (people == null)
			{
				return null;
			}
			else
			{
				var pets = people
					.Where(x => x.pets != null)
					.SelectMany(
					x => x.pets
					.Where(y => y.type == animalType)
					.Select(y => new PersonPetListItem
					{
						Gender = x.gender,
						PetName = y.name
					})
					).ToList();

				return pets.OrderBy(p => p.Gender).ThenBy(p => p.PetName).ToList();
			}
		}
    }
}
