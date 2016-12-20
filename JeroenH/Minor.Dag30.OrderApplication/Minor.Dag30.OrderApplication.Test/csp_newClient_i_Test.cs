using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Minor.Dag30.OrderApplication.Test
{
    [TestClass()]
    public class csp_newClient_i_Test : SqlDatabaseTestClass
    {

        public csp_newClient_i_Test()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
        }

        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_csp_newClient_iTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(csp_newClient_i_Test));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition SlagendeTestRowCount;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition SlagendeTestClientNr;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition FalendeTestNameNullRowCount;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition FalendeTestNameNull;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition FalendeTestEmailFormatFoutRowCount;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition FalendeTestEmailFormatFout;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition FalendeTestCountryNullRowCount;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition FalendeTestCountryNull;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition FalendeTestCountryTeLangRowCount;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition FalendeTestCountryTeLang;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition FalendeTestAddressNullRowCount;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition FalendeTestAddressNull;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition SlagendeTestResultCode;
            this.dbo_csp_newClient_iTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_csp_newClient_iTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            SlagendeTestRowCount = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            SlagendeTestClientNr = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            FalendeTestNameNullRowCount = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            FalendeTestNameNull = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            FalendeTestEmailFormatFoutRowCount = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            FalendeTestEmailFormatFout = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            FalendeTestCountryNullRowCount = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            FalendeTestCountryNull = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            FalendeTestCountryTeLangRowCount = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            FalendeTestCountryTeLang = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            FalendeTestAddressNullRowCount = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            FalendeTestAddressNull = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            SlagendeTestResultCode = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            // 
            // dbo_csp_newClient_iTest_TestAction
            // 
            dbo_csp_newClient_iTest_TestAction.Conditions.Add(SlagendeTestRowCount);
            dbo_csp_newClient_iTest_TestAction.Conditions.Add(SlagendeTestResultCode);
            dbo_csp_newClient_iTest_TestAction.Conditions.Add(SlagendeTestClientNr);
            dbo_csp_newClient_iTest_TestAction.Conditions.Add(FalendeTestNameNullRowCount);
            dbo_csp_newClient_iTest_TestAction.Conditions.Add(FalendeTestNameNull);
            dbo_csp_newClient_iTest_TestAction.Conditions.Add(FalendeTestEmailFormatFoutRowCount);
            dbo_csp_newClient_iTest_TestAction.Conditions.Add(FalendeTestEmailFormatFout);
            dbo_csp_newClient_iTest_TestAction.Conditions.Add(FalendeTestCountryNullRowCount);
            dbo_csp_newClient_iTest_TestAction.Conditions.Add(FalendeTestCountryNull);
            dbo_csp_newClient_iTest_TestAction.Conditions.Add(FalendeTestCountryTeLangRowCount);
            dbo_csp_newClient_iTest_TestAction.Conditions.Add(FalendeTestCountryTeLang);
            dbo_csp_newClient_iTest_TestAction.Conditions.Add(FalendeTestAddressNullRowCount);
            dbo_csp_newClient_iTest_TestAction.Conditions.Add(FalendeTestAddressNull);
            resources.ApplyResources(dbo_csp_newClient_iTest_TestAction, "dbo_csp_newClient_iTest_TestAction");
            // 
            // SlagendeTestRowCount
            // 
            SlagendeTestRowCount.Enabled = true;
            SlagendeTestRowCount.Name = "SlagendeTestRowCount";
            SlagendeTestRowCount.ResultSet = 1;
            SlagendeTestRowCount.RowCount = 1;
            // 
            // SlagendeTestClientNr
            // 
            SlagendeTestClientNr.ColumnNumber = 1;
            SlagendeTestClientNr.Enabled = true;
            SlagendeTestClientNr.ExpectedValue = "1";
            SlagendeTestClientNr.Name = "SlagendeTestClientNr";
            SlagendeTestClientNr.NullExpected = false;
            SlagendeTestClientNr.ResultSet = 2;
            SlagendeTestClientNr.RowNumber = 1;
            // 
            // FalendeTestNameNullRowCount
            // 
            FalendeTestNameNullRowCount.Enabled = true;
            FalendeTestNameNullRowCount.Name = "FalendeTestNameNullRowCount";
            FalendeTestNameNullRowCount.ResultSet = 3;
            FalendeTestNameNullRowCount.RowCount = 1;
            // 
            // FalendeTestNameNull
            // 
            FalendeTestNameNull.ColumnNumber = 1;
            FalendeTestNameNull.Enabled = true;
            FalendeTestNameNull.ExpectedValue = "-1";
            FalendeTestNameNull.Name = "FalendeTestNameNull";
            FalendeTestNameNull.NullExpected = false;
            FalendeTestNameNull.ResultSet = 3;
            FalendeTestNameNull.RowNumber = 1;
            // 
            // FalendeTestEmailFormatFoutRowCount
            // 
            FalendeTestEmailFormatFoutRowCount.Enabled = true;
            FalendeTestEmailFormatFoutRowCount.Name = "FalendeTestEmailFormatFoutRowCount";
            FalendeTestEmailFormatFoutRowCount.ResultSet = 4;
            FalendeTestEmailFormatFoutRowCount.RowCount = 1;
            // 
            // FalendeTestEmailFormatFout
            // 
            FalendeTestEmailFormatFout.ColumnNumber = 1;
            FalendeTestEmailFormatFout.Enabled = true;
            FalendeTestEmailFormatFout.ExpectedValue = "-1";
            FalendeTestEmailFormatFout.Name = "FalendeTestEmailFormatFout";
            FalendeTestEmailFormatFout.NullExpected = false;
            FalendeTestEmailFormatFout.ResultSet = 4;
            FalendeTestEmailFormatFout.RowNumber = 1;
            // 
            // FalendeTestCountryNullRowCount
            // 
            FalendeTestCountryNullRowCount.Enabled = true;
            FalendeTestCountryNullRowCount.Name = "FalendeTestCountryNullRowCount";
            FalendeTestCountryNullRowCount.ResultSet = 5;
            FalendeTestCountryNullRowCount.RowCount = 1;
            // 
            // FalendeTestCountryNull
            // 
            FalendeTestCountryNull.ColumnNumber = 1;
            FalendeTestCountryNull.Enabled = true;
            FalendeTestCountryNull.ExpectedValue = "-1";
            FalendeTestCountryNull.Name = "FalendeTestCountryNull";
            FalendeTestCountryNull.NullExpected = false;
            FalendeTestCountryNull.ResultSet = 5;
            FalendeTestCountryNull.RowNumber = 1;
            // 
            // FalendeTestCountryTeLangRowCount
            // 
            FalendeTestCountryTeLangRowCount.Enabled = true;
            FalendeTestCountryTeLangRowCount.Name = "FalendeTestCountryTeLangRowCount";
            FalendeTestCountryTeLangRowCount.ResultSet = 6;
            FalendeTestCountryTeLangRowCount.RowCount = 1;
            // 
            // FalendeTestCountryTeLang
            // 
            FalendeTestCountryTeLang.ColumnNumber = 1;
            FalendeTestCountryTeLang.Enabled = false;
            FalendeTestCountryTeLang.ExpectedValue = "-1";
            FalendeTestCountryTeLang.Name = "FalendeTestCountryTeLang";
            FalendeTestCountryTeLang.NullExpected = false;
            FalendeTestCountryTeLang.ResultSet = 6;
            FalendeTestCountryTeLang.RowNumber = 1;
            // 
            // FalendeTestAddressNullRowCount
            // 
            FalendeTestAddressNullRowCount.Enabled = true;
            FalendeTestAddressNullRowCount.Name = "FalendeTestAddressNullRowCount";
            FalendeTestAddressNullRowCount.ResultSet = 7;
            FalendeTestAddressNullRowCount.RowCount = 1;
            // 
            // FalendeTestAddressNull
            // 
            FalendeTestAddressNull.ColumnNumber = 1;
            FalendeTestAddressNull.Enabled = true;
            FalendeTestAddressNull.ExpectedValue = "-1";
            FalendeTestAddressNull.Name = "FalendeTestAddressNull";
            FalendeTestAddressNull.NullExpected = false;
            FalendeTestAddressNull.ResultSet = 7;
            FalendeTestAddressNull.RowNumber = 1;
            // 
            // dbo_csp_newClient_iTestData
            // 
            this.dbo_csp_newClient_iTestData.PosttestAction = null;
            this.dbo_csp_newClient_iTestData.PretestAction = null;
            this.dbo_csp_newClient_iTestData.TestAction = dbo_csp_newClient_iTest_TestAction;
            // 
            // SlagendeTestResultCode
            // 
            SlagendeTestResultCode.ColumnNumber = 1;
            SlagendeTestResultCode.Enabled = true;
            SlagendeTestResultCode.ExpectedValue = "0";
            SlagendeTestResultCode.Name = "SlagendeTestResultCode";
            SlagendeTestResultCode.NullExpected = false;
            SlagendeTestResultCode.ResultSet = 1;
            SlagendeTestResultCode.RowNumber = 1;
        }

        #endregion


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion

        [TestMethod()]
        public void dbo_csp_newClient_iTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_csp_newClient_iTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        private SqlDatabaseTestActions dbo_csp_newClient_iTestData;
    }
}
