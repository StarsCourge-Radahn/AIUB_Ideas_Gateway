using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    internal class OtpRepo : DataRepository, IOTP<OTP, int, bool,User>
    {
        public bool Check(OTP obj)
        {

            var otpFromDb = _context.OTPs.SingleOrDefault(o => o.UserID == obj.UserID && o.OTPName == obj.OTPName);

            if (otpFromDb != null && !otpFromDb.IsUsed && otpFromDb.ExpirationTime >= obj.ExpirationTime)
            {
                otpFromDb.IsUsed = true;
                _context.SaveChanges();
                return true; // OTP is valid
            }

            return false; // OTP is not valid
        }

        public bool Create(OTP obj)
        {
            try
            {
                // Add the OTP object to the context
                _context.OTPs.Add(obj);

                // Save changes to the database
                int rowsAffected = _context.SaveChanges();

                // If at least one row was affected, consider it a success
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                // Handle exceptions, e.g., database connection issues
                return false;
            }
        }

        public bool Update(User obj)
        {
            try
            {
                
                var userToUpdate = _context.Users.SingleOrDefault(u => u.UserID == obj.UserID);

                if (userToUpdate != null)
                {
                    
                    userToUpdate.Password = obj.Password;

                    _context.SaveChanges();

                    return true; 
                }

                return false; // User not found
            }
            catch
            { 
                return false;
            }
        }
    }
}
