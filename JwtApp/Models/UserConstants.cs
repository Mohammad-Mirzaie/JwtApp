namespace JwtApp.Models
{
    public class UserConstants
    {

        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel{ 
                Username="mhd.mirzaie", 
                Password="mypass@2022", 
                EmailAddress="mohammad.mirzaie2022@gmail.com",
                Role="Administrator",
                SureName="Mohammad",
                GivenName="Mirzaie"
            },
            new UserModel{
                Username="sediqa.moradi",
                Password="mypass@2022",
                EmailAddress="sediqa.moradi@gmail.com",
                Role="Seller",
                SureName="Sediqa",
                GivenName="Moradi"
            }
        };
     }
}
