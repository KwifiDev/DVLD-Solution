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

        public static ClsBL_TestType Find(EnType testTypeID)
        {
            string testTypeTitle = "", testTypeDescription = "";
            float testTypeFees = 0.0f;

            if (ClsDA_TestTypes.GetTestTypeByID((int)testTypeID, ref testTypeTitle, ref testTypeDescription, ref testTypeFees))
            {
                return new ClsBL_TestType(testTypeID, testTypeTitle, testTypeDescription, testTypeFees);
            }
            else return null;
        }

        public static DataTable Load()
        {
            return ClsDA_TestTypes.GetAllTestTypes();
        }

        public bool Save()
        {
            switch (enMode)
            {
                case EnMode.Add:
                    // Code Here
                    return false;
                case EnMode.Update:
                    return _Update();
            }

            return false;
        }

        private bool _Update()
        {
            return ClsDA_TestTypes.UpdateTestType((int)TestType, TestTypeTitle, TestTypeDescription, TestTypeFees);
        }

        public static float FindTestTypeFees(EnType testType)
        {
            return ClsDA_TestTypes.GetTestFees((int)testType);
        }
    }
}

