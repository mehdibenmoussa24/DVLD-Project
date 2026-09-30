using System;
using System.Collections.Generic;
using System.Data;
using DVLD.DataAccess;

namespace DVLD.Business
{
    public class User
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { set; get; }
        public int PersonID { set; get; }
        public Person PersonInfo;
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }

        public User()

        {
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;
            Mode = enMode.AddNew;
        }

        private User(int UserID, int PersonID, string Username, string Password,
            bool IsActive)

        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = Person.Find(PersonID);
            this.UserName = Username;
            this.Password = Password;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            //call DataAccess Layer 

            this.UserID = UserData.AddNewUser(this.PersonID, this.UserName,
                this.Password, this.IsActive);

            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        {
            //call DataAccess Layer 

            return UserData.UpdateUser(this.UserID, this.PersonID, this.UserName,
                this.Password, this.IsActive);
        }
        public static User FindByUserID(int UserID)
        {
            int PersonID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = UserData.GetUserInfoByUserID
                                (UserID, ref PersonID, ref UserName, ref Password, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new User(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }
        public static User FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = UserData.GetUserInfoByPersonID
                                (PersonID, ref UserID, ref UserName, ref Password, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new User(UserID, UserID, UserName, Password, IsActive);
            else
                return null;
        }
        public static User FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;

            bool IsActive = false;

            bool IsFound = UserData.GetUserInfoByUsernameAndPassword
                                (UserName, Password, ref UserID, ref PersonID, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new User(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }

            return false;
        }

        public static DataTable GetAllUsers()
        {
            return UserData.GetAllUsers();
        }

        public static bool DeleteUser(int UserID)
        {
            return UserData.DeleteUser(UserID);
        }

        public static bool isUserExist(int UserID)
        {
            return UserData.IsUserExist(UserID);
        }

        public static bool isUserExist(string UserName)
        {
            return UserData.IsUserExist(UserName);
        }

        public static bool isUserExistForPersonID(int PersonID)
        {
            return UserData.IsUserExistForPersonID(PersonID);
        }
    }
}
