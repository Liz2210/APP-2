using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleHierarchies.Data;
using SampleHierarchies.Services;

namespace SampleHierarchies.Tests
{
    [TestClass]
    public class ScreenDefinitionServiceTests
    {
        [TestMethod]
        public void ReadJsonFile_ValidPath_ReturnsScreenDefinitionObject()
        {
            // Arrange
            string jsonPath = "ReadTestForUnitTests.json";

            // Act
            var result = ScreenDefinionService.Read(jsonPath);

            // Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void WriteToJsonFile_ValidSettings_WritesToFileSuccessfully()
        {
            // Arrange
            string jsonPath = "WriteTestForUnitTests.json";
            ScreenDefinition settings = new ScreenDefinition();

            // Act
            ScreenDefinionService.Write(settings, jsonPath);

            // Assert
            Assert.IsTrue(File.Exists(jsonPath));
        }

        [TestMethod]
        public void ShowScreenContent_ValidArguments_DisplaysContent()
        {
            // Arrange
            string jsonPath = "ContentTestForUnitTests.json";
            int lineNumber = 0;
            string predictText = "Text for test";
            string result;
            StringWriter temp = new StringWriter();

            // Act
            Console.SetOut(temp);
            ScreenDefinionService.Show(jsonPath, lineNumber);

            result = temp.ToString().Trim();
            predictText.Trim();

            // Assert
            Assert.IsTrue(result == predictText);
        }
    }
}