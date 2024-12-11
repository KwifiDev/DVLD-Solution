using DVLD_DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BL
{
    public class ClsBL_TestType
    {
        enum EnMode { Add, Update }
        EnMode enMode;
        public enum EnType { Vision = 1, Written = 2, Street = 3 }
        
        public EnType TestType { get; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }

        private ClsBL_TestType(EnType testTypeID, string testTypeTitle, string testTypeDescription, float testTypeFees)
        {
            enMode = EnMode.Update;

            TestType = testTypeID;
            TestTypeTitle = testTypeTitle;
            TestTypeDescription = testTypeDescription;
            TestTypeFees = testTypeFees;
        }

        public static async Task<ClsBL_TestType> Find(EnType testTypeID)
        {

            ClsDA_TestTypes.Data data = await ClsDA_TestTypes.GetTestTypeByID((int)testTypeID);

            if (data != null && data.IsFound)
            {
                return new ClsBL_TestType(testTypeID, data.TestTypeTitle, data.TestTypeDescription, data.TestTypeFees);
            }
            else return null;
        }

        public static async Task<DataTable> Load()
        {
            return await ClsDA_TestTypes.GetAllTestTypes();
        }

        public async Task<bool> Save()
        {
            switch (enMode)
            {
                case EnMode.Add:
                    // Code Here
                    return false;
                case EnMode.Update:
                    return await _Update();
            }

            return false;
        }

        private async Task<bool> _Update()
        {
            return await ClsDA_TestTypes.UpdateTestType((int)TestType, TestTypeTitle, TestTypeDescription, TestTypeFees);
        }

        public static async Task<float> FindTestTypeFees(EnType testType)
        {
            return await ClsDA_TestTypes.GetTestFees((int)testType);
        }
    }
}

