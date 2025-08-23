using NUnit.Framework;
using AltTester.AltTesterSDK.Driver;

public class Test
{   //Important! If your test file is inside a folder that contains an .asmdef file, please make sure that the assembly definition references NUnit.
    public AltDriver altDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altDriver = new AltDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altDriver.Stop();
    }


    [Test]
    public void TestIfButtonExist()
    {
        altDriver.LoadScene("SampleScene");
        var countButton = altDriver.FindObject(By.NAME, "SubmitButton");
        Assert.IsTrue(countButton.enabled, "Count button should be accessible");
        UnityEngine.Debug.Log("[OK] Count button is accessible");
    }

    [Test]
    public void TestButtonPress()
    {
        altDriver.LoadScene("SampleScene");
        var countText = altDriver.FindObject(By.NAME, "Count");
        var countButton = altDriver.FindObject(By.NAME, "SubmitButton");

        int startValue = int.Parse(countText.GetText());
        countButton.Tap();
        int newValue = int.Parse(countText.GetText());

        Assert.AreEqual(startValue + 1, newValue, "Count value won't increase by 1 when button pressed");
        UnityEngine.Debug.Log("[OK] Count increases when button is pressed");
    }

    [Test]
    public void TestButtonCountOnPress()
    {
        altDriver.LoadScene("SampleScene");
        var countText = altDriver.FindObject(By.NAME, "CountText");
        var countButton = altDriver.FindObject(By.NAME, "CountButton");

        int startValue = int.Parse(countText.GetText());
        if (startValue != 1)
        {
            UnityEngine.Debug.LogWarning($"[WARN] Starting count is {startValue}, expected 1");
        }

        for (int i = 0; i < 10; i++)
        {
            countButton.Tap();
        }

        int finalValue = int.Parse(countText.GetText());
        Assert.AreEqual(11, finalValue, $"Count should be 10 after 10 presses, but was {finalValue}");
        UnityEngine.Debug.Log("[OK] Count value is 10 after 10 presses");
    }
    

}
