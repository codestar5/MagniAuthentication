using MagniAuthentication.MagniBaseAuthentication.Interface;
using MagniAuthentication.MagniBaseAuthentication.Models;
using Microsoft.EntityFrameworkCore;

namespace MagniAuthentication.MagniBaseAuthentication.Repository
{
    public class UserRepository : IUser
    {
        readonly DatabaseContext _dbContext = new();

        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserInfo> GetUserInfoDetails()
        {
            try
            {
                return _dbContext.UserInfos.ToList();
            }
            catch
            {
                throw;
            }
        }

        public UserInfo GetUserInfoDetails(int id)
        {
            try
            {
                UserInfo? UserInfo = _dbContext.UserInfos.Find(id);
                if (UserInfo != null)
                {
                    return UserInfo;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddUserInfo(UserInfo UserInfo)
        {
            try
            {
                _dbContext.UserInfos.Add(UserInfo);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateUserInfo(UserInfo UserInfo)
        {
            try
            {
                _dbContext.Entry(UserInfo).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public UserInfo DeleteUserInfo(int id)
        {
            try
            {
                UserInfo? UserInfo = _dbContext.UserInfos.Find(id);

                if (UserInfo != null)
                {
                    _dbContext.UserInfos.Remove(UserInfo);
                    _dbContext.SaveChanges();
                    return UserInfo;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckUserInfo(int id)
        {
            return _dbContext.UserInfos.Any(e => e.UserId == id);
        }
    }
}
