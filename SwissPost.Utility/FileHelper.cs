namespace SwissPost.Utility;

public static class FileHelper
{
    public static string GenerateOutputFileName(string sourceFilePath)
    {
        var sourceFileName = Path.GetFileNameWithoutExtension(sourceFilePath);
        var timestamp = DateTime.UtcNow.ToString("yyyyMMddhhmmssfff");
        var outFileName = $"{sourceFileName}_GeoJSON_{timestamp}.csv";

        return outFileName;
    }

    public static string GenerateOutputFilePath(string sourceFilePath)
    {
        var directory = Path.GetDirectoryName(sourceFilePath);
        var outFilePath = Path.Combine(directory, GenerateOutputFileName(sourceFilePath));

        return outFilePath;
    }
}