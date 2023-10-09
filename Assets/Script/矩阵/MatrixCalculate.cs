using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class MatrixCalculate : MonoBehaviour
{
    public int[,] matrixA;
    public int[,] matrixB;
    private void Start()
    {
        // 创建两个矩阵
        // 打印原始矩阵
        Debug.Log("Matrix A:");
        PrintMatrix(matrixA);
        Debug.Log("Matrix B:");
        PrintMatrix(matrixB);

        // 矩阵加法
        int[,] sumMatrix = AddMatrices(matrixA, matrixB);
        Debug.Log("Matrix A + Matrix B:");
        PrintMatrix(sumMatrix);

        // 矩阵乘法
        int[,] productMatrix = MultiplyMatrices(matrixA, matrixB);
        Debug.Log("Matrix A * Matrix B:");
        PrintMatrix(productMatrix);
    }

    private int[,] AddMatrices(int[,] matrixA, int[,] matrixB)
    {
        int rows = matrixA.GetLength(0);
        int columns = matrixA.GetLength(1);
        int[,] resultMatrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                resultMatrix[i, j] = matrixA[i, j] + matrixB[i, j];
            }
        }

        return resultMatrix;
    }

    private int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
    {
        int rowsA = matrixA.GetLength(0);
        int columnsA = matrixA.GetLength(1);
        int columnsB = matrixB.GetLength(1);
        int[,] resultMatrix = new int[rowsA, columnsB];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < columnsB; j++)
            {
                for (int k = 0; k < columnsA; k++)
                {
                    resultMatrix[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }

        return resultMatrix;
    }

    private void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        string matrixString = "";
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrixString += matrix[i, j] + "\t";
            }
            matrixString += "\n";
        }

        Debug.Log(matrixString);
    }
}