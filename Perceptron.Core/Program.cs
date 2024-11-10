using Perceptron.Core;

var trainImagesPath = Path.Combine(Directory.GetCurrentDirectory(), "assets", "train-images-idx3-ubyte",
    "train-images.idx3-ubyte");
var trainLabelsPath = Path.Combine(Directory.GetCurrentDirectory(), "assets", "train-labels-idx1-ubyte",
    "train-labels.idx1-ubyte");

var testImagesPath = Path.Combine(Directory.GetCurrentDirectory(), "assets", "t10k-images-idx3-ubyte",
    "t10k-images.idx3-ubyte");
var testLabelsPath = Path.Combine(Directory.GetCurrentDirectory(), "assets", "t10k-labels-idx1-ubyte",
    "t10k-labels.idx1-ubyte");

var (trainImages, trainLabels) = MNISTLoader.LoadMNIST(trainImagesPath, trainLabelsPath);
var (testImages, testLabels) = MNISTLoader.LoadMNIST(testImagesPath, testLabelsPath);

for (var i = 0; i < trainLabels.Length; i++)
{
    trainLabels[i] = trainLabels[i] == 2 ? 1 : 0;
}

for (var i = 0; i < testLabels.Length; i++)
{
    testLabels[i] = testLabels[i] == 2 ? 1 : 0;
}

var classifier = new BinaryClassifier(784);

classifier.Train(trainImages, trainLabels, epochs: 10);

var accuracy = classifier.Evaluate(testImages, testLabels);

Console.WriteLine($"Accuracy: {accuracy}%");