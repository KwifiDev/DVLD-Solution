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
        public ClsBL_TestAppointment TestAppointmentInfo { get; private set; }

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
            //TestAppointmentInfo = await ClsBL_TestAppointment.Find(TestAppointmentID);
            enMode = EnMode.Update;
        }

        private static async Task<ClsBL_Test> CreateAsync(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            ClsBL_Test test = new ClsBL_Test(testID, testAppointmentID, testResult, notes, createdByUserID)
            {
                TestAppointmentInfo = await ClsBL_TestAppointment.Find(testAppointmentID).ConfigureAwait(false)
            };

            return test;
        }

        public static async Task<ClsBL_Test> Find(int testID)
        {
            ClsDA_Tests.Data data = await ClsDA_Tests.GetTestByID(testID).ConfigureAwait(false);
            
            if (data != null && data.IsFound)
            {
                return await CreateAsync(testID, data.TestAppointmentID, data.TestResult, data.Notes,
                                    data.CreatedByUserID).ConfigureAwait(false);
            }
            else return null;
        }

        public static async Task<DataTable> Load()
        {
            return await ClsDA_Tests.GetAllTests();
        }

        public static async Task<bool> IsExist(int testID)
        {
            return await ClsDA_Tests.IsTestExist(testID);
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
                    return _Update();

            }
            return false;
        }

        private bool _Update()
        {
            return false;
        }

        private async Task<bool> _Add()
        {
            TestID = await ClsDA_Tests.AddNewTest(TestAppointmentID,TestResult,Notes,CreatedByUserID);

            return (TestID > 0);
        }

        public static async Task<int> FindTestIDByTestAppointmentID(int testAppointmentID)
        {
            return await ClsDA_Tests.GetTestIDByTestAppointmentID(testAppointmentID);
        }
    }
}
