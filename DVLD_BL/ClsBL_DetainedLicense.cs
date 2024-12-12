using DVLD_DA;
using System;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;

namespace DVLD_BL
{
    public class ClsBL_DetainedLicense
    {
        enum EnMode { Add, Update }
        EnMode enMode;
        public int DetainID { get; private set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public float FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }
        public ClsBL_User CreatedByUserInfo { get; private set; }
        public ClsBL_User ReleasedByUserInfo { get; private set; }

        public ClsBL_DetainedLicense()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = null;
            ReleasedByUserID = null;
            ReleaseApplicationID = null;
            enMode = EnMode.Add;
        }

        private ClsBL_DetainedLicense(int detainID, int licenseID, DateTime detainDate, float fineFees, int createdByUserID,
                                      bool isReleased, DateTime? releaseDate, int? releasedByUserID, int? releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;
            //CreatedByUserInfo = ClsBL_User.Find(CreatedByUserID);
            //ReleasedByUserInfo = ReleasedByUserID != null ? ClsBL_User.Find((int)ReleasedByUserID) : null;
            enMode = EnMode.Update;
        }

        private static async Task<ClsBL_DetainedLicense> CreateAsync(int detainID, int licenseID, DateTime detainDate,
                                                float fineFees, int createdByUserID, bool isReleased,
                                                DateTime? releaseDate, int? releasedByUserID, int? releaseApplicationID)
        {
            ClsBL_DetainedLicense detainedLicense = new ClsBL_DetainedLicense(detainID, licenseID, detainDate, fineFees,
                createdByUserID, isReleased, releaseDate, releasedByUserID, releaseApplicationID)
            {
                CreatedByUserInfo = await ClsBL_User.Find(createdByUserID).ConfigureAwait(false),
                ReleasedByUserInfo = releasedByUserID != null ? await ClsBL_User.Find((int)releasedByUserID).ConfigureAwait(false) : null
            };

            return detainedLicense;
        }

        public static async Task<ClsBL_DetainedLicense> Find(int detainID)
        {

            ClsDA_DetainedLicenses.Data data = await ClsDA_DetainedLicenses.GetDetainedLicenseByID(detainID).ConfigureAwait(false);

            if (data != null && data.IsFound)
            {
                return await CreateAsync(detainID, data.LicenseID, data.DetainDate, data.FineFees, data.CreatedByUserID,
                                                 data.IsReleased, data.ReleaseDate, data.ReleasedByUserID,
                                                 data.ReleaseApplicationID).ConfigureAwait(false);
            }
            else return null;
        }

        public async Task<bool> Save()
        {
            switch (enMode)
            {
                case EnMode.Add:
                    {
                        if (await _Add())
                        {
                            enMode = EnMode.Update;
                            return true;
                        }
                        else return false;
                    }
                case EnMode.Update:
                    {
                        return await _Update();
                    }

            }

            return false;
        }

        private async Task<bool> _Add()
        {
            DetainID = await ClsDA_DetainedLicenses.AddNewDetainedLicense(LicenseID, DetainDate, FineFees, CreatedByUserID);
            return (DetainID > 0);
        }

        private async Task<bool> _Update()
        {
            return await ClsDA_DetainedLicenses.UpdateDetainedLicense(DetainID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
        }

        public static async Task<bool> IsDetained(int licenseID)
        {
            return await ClsDA_DetainedLicenses.IsDetained(licenseID);
        }

        public static async Task<DataTable> Load()
        {
            return await ClsDA_DetainedLicenses.GetAllDetainedLicenses();
        }

        public static async Task<DataTable> LoadView()
        {
            return await ClsDA_DetainedLicenses.GetAllDetainedLicenses_View();
        }

        public static async Task<ClsBL_DetainedLicense> FindByLicenseID(int licenseID)
        {
            ClsDA_DetainedLicenses.Data data = await ClsDA_DetainedLicenses.GetDetainedLicenseByLicenseID(licenseID).ConfigureAwait(false);

            if (data != null && data.IsFound)
            {
                return await CreateAsync(data.DetainID, data.LicenseID, data.DetainDate, data.FineFees,
                                                 data.CreatedByUserID, data.IsReleased, data.ReleaseDate,
                                                 data.ReleasedByUserID, data.ReleaseApplicationID).ConfigureAwait(false);
            }
            else return null;
        }

        internal async Task<bool> ReleaseLicense(int releasedByUserID, int releaseApplicationID)
        {
            if (IsReleased) return false;

            IsReleased = true;
            ReleaseDate = DateTime.Now;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;

            return await Save();
        }

        internal async Task<bool> ReleaseLicenseV2(int releasedByUserID, int releaseApplicationID)
        {
            if (IsReleased) return false;

            return await ClsDA_DetainedLicenses.ReleaseDetainedLicense(DetainID, releasedByUserID, releaseApplicationID);
        }
    }
}
