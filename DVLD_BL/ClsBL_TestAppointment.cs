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
        public int? RetakeTestApplicationID { get; set; }

        private ClsBL_TestAppointment(int testAppointmentID, ClsBL_TestType.EnType testType, int localDrivingLicenseApplicationID,
                                        DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked, int? retakeTestApplicationID)
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

        public static async Task<ClsBL_TestAppointment> Find(int testAppointmentID)
        {
            ClsDA_TestAppointments.Data data = await ClsDA_TestAppointments.GetTestAppointmentByID(testAppointmentID);

            if (data != null && data.IsFound)
            {
                return new ClsBL_TestAppointment(testAppointmentID, (ClsBL_TestType.EnType)data.TestTypeID,
                    data.LocalDrivingLicenseApplicationID, data.AppointmentDate, data.PaidFees, data.CreatedByUserID,
                    data.IsLocked, data.RetakeTestApplicationID);
            }
            else return null;
        }

        public static async Task<DataTable> Load()
        {
            return await ClsDA_TestAppointments.GetAllTestAppointments();
        }

        public static async Task<DataTable> LoadView()
        {
            return await ClsDA_TestAppointments.GetAllTestAppointments_View();
        }

        public static async Task<bool> IsExist(int testAppointmentID)
        {
            return await ClsDA_TestAppointments.IsTestAppointmentExist(testAppointmentID);
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

        private async Task<bool> _Update()
        {
            return await ClsDA_TestAppointments.UpdateTestAppointment(TestAppointmentID, AppointmentDate);
        }

        private async Task<bool> _Add()
        {
            TestAppointmentID = await ClsDA_TestAppointments.AddNewTestAppointment
                ((int)TestType, LocalDrivingLicenseApplicationID,
                AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);

            return (TestAppointmentID > 0);
        }

        public static async Task<bool> LockByTestAppointmentID(int testAppointmentID)
        {
            return await ClsDA_TestAppointments.LockByTestAppointmentID(testAppointmentID);
        }

        public async Task<bool> Lock()
        {
            return await LockByTestAppointmentID(TestAppointmentID);
        }
       
    }
}
