# MNIST Binary Classifier
This project implements a simple binary classifier (perceptron) to recognize the digit "2" from the MNIST dataset. It includes custom data loading, training, and evaluation functionalities in C#, without reliance on external machine learning libraries.

## Project Structure
- **MNISTLoader**: Handles loading and processing the MNIST dataset from binary files.
- **BinaryClassifier**: A single-layer perceptron model for binary classification.
- **Program.cs**: Executes training and evaluation, printing model accuracy.

## Setup Instructions
### Download MNIST Data:

Place train-images-idx3-ubyte, train-labels-idx1-ubyte, t10k-images-idx3-ubyte, and t10k-labels-idx1-ubyte files in the assets folder with subfolders like below:
```
assets/
├── train-images-idx3-ubyte/
│   └── train-images.idx3-ubyte
├── train-labels-idx1-ubyte/
│   └── train-labels.idx1-ubyte
├── t10k-images-idx3-ubyte/
│   └── t10k-images.idx3-ubyte
└── t10k-labels-idx1-ubyte/
    └── t10k-labels.idx1-ubyte

```
### Run the Project:

The project will load the MNIST data, train the binary classifier over 10 epochs, and evaluate its accuracy in distinguishing the digit "2" from other digits.
## Code Overview

### MNISTLoader
- **LoadMNIST**: Loads and processes images and labels from binary files.
- **LoadImages** and **LoadLabels**: Handle loading images and labels into double and integer arrays for model processing. Automatically adjusts for dataset size (60,000 for training, 10,000 for testing).
### BinaryClassifier
- **Train**: Trains the perceptron model on labeled MNIST images to recognize the digit "2".
- **Evaluate**: Calculates the model's accuracy on the test dataset.
- **Sample** Execution Output
After running the program, you should see output similar to:

```
Epoch 1/10 completed.
Epoch 2/10 completed.
...
Epoch 10/10 completed.
Accuracy: 96.51%
```

## Customizing
- **Epochs**: Modify the number of epochs in Program.cs by adjusting classifier.Train(..., epochs: 10);.
- **Learning Rate**: Adjust the learning rate in BinaryClassifier for more fine-tuned training.