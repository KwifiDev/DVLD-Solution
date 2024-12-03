using DVLD_DA;
using System;
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

        public static async Task<ClsBL_DetainedLicense> CreateAsync(int detainID, int licenseID, DateTime detainDate, float fineFees, int createdByUserID,
                                      bool isReleased, DateTime? releaseDate, int? releasedByUserID, int? releaseApplicationID)
        {
            ClsBL_DetainedLicense detainedLicense = new ClsBL_DetainedLicense(detainID, licenseID, detainDate, fineFees,
                createdByUserID, isReleased, releaseDate, releasedByUserID, releaseApplicationID)
            {
                CreatedByUserInfo = await ClsBL_User.Find(createdByUserID),
                ReleasedByUserInfo = releasedByUserID != null ? await ClsBL_User.Find((int)releasedByUserID) : null
            };

            return detainedLicense;
        }

        public static async Task<ClsBL_DetainedLicense> Find(int detainID)
        {
            int licenseID = -1, createdByUserID = -1;
            int? releasedByUserID = -1, releaseApplicationID = -1;
            DateTime detainDate = DateTime.Now;
            DateTime? releaseDate = DateTime.Now;
            float fineFees = 0;
            bool isReleased = false;

            if (ClsDA_DetainedLicenses.GetDetainedLicenseByID(detainID, ref licenseID, ref detainDate, ref fineFees,
                ref createdByUserID, ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
            {
                return await CreateAsync(detainID, licenseID, detainDate, fineFees, createdByUserID,
                                                 isReleased, releaseDate, releasedByUserID, releaseApplicationID).ConfigureAwait(false);
            }
            else return null;
        }

        public bool Save()
        {
            switch (enMode)
            {
                case EnMode.Add:
                    {
                        if (_Add())
                        {
                            enMode = EnMode.Update;
                            return true;
                        }
                        else return false;
                    }
                case EnMode.Update:
                    {
                        return _Update();
                    }

            }

            return false;
        }

        private bool _Add()
        {
            DetainID = ClsDA_DetainedLicenses.AddNewDetainedLicense(LicenseID, DetainDate, FineFees, CreatedByUserID);
            return (DetainID > 0);
        }

        private bool _Update()
        {
            return ClsDA_DetainedLicenses.UpdateDetainedLicense(DetainID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
        }

        public static bool IsDetained(int licenseID)
        {
            return ClsDA_DetainedLicenses.IsDetained(licenseID);
        }

        public static DataTable Load()
        {
            return ClsDA_DetainedLicenses.GetAllDetainedLicenses();
        }

        public static DataTable LoadView()
        {
            return ClsDA_DetainedLicenses.GetAllDetainedLicenses_View();
        }

        public static ClsBL_DetainedLicense FindByLicenseID(int licenseID)
        {
            int detainID = -1, createdByUserID = -1;
            int? releasedByUserID = -1, releaseApplicationID = -1;
            DateTime detainDate = DateTime.Now;
            DateTime? releaseDate = DateTime.Now;
            float fineFees = 0;
            bool isReleased = false;

            if (ClsDA_DetainedLicenses.GetDetainedLicenseByLicenseID(ref detainID, licenseID, ref detainDate, ref fineFees,
                ref createdByUserID, ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
            {
                return new ClsBL_DetainedLicense(detainID, licenseID, detainDate, fineFees, createdByUserID,
                                                 isReleased, releaseDate, releasedByUserID, releaseApplicationID);
            }
            else return null;
        }

        internal bool ReleaseLicense(int releasedByUserID, int releaseApplicationID)
        {
            if (IsReleased) return false;

            IsReleased = true;
            ReleaseDate = DateTime.Now;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;

            return Save();
        }

        internal bool ReleaseLicenseV2(int releasedByUserID, int releaseApplicationID)
        {
            if (IsReleased) return false;

            return ClsDA_DetainedLicenses.ReleaseDetainedLicense(DetainID, releasedByUserID, releaseApplicationID);
        }
    }
}
