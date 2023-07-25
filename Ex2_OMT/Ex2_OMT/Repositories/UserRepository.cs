using Ex2_OMT.Models;
using Microsoft.EntityFrameworkCore;

namespace Ex2_OMT.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IConfiguration _configuration;
        private readonly Ex2Context _context;
        public UserRepository(Ex2Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<ResponseData<Models.User>> GetAll(string? search = "", int? role = null, int page = 1)
        {
            var query = _context.Users.Where(o => o.IsDisabled == 0)
                .Where(o => o.UserName.ToLower().Trim().Contains(search.ToLower().Trim()))
                .Where(o => o.Role == role || role == null);
            var a = await query.CountAsync();
            var result = await query.Skip((page - 1) * 10).Take(10).ToListAsync();

            var pageNum = (int)Math.Ceiling((decimal)a / 10);
            if (page < 1 || page > pageNum)
            {
                return new ResponseData<User>
                {
                    mess = "Số trang vượt quá trang tối đa"
                };
            }
            return new ResponseData<Models.User>
            {
                CurrentPage = page,
                TotalPage = pageNum,
                Data = result
            };
        }

        public async Task<ApiResponse<User>> DisableUser(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(o => o.UserId == id);
            if (user != null)
            {
                user.IsDisabled = 1;
                await _context.SaveChangesAsync();
                return new ApiResponse<User>
                {
                    Data = user,
                    Message = new List<string> {
                    "Vô hiệu tài khoản thành công"
                    },
                    Status = 1
                };

            }
            else
            {
                return new ApiResponse<User>
                {
                    Message = new List<string> {
                    "Vô hiệu tài khoản thất bại"
                    },
                    Status = 0
                };
            }
        }
        public async Task<ApiResponse<User>> EnableUser(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(o => o.UserId == id);
            if (user != null)
            {
                user.IsDisabled = 0;
                await _context.SaveChangesAsync();
                return new ApiResponse<User>
                {
                    Data = user,
                    Message = new List<string> {
                    "Kích hoạt tài khoản thành công"
                    },
                    Status = 1
                };
            }
            else
            {
                return new ApiResponse<User>
                {
                    Message = new List<string> {
                    "Kích hoạt tài khoản thất bại"
                    },
                    Status = 0
                };
            }
        }

        public async Task<ApiResponse<User>> ChangePassword(PasswordDTO pass, int claim)
        {
            var user = _context.Users.SingleOrDefault(o => o.UserId == claim);
            if (user != null && user.IsDisabled != 1)
            {
                if (user.Password == pass.OldPassword)
                {
                    user.Password = pass.NewPassword;
                    await _context.SaveChangesAsync();
                    return new ApiResponse<User>
                    {
                        Data = user,
                        Message = new List<string> {
                    "Đổi mật khẩu thành công"
                    },
                        Status = 1
                    };
                }
                else
                {
                    return new ApiResponse<User>
                    {
                        Message = new List<string> {
                    "Sai mật khẩu cũ"
                    },
                        Status = 0
                    };
                }
            }
            return new ApiResponse<User>
            {
                Message = new List<string> {
                    "Đổi mật khẩu thất bại"
                    },
                Status = 0
            };
        }

        public async Task<ApiResponse<User>> Register(UserAddDTO user)
        {
            bool validate = true;
            List<string> message = new List<string>();
            if (user.UserName == null || user.UserName.Trim() == "")
            {
                message.Add("Thiếu tên đăng nhập");
                validate = false;
            }
            else if (user.Password.Trim() == "" || user.Password == null)
            {
                message.Add("Thiếu mật khẩu");
                validate = false;
            }
            if (!validate)
            {
                return new ApiResponse<User>
                {
                    Message = message,
                    Status = 0
                };
            }
            var check = await _context.Users.SingleOrDefaultAsync(o => o.UserName == user.UserName);
            if (check == null)
            {
                var addedUser = new User
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    IsDisabled = 0,
                    Role = 2,
                };
                _context.Add(addedUser);
                await _context.SaveChangesAsync();
                return new ApiResponse<User>
                {
                    Data = addedUser,
                    Message = new List<string> {
                    "Đăng kí thành công"
                    },
                    Status = 1
                };
            }
            else
            {
                return new ApiResponse<User>
                {
                    Message = new List<string> {
                    "Tên tài khoản đã tồn tại"
                    },
                    Status = 0
                };
            }
            return new ApiResponse<User>
            {
                Message = new List<string> {
                    "Đăng kí thất bại"
                    },
                Status = 0
            };
        }

        public async Task<ApiResponse<User>> CreateStaff(UserAddDTO user)
        {
            bool validate = true;
            List<string> message = new List<string>();
            if (user.UserName == null || user.UserName.Trim() == "")
            {
                message.Add("Thiếu tên đăng nhập");
                validate = false;
            }
            else if (user.Password.Trim() == "" || user.Password == null)
            {
                message.Add("Thiếu mật khẩu");
                validate = false;
            }
            if (!validate)
            {
                return new ApiResponse<User>
                {
                    Message = message,
                    Status = 0
                };
            }
            var check = await _context.Users.SingleOrDefaultAsync(o => o.UserName == user.UserName);
            if (check == null)
            {
                var addedUser = new User
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    IsDisabled = 0,
                    Role = 1,
                };
                _context.Add(addedUser);
                await _context.SaveChangesAsync();
                return new ApiResponse<User>
                {
                    Data = addedUser,
                    Message = new List<string> {
                    "Tạo admin thành công"
                    },
                    Status = 1
                };
            }
            else
            {
                return new ApiResponse<User>
                {
                    Message = new List<string> {
                    "Tên tài khoản đã tồn tại"
                    },
                    Status = 0
                };
            }
        }

        public async Task<ApiResponse<User>> GetUser(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(o => o.UserId == id);
            if (user != null)
            {
                return new ApiResponse<User>
                {
                    Data = user,
                    Status = 1
                };
            }
            else
            {
                return new ApiResponse<User>
                {
                    Message = new List<string> {
                    "Tài khoản không tồn tại"
                    },
                    Status = 0
                };
            }
        }
    }
}
