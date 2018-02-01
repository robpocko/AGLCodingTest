namespace AGLTest.Model.Lists
{
	public class PersonPetListItem
    {
		public string Gender { get; set; }
		public string PetName { get; set; }

		public override string ToString()
		{
			return $"{Gender} : {PetName}";
		}
	}
}
