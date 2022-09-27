// Задача 58:
// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

Console.Clear();
Console.WriteLine("");
Console.WriteLine("\t Задача 58");
int[,] arrayA = GetArray(3, 3, 1, 9);
int[,] arrayB = GetArray(3, 3, 1, 9);
PrintArray(arrayA);
PrintArray(arrayB);
if (arrayA.GetLength(0) == arrayB.GetLength(1))
{
    int[,] multiplyingArrays = MultiplyingArrays(arrayA, arrayB);
    PrintArray(multiplyingArrays);
}
else
{
    Console.WriteLine($"Не удалось вычислить произведение матриц, для расчета должно "
    + "выполняться условие: число столбцов первой матрицы"
    + " совпадает с числом строк второй матрицы.");
}


int[,] MultiplyingArrays(int[,] array1, int[,] array2)
{
    int[,] multiplyingArrays = new int[array1.GetLength(0), array2.GetLength(1)];

    for (int i = 0; i < array1.GetLength(0); i++)
    {
        for (int j = 0; j < array2.GetLength(1); j++)
            for (int k = 0; k < array2.GetLength(0); k++) // Дополнительный цикл for с переменной k нужен:
                                                          // - для сложения перемноженных элементов
                                                          // - для ограничения по по количеству строк второго массива,
                                                          // что бы элемент на "выпал" из него. 
            {
                multiplyingArrays[i,j]+= array1[i,k]*array2[k,j];
            }
    }
    return multiplyingArrays;
}

int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintArray(int[,] array)
{
    Console.WriteLine("");
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("[ ");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }
        Console.SetCursorPosition(Console.CursorLeft - 6, Console.CursorTop);
        Console.WriteLine(" ]");
    }
    Console.WriteLine("");
}