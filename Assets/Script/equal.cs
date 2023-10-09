using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Data;
using System.Text.RegularExpressions;

public class equal : MonoBehaviour
{
    public Text text;
    public Text text2;
    private static double Ans;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    static double EvaluateExpression(string expression)
    {
        try
        {
            expression=ReplaceMathFunctions(expression);
            var result = new DataTable().Compute(expression, null);
            Ans=Convert.ToDouble(result);
            return Convert.ToDouble(result);
        }
        catch (Exception)
        {
            Console.WriteLine("无法计算给定的算式。请确认输入的格式是否正确。");
            return 0.0;
        }
    }
    public void click()
    {
        string value = text.text;
        text2.text=text.text+"=";
        string stringValue = EvaluateExpression(value).ToString();
        if(stringValue=="0.0")
        {
            text.text= "无法计算给定的算式。请确认输入的格式是否正确。";
        }
        else
        {
           text.text=stringValue; 
        }
        
        
    }
    static string ReplaceMathFunctions(string input)
    {
        // 使用正则表达式替换cos和sin函数
        input = Regex.Replace(input, @"cos\(([^)]+)\)", "Math.Cos($1)");
        input = Regex.Replace(input, @"sin\(([^)]+)\)", "Math.Sin($1)");

        // 在这里可以添加更多的数学函数替换规则，根据需要

        return input;
    }
}
