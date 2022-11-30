using MagniAuthentication.MagniBaseAuthentication.Models;

namespace MagniAuthentication.MagniBaseAuthentication.Interface
{
    public interface IUser
    {
        public List<UserInfo> GetUserInfoDetails();
        public UserInfo GetUserInfoDetails(int id);
        public void AddUserInfo(UserInfo userinfo);
        public void UpdateUserInfo(UserInfo userinfo);
        public UserInfo DeleteUserInfo(int id);
        public bool CheckUserInfo(int id);
    }
}
