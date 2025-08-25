using NUnit.Framework;
using AltTester.AltTesterSDK.Driver;
using System.Threading; // Sleep function

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
    // Test if buttos ir reachable 
    public void TestIfButtonExist()
    {
        // Load scene by name
        altDriver.LoadScene("SampleScene");
        // Find button by name
        var countButton = altDriver.FindObject(By.NAME, "SubmitButton");
        // check if button is enabled or print error message
        Assert.IsTrue(countButton.enabled, "Count button should be accessible");

    }

    [Test]
    // Test if button presses 
    public void TestButtonPress()
    {
        //lod scene by name
        altDriver.LoadScene("SampleScene");
        // Find counter by name
        var countText = altDriver.FindObject(By.NAME, "Count");
        // Find button by name
        var countButton = altDriver.FindObject(By.NAME, "SubmitButton");
        // Get initial from text and parse to int
        int startValue = int.Parse(countText.GetText());
        // Press button
        countButton.Tap();
        //get new value from text and parse to int
        int newValue = int.Parse(countText.GetText());
        // check if new value is 1 more than start value or print error message 
        Assert.AreEqual(startValue + 1, newValue, "Count value won't increase by 1 when button pressed");

    }

    [Test]
    // Test button presses and if counter count it 
    public void TestButtonCountOnPress()
    {
        // Load scene by name
        altDriver.LoadScene("SampleScene");
        // Find counter by name
        var countText = altDriver.FindObject(By.NAME, "Count");
        // Find button by name
        var countButton = altDriver.FindObject(By.NAME, "SubmitButton");

        // Get initial from text and parse to int
        int startValue = int.Parse(countText.GetText());
        // Check if start value is 0 or print error message with start value
        Assert.AreEqual(0, startValue, $"Count should start at 0, but was {startValue}");

        // Press button 10 times
        for (int i = 0; i < 10; i++)
        {
            // Press button
            countButton.Tap();
            // Small delay to ensure the UI has time to update
            Thread.Sleep(100);
        }

        // Get final value from text and parse to int
        int finalValue = int.Parse(countText.GetText());
        // Check if final value is 10 or priint error message with final value
        Assert.AreEqual(10, finalValue, $"Count should be 10 after 10 presses, but was {finalValue}");
    }


}
