using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using V50_IDOMBackOffice.PlugIn.Controller;
using IdomOffice.Interface.BackOffice.Users;

namespace V50_IDOMBackOffice.Account
{
    public class QMembershipProvider : MembershipProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordReset
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                return 0;
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                return 6;
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                return  MembershipPasswordFormat.Clear;
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            if (GetUser(username, false) != null)
            {
                status = MembershipCreateStatus.DuplicateUserName;
                return null;
            }

            var userManager = PlugInManager.GetUserManager();


            QApplikationUser au = new QApplikationUser();
            au.Id = Guid.NewGuid().ToString();
            au.Username = username;
            au.Password = password;
            au.Email = email;
            au.PasswordQuestion = passwordQuestion;
            au.PasswordAnswer = passwordAnswer;
            au.IsApproved = isApproved;
            au.ProviderUserKey = providerUserKey == null ? Guid.NewGuid().ToString() : providerUserKey.ToString();
            userManager.AddUser(au);
            //TODO : Ovo je samo glavni status treba vidjeti da li treba jos koji status programirati
            status = MembershipCreateStatus.Success;
            return GetUser(username, false);



        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            var userManager = PlugInManager.GetUserManager();
            var abUser = userManager.GetUser(username);
            if (abUser == null)
                return null;

            var msu = new MembershipUser(this.Name, username, abUser.ProviderUserKey, abUser.Email, abUser.PasswordQuestion, "", abUser.IsApproved, abUser.IsLockedOut,
                                          abUser.CreationDate, abUser.LastLoginDate, abUser.LastActivityDate, abUser.LastPasswordChangedDate, abUser.LastLockoutDate);
            return msu;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            var userManager = PlugInManager.GetUserManager();
            var adriabookUser = userManager.GetUser(username);
            if (adriabookUser == null)
                return false;

            return adriabookUser.Password == password;
        }
    }
}