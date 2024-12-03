using DVLD_DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BL
{
    public class ClsBL_Test
    {
        enum EnMode { Add, Update };
        EnMode enMode;

        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public ClsBL_TestAppointment TestAppointmentInfo { get; }

        public ClsBL_Test()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = string.Empty;
            CreatedByUserID = -1;
            enMode = EnMode.Add;
        }

        private ClsBL_Test(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserID = createdByUserID;
            TestAppointmentInfo = ClsBL_TestAppointment.Find(TestAppointmentID);
            enMode = EnMode.Update;
        }

        public static ClsBL_Test Find(int testID)
        {
            int testAppointmentID = -1, createdByUserID = -1;
            bool testResult = false;
            string notes = string.Empty;

            if (ClsDA_Tests.GetTestByID(testID, ref testAppointmentID, ref testResult, ref notes, ref createdByUserID))
            {
                return new ClsBL_Test(testID, testAppointmentID, testResult, notes, createdByUserID);
            }
            else return null;
        }

        public static DataTable Load()
        {
            return ClsDA_Tests.GetAllTests();
        }

        public static bool IsExist(int testID)
        {
            return ClsDA_Tests.IsTestExist(testID);
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
            return false;
        }

        private bool _Add()
        {
            TestID = ClsDA_Tests.AddNewTest(TestAppointmentID,TestResult,Notes,CreatedByUserID);

            return (TestID > 0);
        }

        public static int FindTestIDByTestAppointmentID(int testAppointmentID)
        {
            return ClsDA_Tests.GetTestIDByTestAppointmentID(testAppointmentID);
        }
    }
}
