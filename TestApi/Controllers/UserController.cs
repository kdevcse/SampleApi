using Microsoft.AspNetCore.Mvc;
using TestApi.Entities;
using TestApi.Helpers;
using TestApi.Models;
using TestApi.Services;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<GetUserResponse> GetUser(int userId)
        {
            var response = new GetUserResponse();

            try
            {
                var user = _userService.GetUser(userId);

                if (user == null)
                {
                    return ApiLoggerHelper.LogError<GetUserResponse>(_logger, $"Could not find user with id: {userId}", "UserController\\GetUser");
                }

                response.User = user;
                response.StatusCode = StatusCodes.Status200OK;
                response.Success = true;
            } catch (Exception ex)
            {
                response = ApiLoggerHelper.LogError<GetUserResponse>(_logger, $"Exception {ex.Message}", "UserController\\GetUser");
            }

            return response;
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<CrudUserResponse> CreateUser(User user)
        {
            try {
                var createdUserId = _userService.CreateUser(user);


                if (createdUserId == null)
                {
                    return ApiLoggerHelper.LogError<CrudUserResponse>(_logger, "Error creating user", "UserController\\CreateUser");
                }

                return new CrudUserResponse
                {
                    Id = createdUserId.Value,
                    StatusCode = StatusCodes.Status200OK,
                    Success = true,
                };
            }
            catch (Exception ex) {
                return ApiLoggerHelper.LogError<CrudUserResponse>(_logger, $"Exception {ex.Message}", "UserController\\CreateUser");
            }
        }

        [HttpPut]
        public async Task<CrudUserResponse> UpdateUser(User modifiedUser)
        {
            try
            {
                var updatedUserId = _userService.UpdateUser(modifiedUser);

                if (updatedUserId == null)
                {
                    return ApiLoggerHelper.LogError<CrudUserResponse>(_logger, $"Error updating user with ID: {modifiedUser.Id}", "UserController\\UpdateUser");
                }

                return new CrudUserResponse
                {
                    Id = updatedUserId.Value,
                    StatusCode = StatusCodes.Status200OK,
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                return ApiLoggerHelper.LogError<CrudUserResponse>(_logger, $"Exception {ex.Message}", "UserController\\UpdateUser");
            }
        }

        [HttpDelete(Name = "DeleteUser")]
        public async Task<CrudUserResponse> DeleteUser(int userId)
        {
            try
            {
                var deletedUserId = _userService.DeleteUser(userId);

                if (deletedUserId == null)
                {
                    return ApiLoggerHelper.LogError<CrudUserResponse>(_logger, $"Error deleting user with ID: {userId}", "UserController\\DeleteUser");
                }

                return new CrudUserResponse
                {
                    Id = deletedUserId.Value,
                    StatusCode = StatusCodes.Status200OK,
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                return ApiLoggerHelper.LogError<CrudUserResponse>(_logger, $"Exception {ex.Message}", "UserController\\DeleteUser");
            }
        }
    }
}
