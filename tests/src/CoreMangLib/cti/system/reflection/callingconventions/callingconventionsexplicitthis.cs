using System;
using System.Reflection;

/// <summary>
/// CallingConventions.ExplicitThis [v-yaduoj]
/// </summary>
public class CallingConventionsTest
{
    private enum MyCallingConventions
    {
        Standard = 0x0001,
        VarArgs = 0x0002,
        Any = ExplicitThis | VarArgs,
        HasThis = 0x0020,
        ExplicitThis = 0x0040,
    }

    public static int Main()
    {
        CallingConventionsTest testObj = new CallingConventionsTest();

        TestLibrary.TestFramework.BeginTestCase("for Enumeration: CallingConventions.ExplicitThis");
        if (testObj.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }

    public bool RunTests()
    {
        bool retVal = true;

        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;

        return retVal;
    }

    #region Positive tests
    public bool PosTest1()
    {
        bool retVal = true;

        const string c_TEST_ID = "P001";
        const string c_TEST_DESC = "PosTest1: Calling convention is ExplicitThis";
        string errorDesc;

        int expectedValue;
        int actualValue;

        TestLibrary.TestFramework.BeginScenario(c_TEST_DESC);
        try
        {
            expectedValue = (int)MyCallingConventions.ExplicitThis;
            actualValue = (int)CallingConventions.ExplicitThis;
            if (actualValue != expectedValue)
            {
                errorDesc = "ExplicitThis value of CallingConventionsExplicitThis is not the value " + expectedValue +
                            "as expected: actual(" + actualValue + ")";
                TestLibrary.TestFramework.LogError("001" + " TestId-" + c_TEST_ID, errorDesc);
                retVal = false;
            }
        }
        catch (Exception e)
        {
            errorDesc = "Unexpected exception: " + e;
            TestLibrary.TestFramework.LogError("002" + " TestId-" + c_TEST_ID, errorDesc);
            retVal = false;
        }

        return retVal;
    }
    #endregion
}
