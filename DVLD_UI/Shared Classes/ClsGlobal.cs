using DVLD_BL;
using Microsoft.Win32;
using System.Collections.Generic;
using static DVLD_UI.Shared_Classes.ClsRegistryConfig;

namespace DVLD_UI
{
    internal static class ClsGlobal
    {
        private static ClsBL_User _loginUser;
        internal static ClsBL_User LoginUser
        {
            get => _loginUser;
            set
            {
                _loginUser = value;

                if (_loginUser != null) IsUserCanAccessTo = _loginUser.GetPermissionsStatus();
            }
        }
        internal static Dictionary<ClsBL_User.EnPermissions, bool> IsUserCanAccessTo { get; private set; }

        internal static void StoreUserData(bool isRemember, string username, string password)
        {
            if (isRemember)
                //store username and password on Windows Registry
                RememberUserV2(username, password);
            else
                //store empty username and password on Windows Registry
                ResetUserV2();
        }

        private static void RememberUserV2(string usernameValue, string passwordValue)
        {
            Registry.SetValue(DefaultAppKeyName, RememberValueName, 1);
            Registry.SetValue(DefaultAppKeyName, UsernameValueName, usernameValue);
            Registry.SetValue(DefaultAppKeyName, PasswordValueName, passwordValue);
        }

        private static void ResetUserV2()
        {
            Registry.SetValue(DefaultAppKeyName, RememberValueName, 0);
            Registry.SetValue(DefaultAppKeyName, UsernameValueName, string.Empty);
            Registry.SetValue(DefaultAppKeyName, PasswordValueName, string.Empty);
        }

        internal static bool IsRememberMe()
        {
            object obj = Registry.GetValue(DefaultAppKeyName, RememberValueName, 0);

            if (obj != null && int.TryParse(obj.ToString(), out int result))
            {
                return result > 0;
            }

            return false;
        }

        internal static string GetUsernameValue()
        {
            return Registry.GetValue(DefaultAppKeyName, UsernameValueName, null) as string;
        }

        internal static string GetPasswordValue()
        {
            return Registry.GetValue(DefaultAppKeyName, PasswordValueName, null) as string;
        }

        //private static void RememberUser(string username, string password)
        //{
        //    Settings.Default.IsRememberMe = true;
        //    Settings.Default.Username = username;
        //    Settings.Default.Password = password;
        //    Settings.Default.Save();
        //}

        //private static void ResetUser()
        //{
        //    Settings.Default.IsRememberMe = false;
        //    Settings.Default.Username = default;
        //    Settings.Default.Password = default;
        //    Settings.Default.Save();
        //}
    }
}
