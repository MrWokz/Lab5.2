using System;
using System.Linq;

public class MathOperations
{
    // Перевантажений метод Add для чисел
    public int Add(int a, int b)
    {
        return a + b;
    }

    // Перевантажений метод Add для масивів чисел
    public int[] Add(int[] array1, int[] array2)
    {
        if (array1.Length != array2.Length)
            throw new ArgumentException("Arrays must be of the same length.");

        return array1.Zip(array2, (x, y) => x + y).ToArray();
    }

    // Перевантажений метод Add для матриць
    public int[,] Add(int[,] matrix1, int[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);

        if (rows != matrix2.GetLength(0) || cols != matrix2.GetLength(1))
            throw new ArgumentException("Matrices must be of the same dimensions.");

        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        return result;
    }

    // Метод для додавання тензорів (тривимірні масиви)
    public int[,,] Add(int[,,] tensor1, int[,,] tensor2)
    {
        int x = tensor1.GetLength(0);
        int y = tensor1.GetLength(1);
        int z = tensor1.GetLength(2);

        if (x != tensor2.GetLength(0) || y != tensor2.GetLength(1) || z != tensor2.GetLength(2))
            throw new ArgumentException("Tensors must be of the same dimensions.");

        int[,,] result = new int[x, y, z];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                for (int k = 0; k < z; k++)
                {
                    result[i, j, k] = tensor1[i, j, k] + tensor2[i, j, k];
                }
            }
        }
        return result;
    }

    // Перевантажений метод Subtract для чисел
    public int Subtract(int a, int b)
    {
        return a - b;
    }

    // Перевантажений метод Subtract для масивів чисел
    public int[] Subtract(int[] array1, int[] array2)
    {
        if (array1.Length != array2.Length)
            throw new ArgumentException("Arrays must be of the same length.");

        return array1.Zip(array2, (x, y) => x - y).ToArray();
    }

    // Перевантажений метод Subtract для матриць
    public int[,] Subtract(int[,] matrix1, int[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);

        if (rows != matrix2.GetLength(0) || cols != matrix2.GetLength(1))
            throw new ArgumentException("Matrices must be of the same dimensions.");

        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }
        return result;
    }

    // Метод для віднімання тензорів (тривимірні масиви)
    public int[,,] Subtract(int[,,] tensor1, int[,,] tensor2)
    {
        int x = tensor1.GetLength(0);
        int y = tensor1.GetLength(1);
        int z = tensor1.GetLength(2);

        if (x != tensor2.GetLength(0) || y != tensor2.GetLength(1) || z != tensor2.GetLength(2))
            throw new ArgumentException("Tensors must be of the same dimensions.");

        int[,,] result = new int[x, y, z];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                for (int k = 0; k < z; k++)
                {
                    result[i, j, k] = tensor1[i, j, k] - tensor2[i, j, k];
                }
            }
        }
        return result;
    }

    // Перевантажений метод Multiply для чисел
    public int Multiply(int a, int b)
    {
        return a * b;
    }

    // Перевантажений метод Multiply для масивів чисел
    public int[] Multiply(int[] array1, int[] array2)
    {
        if (array1.Length != array2.Length)
            throw new ArgumentException("Arrays must be of the same length.");

        return array1.Zip(array2, (x, y) => x * y).ToArray();
    }

    // Перевантажений метод Multiply для матриць
    public int[,] Multiply(int[,] matrix1, int[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int rows2 = matrix2.GetLength(0);
        int cols2 = matrix2.GetLength(1);

        if (cols1 != rows2)
            throw new ArgumentException("Number of columns in the first matrix must be equal to the number of rows in the second matrix.");

        int[,] result = new int[rows1, cols2];
        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                for (int k = 0; k < cols1; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }
        return result;
    }

    // Метод для множення тензорів (елементне множення)
    public int[,,] Multiply(int[,,] tensor1, int[,,] tensor2)
    {
        int x = tensor1.GetLength(0);
        int y = tensor1.GetLength(1);
        int z = tensor1.GetLength(2);

        if (x != tensor2.GetLength(0) || y != tensor2.GetLength(1) || z != tensor2.GetLength(2))
            throw new ArgumentException("Tensors must be of the same dimensions.");

        int[,,] result = new int[x, y, z];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                for (int k = 0; k < z; k++)
                {
                    result[i, j, k] = tensor1[i, j, k] * tensor2[i, j, k];
                }
            }
        }
        return result;
    }
}

// Тестування класу MathOperations
public class Program
{
    public static void Main()
    {
        MathOperations mathOps = new MathOperations();

        // Тестування додавання чисел
        Console.WriteLine("Add two numbers: " + mathOps.Add(5, 3)); // Виведе 8

        // Тестування віднімання чисел
        Console.WriteLine("Subtract two numbers: " + mathOps.Subtract(5, 3)); // Виведе 2

        // Тестування множення чисел
        Console.WriteLine("Multiply two numbers: " + mathOps.Multiply(5, 3)); // Виведе 15

        // Тестування додавання масивів
        int[] array1 = { 1, 2, 3 };
        int[] array2 = { 4, 5, 6 };
        int[] arraySum = mathOps.Add(array1, array2);
        Console.WriteLine("Add two arrays: " + string.Join(", ", arraySum)); // Виведе 5, 7, 9

        // Тестування віднімання масивів
        int[] arrayDiff = mathOps.Subtract(array1, array2);
        Console.WriteLine("Subtract two arrays: " + string.Join(", ", arrayDiff)); // Виведе -3, -3, -3

        // Тестування множення масивів
        int[] arrayProduct = mathOps.Multiply(array1, array2);
        Console.WriteLine("Multiply two arrays: " + string.Join(", ", arrayProduct)); // Виведе 4, 10, 18

        // Тестування додавання матриць
        int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
        int[,] matrix2 = { { 5, 6 }, { 7, 8 } };
        int[,] matrixSum = mathOps.Add(matrix1, matrix2);
        Console.WriteLine("Add two matrices:");
        for (int i = 0; i < matrixSum.GetLength(0); i++)
        {
            for (int j = 0; j < matrixSum.GetLength(1); j++)
            {
                Console.Write(matrixSum[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Тестування віднімання матриць
        int[,] matrixDiff = mathOps.Subtract(matrix1, matrix2);
        Console.WriteLine("Subtract two matrices:");
        for (int i = 0; i < matrixDiff.GetLength(0); i++)
        {
            for (int j = 0; j < matrixDiff.GetLength(1); j++)
            {
                Console.Write(matrixDiff[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Тестування множення матриць
        int[,] matrixProduct = mathOps.Multiply(matrix1, matrix2);
        Console.WriteLine("Multiply two matrices:");
        for (int i = 0; i < matrixProduct.GetLength(0); i++)
        {
            for (int j = 0; j < matrixProduct.GetLength(1); j++)
            {
                Console.Write(matrixProduct[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Тестування додавання тензорів
        int[,,] tensor1 = { { { 1, 2 }, { 3, 4 } }, { { 5, 6 }, { 7, 8 } } };
        int[,,] tensor2 = { { { 9, 10 }, { 11, 12 } }, { { 13, 14 }, { 15, 16 } } };
        int[,,] tensorSum = mathOps.Add(tensor1, tensor2);
        Console.WriteLine("Add two tensors:");
        for (int i = 0; i < tensorSum.GetLength(0); i++)
        {
            for (int j = 0; j < tensorSum.GetLength(1); j++)
            {
                for (int k = 0; k < tensorSum.GetLength(2); k++)
                {
                    Console.Write(tensorSum[i, j, k] + " ");
                }
                Console.WriteLine();
            }
        }

        // Тестування віднімання тензорів
        int[,,] tensorDiff = mathOps.Subtract(tensor1, tensor2);
        Console.WriteLine("Subtract two tensors:");
        for (int i = 0; i < tensorDiff.GetLength(0); i++)
        {
            for (int j = 0; j < tensorDiff.GetLength(1); j++)
            {
                for (int k = 0; k < tensorDiff.GetLength(2); k++)
                {
                    Console.Write(tensorDiff[i, j, k] + " ");
                }
                Console.WriteLine();
            }
        }

        // Тестування множення тензорів
        int[,,] tensorProduct = mathOps.Multiply(tensor1, tensor2);
        Console.WriteLine("Multiply two tensors:");
        for (int i = 0; i < tensorProduct.GetLength(0); i++)
        {
            for (int j = 0; j < tensorProduct.GetLength(1); j++)
            {
                for (int k = 0; k < tensorProduct.GetLength(2); k++)
                {
                    Console.Write(tensorProduct[i, j, k] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
