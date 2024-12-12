using DVLD_DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DVLD_BL
{
    public class ClsBL_User
    {
        [Flags]
        public enum EnPermissions
        {
            None = 0,

            // Applications Menu
            ApplicationsMenu = 1 << 0,
            ManageApplicationsMenu = 1 << 9,
            ManageApplicationTypes = 1 << 16,

            // Driving Licenses Services Menu
            DrivingLicensesServicesMenu = 1 << 1,
            NewDrivingLicense = 1 << 2,
            AddNewLocalLicenseApplication = 1 << 3,
            IssueInternationalLicense = 1 << 4,
            RenewLocalLicense = 1 << 5,
            ReplacementLicense = 1 << 6,
            RetakeTest = 1 << 7,
            PersonLicenseHistory = 1 << 8,
            
            // Manage LDL Applications
            ManageLocalDrivingLicenseApplications = 1 << 10,
            EditLDLApplication = 1 << 11,
            DeleteLDLApplication = 1 << 12,
            CancelLDLApplication = 1 << 13,
            SchedulingTests = 1 << 14,
            IssueLocalLicense = 1 << 15,

            // Manage International License
            ManageInternationalLicense = 1 << 16,

            // Detain Licenses Menu
            DetainLicensesMenu = 1 << 17,
            ManageDetainLicenses = 1 << 18,
            DetainLicense = 1 << 19,
            ReleaseDetainedLicense = 1 << 20,

            // Test Types
            ManageTestTypes = 1 << 21,

            // People Menu
            PeopleMenu = 1 << 22,
            AddPerson = 1 << 23,
            EditPerson = 1 << 24,
            DeletePerson = 1 << 25,

            // Users Menu
            UsersMenu = 1 << 26,
            AddUser = 1 << 27,
            EditUser = 1 << 28,
            DeleteUser = 1 << 29,
            ChangePasswords = 1 << 30,

            // Manage Drivers
            ManageDrivers = 1 << 31,

            // Full Control
            FullControl = -1
        }
        enum EnMode { Add, Update };
        EnMode enMode;
        public int UserID { get; private set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public EnPermissions Permissions { get; set; }
        public bool IsActive { get; set; }
        public ClsBL_Person PersonInfo { get; private set; }

        public ClsBL_User()
        {
            enMode = EnMode.Add;
            UserID = -1;
            PersonID = -1;
            UserName = string.Empty;
            Password = string.Empty;
            Permissions = EnPermissions.None;
            IsActive = false;
        }

        private ClsBL_User(int userID, int personID, string userName, string password, EnPermissions permissions , bool isActive)
        {
            enMode = EnMode.Update;
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            Permissions = permissions;
            IsActive = isActive;

            //PersonInfo = ClsBL_Person.Find(PersonID).Result;

        }

        private static async Task<ClsBL_User> CreateAsync(int userID, int personID, string userName, string password, EnPermissions permissions, bool isActive)
        {
            ClsBL_User user = new ClsBL_User(userID, personID, userName, password, permissions, isActive)
            {
                PersonInfo = await ClsBL_Person.Find(personID).ConfigureAwait(false)
            };

            return user;
        }

        public Dictionary<EnPermissions, bool> GetPermissionsStatus()
        {
            Dictionary<EnPermissions, bool> permissionsStatus = new Dictionary<EnPermissions, bool>();

            Array allPermissionTypes = Enum.GetValues(typeof(EnPermissions));

            foreach (EnPermissions permission in allPermissionTypes)
            {
                if (permission != EnPermissions.None)
                    permissionsStatus[permission] = Permissions.HasFlag(permission);
            }

            return permissionsStatus;
        }
    
        public static async Task<ClsBL_User> Find(int userID)
        {
            ClsDA_Users.Data user = await ClsDA_Users.GetUserByID(userID).ConfigureAwait(false);

            if (user != null & user.IsFound)
            {
                return await CreateAsync(userID, user.PersonID, user.UserName, user.Password,
                    (EnPermissions)user.Permissions, user.IsActive).ConfigureAwait(false);
            }
            else return null;
        }

        public static async Task<ClsBL_User> FindByPersonID(int personID)
        {
            ClsDA_Users.Data user = await ClsDA_Users.GetUserByPersonID(personID).ConfigureAwait(false);

            if (user != null && user.IsFound)
            {
                return await CreateAsync(user.UserID, personID, user.UserName, user.Password,
                    (EnPermissions)user.Permissions, user.IsActive).ConfigureAwait(false);
            }
            else return null;
        }

        public static async Task<ClsBL_User> FindByUsernameAndPassword(string userName, string password)
        {
            // Check if password not Encrypted :
            if (!IsHashed(password)) return null;

            ClsDA_Users.Data user = await ClsDA_Users.GetUserByUsernameAndPassword(userName, password).ConfigureAwait(false);

            if (user != null && user.IsFound)
            {
                return await CreateAsync(user.UserID, user.PersonID, userName, password,
                    (EnPermissions)user.Permissions, user.IsActive).ConfigureAwait(false);
            }
            else return null;
        }

        private static bool IsHashed(string password)
        {
            return password.Length == 64;
        }

        public static async Task<bool> IsExistByUserID(int userID)
        {
            return await ClsDA_Users.IsUserExistByUserID(userID);
        }

        public static async Task<bool> IsExistByPersonID(int PersonID)
        {
            return await ClsDA_Users.IsUserExistByPersonID(PersonID);
        }

        public static async Task<DataTable> Load()
        {
            return await ClsDA_Users.GetAllUsers();
        }

        private async Task<bool> _Add()
        {
            UserID = await ClsDA_Users.AddNewUser(PersonID, UserName, Password, (int)Permissions, IsActive).ConfigureAwait(false);
            return (UserID != -1);
        }

        private async Task<bool> _Update()
        {
            return await ClsDA_Users.UpdateUser(UserID, PersonID, UserName, Password, (int)Permissions, IsActive).ConfigureAwait(false);
        }

        public async Task<bool> Delete()
        {
            return await ClsDA_Users.DeleteUser(UserID).ConfigureAwait(false);
        }

        public static async Task<bool> Delete(int userID)
        {
            return await ClsDA_Users.DeleteUser(userID);
        }

        public async Task<bool> Save()
        {
            switch (enMode)
            {
                case EnMode.Add:
                    if (await _Add())
                    {
                        enMode = EnMode.Update;
                        return true;
                    }
                    else return false;

                case EnMode.Update:
                    return await _Update();

            }

            return false;
        }

        public static async Task<int> FindUserIDByUsername(string username)
        {
            return await ClsDA_Users.GetUserIDByUsername(username);
        }

        public static async Task<string> FindUserNameByUserID(int userID)
        {
            return await ClsDA_Users.GetUsernameByUserID(userID);
        }

        public static async Task<bool> IsUsernameExist(string username)
        {
            return await ClsDA_Users.IsUsernameExist(username);
        }
    }
}
