namespace Perceptron.Core;

public abstract class MNISTLoader
{
    public static (double[][] images, int[] labels) LoadMNIST(string imageFilePath, string labelFilePath)
    {
        var images = LoadImages(imageFilePath);
        var labels = LoadLabels(labelFilePath);
        return (images, labels);
    }

    private static int[] LoadLabels(string labelFilePath)
    {
        var labelCount = labelFilePath.Contains("t10k") ? 10000 : 60000;
        using var stream = new FileStream(labelFilePath, FileMode.Open, FileAccess.Read);
        using var streamReader = new BinaryReader(stream);

        // First 8 bytes are metadata
        streamReader.BaseStream.Seek(8, SeekOrigin.Begin);
        var labelData = streamReader.ReadBytes(labelCount);

        var labels = new int[labelCount];
        for (var i = 0; i < labelCount; i++)
        {
            labels[i] = labelData[i];
        }

        return labels;
    }

    private static double[][] LoadImages(string imageFilePath)
    {
        var numImages = imageFilePath.Contains("t10k") ? 10000 : 60000;
        const int numPixels = 784; // 28 * 28

        using var stream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
        using var streamReader = new BinaryReader(stream);
        streamReader.BaseStream.Seek(16, SeekOrigin.Begin);

        var imageData = streamReader.ReadBytes(numImages * numPixels);

        var images = new double[numImages][];

        for (var i = 0; i < numImages; i++)
        {
            images[i] = new double[784];
            for (var j = 0; j < 784; j++)
            {
                images[i][j] = imageData[i * 784 + j] / 255.0;
            }
        }

        return images;
    }
}