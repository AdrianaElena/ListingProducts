using Products.Models;

namespace Products.Services
{
    public class SecurityService
    {
        UsersDAO usersDAO = new UsersDAO();

        public SecurityService()
        {
        }

        public bool isValid(UserModel user)
        {
            return usersDAO.FindUserByNameAndPassword(user);
        }
    }
}
