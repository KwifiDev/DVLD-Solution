using DVLD_DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_BL
{
    public class ClsBL_TestAppointment
    {
        enum EnMode { Add, Update };
        EnMode enMode;
        public int TestAppointmentID { get; private set; }
        public ClsBL_TestType.EnType TestType { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }

        private ClsBL_TestAppointment(int testAppointmentID, ClsBL_TestType.EnType testType, int localDrivingLicenseApplicationID,
                                        DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked, int retakeTestApplicationID)
        {
            TestAppointmentID = testAppointmentID;
            TestType = testType;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
            RetakeTestApplicationID = retakeTestApplicationID;
            enMode = EnMode.Update;
        }
        public ClsBL_TestAppointment()
        {
            TestAppointmentID = -1;
            TestType = ClsBL_TestType.EnType.Vision;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            IsLocked = false;
            RetakeTestApplicationID = -1;
            enMode = EnMode.Add;
        }

        public static ClsBL_TestAppointment Find(int testAppointmentID)
        {
            int testTypeID = -1, localDrivingLicenseApplicationID = -1, createdByUserID = -1, retakeTestApplicationID = -1;
            float paidFees = 0;
            bool isLocked = false;
            DateTime appointmentDate = DateTime.Now;

            if (ClsDA_TestAppointments.GetTestAppointmentByID(testAppointmentID, ref testTypeID, 
                                            ref localDrivingLicenseApplicationID,ref appointmentDate, ref paidFees,
                                            ref createdByUserID, ref isLocked, ref retakeTestApplicationID))
            {
                return new ClsBL_TestAppointment(testAppointmentID, (ClsBL_TestType.EnType)testTypeID, localDrivingLicenseApplicationID,
                                                    appointmentDate, paidFees, createdByUserID, isLocked, retakeTestApplicationID);
            }
            else return null;
        }

        public static DataTable Load()
        {
            return ClsDA_TestAppointments.GetAllTestAppointments();
        }

        public static DataTable LoadView()
        {
            return ClsDA_TestAppointments.GetAllTestAppointments_View();
        }

        public static bool IsExist(int testAppointmentID)
        {
            return ClsDA_TestAppointments.IsTestAppointmentExist(testAppointmentID);
        }

        public bool Save()
        {
            switch (enMode)
            {
                case EnMode.Add:
                    if (_Add())
                    {
                        enMode = EnMode.Update;
                        return true;
                    }
                    else return false;

                case EnMode.Update:
                    return _Update();

            }
            return false;
        }

        private bool _Update()
        {
            return ClsDA_TestAppointments.UpdateTestAppointment(TestAppointmentID, AppointmentDate);
        }

        private bool _Add()
        {
            TestAppointmentID = ClsDA_TestAppointments.AddNewTestAppointment
                ((int)TestType, LocalDrivingLicenseApplicationID,
                AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);

            return (TestAppointmentID > 0);
        }

        public static bool LockByTestAppointmentID(int testAppointmentID)
        {
            return ClsDA_TestAppointments.LockByTestAppointmentID(testAppointmentID);
        }

        public bool Lock()
        {
            return LockByTestAppointmentID(TestAppointmentID);
        }
       
    }
}
