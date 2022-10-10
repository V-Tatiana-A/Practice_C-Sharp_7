// Задача 47.Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9


using static System.Console;
Clear();
WriteLine("Задача 47");
Write("Введите размер матрицы, мин и макс значения через пробел:  ");
double[] parametres=GetRealArrayFromString(ReadLine()!);
double[,] matrix=GetRealMatrixArray(parametres[0], parametres[1], parametres[2], parametres[3]);
PrintRealMatrix(matrix);



// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17->такого числа в массиве нет


WriteLine("");
WriteLine("Задача 50");
Write("Введите размер матрицы, мин и макс значения через пробел:  ");
int[] task=GetArrayFromString(ReadLine()!);
int[,] Matr=GetMatrixArray(task[0], task[1], task[2], task[3]);
PrintMatrix(Matr);
WriteLine("");
WriteLine("Введите индекс элемента через запятую");
int[] ind=GetIndFromString(ReadLine()!);
FindNumFromInd(ind, Matr);
WriteLine("");
WriteLine("Введите искомое число");
int A = Convert.ToInt32(ReadLine()!);
FindIndFromNum(A, Matr);


// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.


WriteLine("");
WriteLine("Задача 52");
Write("Введите размер матрицы, мин и макс значения через пробел:  ");
int[] input=GetArrayFromString(ReadLine()!);
int[,] TDArray=GetMatrixArray(input[0], input[1], input[2], input[3]);
PrintMatrix(TDArray);
WriteLine("");
WriteLine($"Среднее арифметическое элементов по каждому столбцу равно соответственно: ");
WriteLine($"{String.Join("; ", ArithAverageСolumns(TDArray))}");


// methods


double[,] GetRealMatrixArray(double rows, double columns, double minValue, double maxValue) 
{
    double[,] resultMatrix = new double[Convert.ToInt32(rows), Convert.ToInt32(columns)];
    for (int i = 0; i < resultMatrix.GetLength(0); i++) 
    {
        for (int j = 0; j < resultMatrix.GetLength(1); j++) 
        {
            resultMatrix[i,j]=Math.Round((minValue + new Random().NextDouble()*(maxValue-minValue)),3);
        }
    }
    return resultMatrix;
}


int[,] GetMatrixArray(int rows,int columns,int minValue, int maxValue) 
{
    int[,] resultMatrix = new int[rows, columns];
    for (int i = 0; i < resultMatrix.GetLength(0); i++) 
    {
        for (int j = 0; j < resultMatrix.GetLength(1); j++) 
        {
            resultMatrix[i,j]=new Random().Next(minValue,maxValue+1);
        }
    }
    return resultMatrix;
}


void PrintRealMatrix(double[,] inMatrix)
{
    for (int i = 0; i < inMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < inMatrix.GetLength(1); j++)
        {
            Write($"{inMatrix[i,j]}\t");
        }
        WriteLine();
    }
}

void PrintMatrix(int[,] inMatrix)
{
    for (int i = 0; i < inMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < inMatrix.GetLength(1); j++)
        {
            Write($"{inMatrix[i,j]}\t");
        }
        WriteLine();
    }
}


double[] GetRealArrayFromString(string parametres)
{
    string[] parames = parametres.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
    double[] parametresNum=new double[parames.Length];
    for (int i = 0; i < parametresNum.Length; i++)
    {
        parametresNum[i]=Convert.ToDouble(parames[i]);
    }

    return parametresNum;
}


int[] GetArrayFromString(string parametres)
{
    string[] parames = parametres.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
    int[] parametresNum=new int[parames.Length];
    for (int i = 0; i < parametresNum.Length; i++)
    {
        parametresNum[i]=int.Parse(parames[i]);
    }

    return parametresNum;
}

int[] GetIndFromString(string parametres)
{
    string[] parames = parametres.Split(",", System.StringSplitOptions.RemoveEmptyEntries);
    int[] parametresNum=new int[parames.Length];
    for (int i = 0; i < parametresNum.Length; i++)
    {
        parametresNum[i]=int.Parse(parames[i]);
    }

    return parametresNum;
}

void FindNumFromInd (int[] index, int[,] matrix)
{
    if (index[0]>matrix.GetLength(0)-1 || index[1]>matrix.GetLength(1)-1) WriteLine("В массиве нет числа с данным индексом");
    else WriteLine($"Значение элемента с индексом ({String.Join(", ", index)}) =  {matrix[index[0], index[1]]}");
}

void FindIndFromNum (int number, int[,] matrix)
{
    string answer=string.Empty;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i,j]==number) answer=answer+"("+i+","+" "+j+")"+" ";
        }
    }
    if (answer==string.Empty) 
    {
        WriteLine("Такого числа в массиве нет");
    }
    else WriteLine($"Число есть в массиве, его индекс {answer}");
}


double[] ArithAverageСolumns (int[,] matrix)
{
    double[] result=new double[matrix.GetLength(1)];
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            result[j]=result[j]+Convert.ToDouble(matrix[i,j]);
        }
        result[j]=result[j]/matrix.GetLength(0);
    }
    return result;
}