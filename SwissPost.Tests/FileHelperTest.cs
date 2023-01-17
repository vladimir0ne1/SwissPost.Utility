using NUnit.Framework;
using SwissPost.Utility;

namespace SwissPost.Tests;

public class FileHelperTest
{
    [Test]
    public void CheckOutputFileName()
    {
        var sourceFilePath = @"C:\Test\Data\file.csv";
        Console.WriteLine(FileHelper.GenerateOutputFileName(sourceFilePath));
    }

    [Test]
    public void CheckOutputFilePath()
    {
        var sourceFilePath = @"C:\Test\Data\file.csv";
        Console.WriteLine(FileHelper.GenerateOutputFilePath(sourceFilePath));
    }
}
