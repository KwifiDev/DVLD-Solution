using DVLD_BL;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD_UI.Users.Controls
{
    public partial class UCAddEditUserPermissions : UserControl
    {
        private ClsBL_User.EnPermissions _userPermissions;

        public UCAddEditUserPermissions()
        {
            InitializeComponent();
            PopulateNodeTags(tvPermissions.Nodes);
        }

        public void LoadPermissions(ClsBL_User.EnPermissions userPermissions)
        {
            _userPermissions = userPermissions;

            LoadTreeViewData(tvPermissions.Nodes);
        }

        private void LoadTreeViewData(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = ((ClsBL_User.EnPermissions)node.Tag & _userPermissions) > 0;

                if (node.Nodes.Count > 0) LoadTreeViewData(node.Nodes);
            }
        }

        public ClsBL_User.EnPermissions GetSelectedUserPermissions()
        {
            _userPermissions = ClsBL_User.EnPermissions.None; // Reset Permissions before Selected again

            PrepareUserPermissions(tvPermissions.Nodes);

            return _userPermissions;
        }

        private void PopulateNodeTags(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                switch (node.Text)
                {
                    case "Applications Menu":
                        node.Tag = ClsBL_User.EnPermissions.ApplicationsMenu;
                        break;
                    case "Driving Licenses Services Menu":
                        node.Tag = ClsBL_User.EnPermissions.DrivingLicensesServicesMenu;
                        break;
                    case "New Driving License":
                        node.Tag = ClsBL_User.EnPermissions.NewDrivingLicense;
                        break;
                    case "Add New Local License Application":
                        node.Tag = ClsBL_User.EnPermissions.AddNewLocalLicenseApplication;
                        break;
                    case "Issue New International License":
                        node.Tag = ClsBL_User.EnPermissions.IssueInternationalLicense;
                        break;
                    case "Renew Local License":
                        node.Tag = ClsBL_User.EnPermissions.RenewLocalLicense;
                        break;
                    case "Replacement License":
                        node.Tag = ClsBL_User.EnPermissions.ReplacementLicense;
                        break;
                    case "Retake Test Application":
                        node.Tag = ClsBL_User.EnPermissions.RetakeTest;
                        break;
                    case "Show Person License History":
                        node.Tag = ClsBL_User.EnPermissions.PersonLicenseHistory;
                        break;
                    case "Manage Applications Menu":
                        node.Tag = ClsBL_User.EnPermissions.ManageApplicationsMenu;
                        break;
                    case "Manage Local Driving License Applications":
                        node.Tag = ClsBL_User.EnPermissions.ManageLocalDrivingLicenseApplications;
                        break;
                    case "Edit LDL Application":
                        node.Tag = ClsBL_User.EnPermissions.EditLDLApplication;
                        break;
                    case "Delete LDL Application":
                        node.Tag = ClsBL_User.EnPermissions.DeleteLDLApplication;
                        break;
                    case "Cancel LDL Application":
                        node.Tag = ClsBL_User.EnPermissions.CancelLDLApplication;
                        break;
                    case "Scheduling Tests":
                        node.Tag = ClsBL_User.EnPermissions.SchedulingTests;
                        break;
                    case "Issue Local License":
                        node.Tag = ClsBL_User.EnPermissions.IssueLocalLicense;
                        break;
                    case "Manage International License Applications":
                        node.Tag = ClsBL_User.EnPermissions.ManageInternationalLicense;
                        break;
                    case "Detain Licenses Menu":
                        node.Tag = ClsBL_User.EnPermissions.DetainLicensesMenu;
                        break;
                    case "Manage Detain Licenses":
                        node.Tag = ClsBL_User.EnPermissions.ManageDetainLicenses;
                        break;
                    case "Detain License":
                        node.Tag = ClsBL_User.EnPermissions.DetainLicense;
                        break;
                    case "Release Detained License":
                        node.Tag = ClsBL_User.EnPermissions.ReleaseDetainedLicense;
                        break;
                    case "Manage Application Types":
                        node.Tag = ClsBL_User.EnPermissions.ManageApplicationTypes;
                        break;
                    case "Manage Test Types":
                        node.Tag = ClsBL_User.EnPermissions.ManageTestTypes;
                        break;
                    case "People Menu":
                        node.Tag = ClsBL_User.EnPermissions.PeopleMenu;
                        break;
                    case "Add New Person":
                        node.Tag = ClsBL_User.EnPermissions.AddPerson;
                        break;
                    case "Edit Person":
                        node.Tag = ClsBL_User.EnPermissions.EditPerson;
                        break;
                    case "Delete Person":
                        node.Tag = ClsBL_User.EnPermissions.DeletePerson;
                        break;
                    case "Users Menu":
                        node.Tag = ClsBL_User.EnPermissions.UsersMenu;
                        break;
                    case "Add New User":
                        node.Tag = ClsBL_User.EnPermissions.AddUser;
                        break;
                    case "Edit User":
                        node.Tag = ClsBL_User.EnPermissions.EditUser;
                        break;
                    case "Delete User":
                        node.Tag = ClsBL_User.EnPermissions.DeleteUser;
                        break;
                    case "Change Passwords":
                        node.Tag = ClsBL_User.EnPermissions.ChangePasswords;
                        break;
                    case "Manage Drivers":
                        node.Tag = ClsBL_User.EnPermissions.ManageDrivers;
                        break;
                    default:
                        node.Tag = ClsBL_User.EnPermissions.None;
                        break;
                }

                if (node.Nodes.Count > 0)
                {
                    PopulateNodeTags(node.Nodes); // Recursive call for child nodes
                }
            }
        }

        private void PrepareUserPermissions(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    _userPermissions |= (ClsBL_User.EnPermissions)node.Tag; // Add checked node to UserPermissions enum
                }

                if (node.Nodes.Count > 0) PrepareUserPermissions(node.Nodes); // Recursive call for child nodes

            }
        }
    }
}
