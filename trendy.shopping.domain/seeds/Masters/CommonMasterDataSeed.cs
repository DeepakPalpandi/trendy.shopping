using trendy.shopping.domain.Entities.Master.Locations;

namespace trendy.shopping.domain.seeds.Masters
{
    public static class CommonMasterDataSeed
    {
        #region Locations

        #region Country
        public static List<Country> Countries { get; set; } = new List<Country>()
        {
            new Country
            {
                Id = new Guid("e2580151-00dc-466b-9adb-a9329b291286"),
                CountryName = "India",
                CountryCode = "india",
                Sequence = 1
            }
        };
        #endregion

        #region State
        public static List<State> State { get; set; } = new List<State>
        {
            new State
            {
                Id = new Guid("572c4811-9f27-4bdf-bc2a-ab89b3bfb1f6"),
                CountryId = new Guid("e2580151-00dc-466b-9adb-a9329b291286"),
                StateName = "TamilNadu",
                StateCode = "tamil_nadu",
                Sequence = 1
            }
        };
        #endregion

        #region City
        public static List<City> City { get; set; } = new List<City>
        {
            new City
            {
                Id = new Guid ("e0c26a51-536f-4259-8377-f41916fe1f9a"),
                StateId = new Guid("572c4811-9f27-4bdf-bc2a-ab89b3bfb1f6"),
                CityName ="Chennai",
                CityCode = "chennai",
                Sequence = 1
            },
            new City
            {
                Id = new Guid ("8c4e2369-534f-44ae-a201-f40f14ced860"),
                StateId = new Guid("572c4811-9f27-4bdf-bc2a-ab89b3bfb1f6"),
                CityName ="Maduari",
                CityCode = "madurai",
                Sequence = 2
            }
        };
        #endregion

        #endregion
    }
}
