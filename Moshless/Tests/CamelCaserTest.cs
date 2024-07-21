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
        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
