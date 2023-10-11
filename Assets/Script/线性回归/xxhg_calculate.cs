using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System; 

public class xxhg_calculate : MonoBehaviour
{
     public xxhg_storage storage;
     public Text error;
     public TMP_InputField forecastx;
     public Text forecasty;
     public Text resulttext;

    public void click()
    {
        if(storage.ListX.Count != storage.ListY.Count || storage.ListX.Count==0 || storage.ListY.Count==0 )
        {
            error.text="输入有误，请检查";
        }
        else if(forecastx.text =="")
        {
            error.text="请输入待预测的特征值X";
        }
        else
        {
            error.text="";
            calculate();
        }
    }
    private void calculate()
    {
    
            // 计算线性回归
            float slope, intercept;
            LinearRegression(storage.ListX, storage.ListY, out slope, out intercept);

            //计算预测值列表
            List<float> predicted = new List<float>();
            for(int i=0;i<storage.ListX.Count;i++)
            {
                float temp=slope*storage.ListX[i]+intercept;
                predicted.Add(temp);
            }

            //计算r平方
            int n = storage.ListY.Count;
    
            float meanActual = storage.Average();

            double ssr = 0;
            for (int i = 0; i < n; i++)
            {
                double residual = storage.ListY[i] - predicted[i];
                ssr += residual * residual;
            }

            double sst = 0;
            for (int i = 0; i < n; i++)
            {
                double diff = storage.ListY[i] - meanActual;
                sst += diff * diff;
            }

            double rSquared = 1 - (ssr / sst);
            
            //预测值
            float x=float.Parse(forecastx.text);
            float y=slope*x+intercept;
            forecasty.text=y.ToString();
            resulttext.text="回归方程为:  y="+slope.ToString()+"x + "+intercept.ToString()+"\nR-Square = "+rSquared.ToString(); 
    }
    private void LinearRegression(List<float> x, List<float> y, out float slope, out float intercept)
    {
            int n = x.Count;
            float sumX = 0f, sumY = 0f, sumXY = 0f, sumXSquare = 0f;

            for (int i = 0; i < n; i++)
            {
                sumX += x[i];
                sumY += y[i];
                sumXY += x[i] * y[i];
                sumXSquare += x[i] * x[i];
            }

            slope = (n * sumXY - sumX * sumY) / (n * sumXSquare - sumX * sumX);
            intercept = (sumY - slope * sumX) / n;
    }

}
