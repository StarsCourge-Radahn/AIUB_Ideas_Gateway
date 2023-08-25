using AutoMapper;
using BLL.DTOs;
using DLL;
using DLL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserServices
    {
        public static bool CreateUser(string name, string username, string email, string pass)
        {
            var ue = DataAccessFactory.AuthDataAccess().GetByEmail(email);
            var uu = DataAccessFactory.AuthDataAccess().GetByUsername(username);

            if (ue != null && uu != null)
            {
                return false;
            }

            var userdto = new UserDTO
            {
                Name = name,
                UserName = username,
                Email = email,
                Password = pass,
                IsBan = false,
                IsDeleted = false
            };
            var mapper = MappingService<UserDTO, User>.GetMapper();

            var user = mapper.Map<User>(userdto);
            var userCreated = DataAccessFactory.UserDataAccess().Create(user);

            var createdUser = GetUserName(username);

            if (createdUser != null)
            {
                int userId = createdUser.UserID;
                var createCv = CvServices.CreateCV(userId);
                if (createCv)
                {
                    return userCreated == true;
                }
            }
            return false;
        }

        public static UserDTO GetUserName(string userName)
        {
            var user = DataAccessFactory.AuthDataAccess().GetByUsername(userName);
            //var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserDTO>(); });
            var mapper = MappingService<User, UserDTO>.GetMapper();
            var rtn = mapper.Map<UserDTO>(user);
            return rtn;
        }
        public static List<UserDTO> GetUsers()
        {
            var users = DataAccessFactory.UserDataAccess().GetAll(true);

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<User, UserDTO>();
            //});

            var mapper = MappingService<User, UserDTO>.GetMapper();
            var rtn = mapper.Map<List<UserDTO>>(users);

            return rtn;
        }

        public static UserDTO GetUser(int id)
        {
            var user = DataAccessFactory.UserDataAccess().GetByID(id);
            //var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserDTO>(); });
            var mapper = MappingService<User, UserDTO>.GetMapper();
            var rtn = mapper.Map<UserDTO>(user);
            return rtn;
        }

        public static bool UpdateUser(UserDTO obj)
        {
            var user = DataAccessFactory.UserDataAccess().GetByID(obj.UserID);
            if (user != null)
            {
                user.Name = obj.Name;
                user.Password = obj.Password;
                user.Email = obj.Email;
                user.IsDeleted = obj.IsDeleted;
                user.IsBan = obj.IsBan;
                user.TemporaryBan = obj.TemporaryBan;

                var rtn = DataAccessFactory.UserDataAccess().Update(user);
                return rtn == true;
            }
            return false;
        }

        public static bool DeleteUser(int id)
        {
            var rtn = DataAccessFactory.UserDataAccess().Delete(id);
            return rtn;
        }
        public static int CurrentlyActiveUsers()
        {
            var cnt = DataAccessFactory.ActiveUsersDataAccess().ActiveAll();
            return cnt.Count();
        }

        public static int AllBanUses()
        {
            var banUsers = DataAccessFactory.UserStaticalDataAccess().AllBan();
            return banUsers.Count();
        }

        public static OTPDTO GetByEmail(string email)
        {
            var user = DataAccessFactory.AuthDataAccess().GetByEmail(email);

            if (user == null)
            {
                return null;
            }

            var mapper = MappingService<User, UserDTO>.GetMapper();
            var rtn = mapper.Map<UserDTO>(user);

            var otpChars = "0123456789";
            var random = new Random();
            var otp = new string(Enumerable.Repeat(otpChars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            var obj = new OTPDTO
            {
                OTPName = otp,
                ExpirationTime = DateTime.Now.AddMinutes(15),
                IsUsed = false,
                UserID = user.UserID
            };

            var otpMapper = MappingService<OTPDTO, OTP>.GetMapper();

            var _otp = otpMapper.Map<OTP>(obj);
            var success = DataAccessFactory.OtpDataAccess().Create(_otp);

            // Return the OTP object if created successfully
            if (success)
            {
                return obj;
            }
            return null;
        }

        public static bool GetValidOTP(string OTP,int UserId)
        {
            var otpDTO = new OTPDTO
            {
                OTPName = OTP,
                UserID = UserId,
                IsUsed = false,
                ExpirationTime = DateTime.Now
            };


            var otp = MappingService<OTPDTO, OTP>.GetMapper().Map<OTP>(otpDTO);

            // Pass the created OTP object to your data access method for validation
            var isValid = DataAccessFactory.OtpDataAccess().Check(otp);

            return isValid;
        }

        public static bool ChangePassword(string password, int UserId)
        {
            var user = new UserDTO
            {
                UserID = UserId,
                Password = password
            };
            var otp = MappingService<UserDTO, User>.GetMapper().Map<User>(user);

            // Pass the created User object to your data access method for validation
            var isValid = DataAccessFactory.OtpDataAccess().Update(otp);

            return isValid;
        }

        
        public static bool ChangePassword(ChangePasswordDTO changePasswordDTO)
        {

            // Validate the provided password change data
            if (string.IsNullOrWhiteSpace(changePasswordDTO.OldPassword) ||
                string.IsNullOrWhiteSpace(changePasswordDTO.NewPassword) ||
                string.IsNullOrWhiteSpace(changePasswordDTO.ConfirmPassword) ||
                !changePasswordDTO.NewPassword.Equals(changePasswordDTO.ConfirmPassword))
            {
                return false;
            }
              
            var user = DataAccessFactory.UserDataAccess().GetByID(changePasswordDTO.UserId);
            if (user == null)
            {
                return false; 
            }

            if(user.Password == changePasswordDTO.OldPassword)
            {
                user.Password =changePasswordDTO.NewPassword;

                bool passwordUpdatedSuccessfully = DataAccessFactory.UserDataAccess().Update(user);

                if (passwordUpdatedSuccessfully)
                {
                    return true;
                }
            }
          
            return false; // Password change failed
        }
        


    }
}
