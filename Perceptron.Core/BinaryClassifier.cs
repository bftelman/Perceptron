namespace Perceptron.Core;

public class BinaryClassifier
{
    private readonly double[] _weights;
    private double _bias;
    private readonly double _learningRate;

    public BinaryClassifier(int inputSize, double learningRate = 0.01)
    {
        _learningRate = learningRate;

        var random = new Random();
        _weights = new double[inputSize];

        for (var i = 0; i < inputSize; i++)
        {
            _weights[i] = (random.NextDouble() - 0.5) * 0.1;
        }

        _bias = random.NextDouble();
    }

    public double[] GetWeights() => _weights;

    public double GetBias() => _bias;

    private double GetLearningRate() => _learningRate;

    private static int Activate(double sum) => sum >= 0 ? 1 : 0;

    private int Predict(double[] inputs)
    {
        var sum = _bias + inputs.Select((t, i) => t * _weights[i]).Sum();
        return Activate(sum);
    }

    public void Train(double[][] inputs, int[] labels, int epochs = 10)
    {
        for (var epoch = 0; epoch < epochs; epoch++)
        {
            for (var i = 0; i < inputs.Length; i++)
            {
                var prediction = Predict(inputs[i]);
                var error = labels[i] - prediction;

                for (var j = 0; j < _weights.Length; j++)
                {
                    _weights[j] += _learningRate * error * inputs[i][j];
                }

                _bias += _learningRate * error;
            }

            Console.WriteLine($"Epoch {epoch + 1}/{epochs} completed.");
        }
    }

    public double Evaluate(double[][] testInputs, int[] testLabels)
    {
        var correct = testInputs.Select(Predict).Where((prediction, i) => prediction == testLabels[i]).Count();
        
        return (double)correct / testInputs.Length * 100;
    }
}