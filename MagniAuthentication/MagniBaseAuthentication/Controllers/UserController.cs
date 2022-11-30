using MagniAuthentication.MagniBaseAuthentication.Interface;
using MagniAuthentication.MagniBaseAuthentication.Models;
using MagniAuthentication.MagniBaseAuthentication.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagniAuthentication.MagniBaseAuthentication.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _IUser;

        public UserController(IUser IUser)
        {
            _IUser = IUser;
        }

        // GET: api/user>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfo>>> Get()
        {
            return await Task.FromResult(_IUser.GetUserInfoDetails());
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> Get(int id)
        {
            var UserInfos = await Task.FromResult(_IUser.GetUserInfoDetails(id));
            if (UserInfos == null)
            {
                return NotFound();
            }
            return UserInfos;
        }

        // POST api/user
        [HttpPost]
        public async Task<ActionResult<UserInfo>> Post(UserInfo UserInfo)
        {
            _IUser.AddUserInfo(UserInfo);
            return await Task.FromResult(UserInfo);
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserInfo>> Put(int id, UserInfo UserInfo)
        {
            if (id != UserInfo.UserId)
            {
                return BadRequest();
            }
            try
            {
                _IUser.UpdateUserInfo(UserInfo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(UserInfo);
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserInfo>> Delete(int id)
        {
            var UserInfo = _IUser.DeleteUserInfo(id);
            return await Task.FromResult(UserInfo);
        }

        private bool UserInfoExists(int id)
        {
            return _IUser.CheckUserInfo(id);
        }
    }
}
