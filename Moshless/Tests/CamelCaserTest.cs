using System.Net.NetworkInformation;

namespace Moshless.Tests
{
    // https://learn.microsoft.com/en-us/dotnet/core/tutorials/testing-library-with-visual-studio?pivots=dotnet-8-0
    // It took many tries to get Microsoft.VisualStudio.TestTools.UnitTesting working. It seems that it will work only with certain
    // project configuration:
    /*
    <Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\intermediate\intermediate.csproj" />
    <PackageReference Include="coverlet.collector" Version="6.0.0" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
    <PackageReference Include="MSTest.TestAdapter" Version="3.1.1" />
    <PackageReference Include="MSTest.TestFramework" Version="3.1.1" />
  </ItemGroup>
  
  <ItemGroup>
    <Using Include="Microsoft.VisualStudio.TestTools.UnitTesting" />
  </ItemGroup>
</Project>
    */

    [TestClass]
    public class CamelCaserTest
    {
        // https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert.areequal?view=visualstudiosdk-2022
        // https://www.softwaretestingmagazine.com/knowledge/how-to-choose-the-right-name-for-unit-tests/

        [TestMethod]
        public void CamelCase_ValidInputs_StringReturned()
        {
            // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-8.0
            Dictionary<String, String> dict = new Dictionary<String, String>
            {
                { "This Kasmok smok", "thisKasmokSmok" },
                { "123", "123" },
                { "iNVERTCAPS", "invertcaps" },
                { "a 1b 43 e E rR", "a1b43EERr" },
                { "mORE INVERTED CPS", "moreInvertedCps" },
                { "  ,. - ", "" },
                { "  [ -=  R=", "r" }
            };
            foreach (KeyValuePair<String, String> pair in dict)
            {
                string camelCased = pair.Key.CamelCase();

                // (expected, got, message)
                Assert.AreEqual<String>(pair.Value, camelCased, 
                    $"For \"{pair.Key}\" got \"{camelCased}\", expected {pair.Value}");
            }
        }

        [TestMethod]
        public void CamelCase_StringEmpty_StringEmptyReturned()
        {
            string camelCased = String.Empty.CamelCase();
            // (expected, got, message)
            Assert.AreEqual<String>(String.Empty, camelCased,
                $"For String.Empty got \"{camelCased}\", expected String.Empty");
        }

        // https://stackoverflow.com/questions/933613/how-do-i-use-assert-to-verify-that-an-exception-has-been-thrown-with-mstest
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Cannot perform CamelCasing on null.")]
        public void CamelCase_NullInput_ExceptionThrown()
        {
            String? str = null;
            string camelCased = str.CamelCase();

            // Func<String, String> func = CamelCaser.CamelCase;

            // (expected, got, message)
            // Assert.ThrowsException<ArgumentNullException>(func(null);
            str.CamelCase();
        }
    }
}
