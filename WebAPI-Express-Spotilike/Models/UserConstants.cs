namespace WebAPI_Express_Spotilike.Models
{
    public class UserConstants
    {
        public static List<UserItem> Users = new List<UserItem>()
        {
            new UserItem() { NomUtilisateur = "jason_admin", Email = "jason.admin@email.com", Password = "MyPass_w0rd"},
            new UserItem() { NomUtilisateur = "elyse_seller", Email = "elyse.seller@email.com", Password = "MyPass_w0rd"},
        };
    }
}
