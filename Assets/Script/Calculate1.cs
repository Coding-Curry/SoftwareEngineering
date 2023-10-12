using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class Calculate1 : MonoBehaviour
{
    public Text text;
    public Text text2;
    public Text text3;

    public void Click()
    {
        try
        {
            string expression = text.text;
            // 替换运算符和函数的符号
            expression = expression.Replace("sin", "Sin")
                .Replace("cos", "Cos")
                .Replace("ln", "log")
                .Replace("π", Math.PI.ToString())
                .Replace("e", Math.E.ToString())
                .Replace("pow", "Mathf.Pow")
                .Replace("ANS", text3.text);

            // 计算结果
            float result = EvaluateExpression(expression);
            string k1 = Convert.ToString(result);
            text2.text = text.text;
            text.text = k1;
        }
        catch (Exception ex)
        {
            Debug.LogError("计算错误：" + ex.Message);
        }
    }

    // 计算算式的结果
    private float EvaluateExpression(string expression)
    {
        // 替换掉除法符号以外的运算符号
        expression = expression.Replace("/", "/").Replace("*", "*");

        // 利用字典存储数学函数名
        Dictionary<string, Func<float, float>> mathFunctions = new Dictionary<string, Func<float, float>>();
        mathFunctions["Sin"] = Mathf.Sin;
        mathFunctions["Cos"] = Mathf.Cos;
        mathFunctions["log"] = Mathf.Log;

        // 解析表达式并计算结果
        float result = EvaluateExpressionRecursive(expression, mathFunctions);
        return result;
    }

    // 递归解析表达式并计算结果
    private float EvaluateExpressionRecursive(string expression, Dictionary<string, Func<float, float>> mathFunctions)
    {
        // 判断是否是数学函数
        foreach (var mathFunction in mathFunctions)
        {
            string functionName = mathFunction.Key;
            int startindex = expression.IndexOf(functionName+"(");
            if (startindex >=0 )
            {
                string judgestring=expression.Substring(startindex);
                int gap = expression.Length-judgestring.Length;
                int endindex=judgestring.IndexOf(")");
                if(endindex<0 )
                {
                    throw new Exception("无效的表达式，缺少右括号： " + expression);
                }
                else
                {
                    endindex+=gap;
                    string argumentExpression = expression.Substring(startindex+functionName.Length+1, endindex -startindex- functionName.Length-1);
                    float argumentValue = EvaluateExpressionRecursive(argumentExpression, mathFunctions);
                    float temp= mathFunction.Value(argumentValue);
                    string remain;
                    if(endindex==expression.Length-1)
                    {
                        remain=expression.Substring(0,startindex)+temp.ToString();
                    }
                    else
                    {
                         remain=expression.Substring(0,startindex)+temp.ToString()+expression.Substring(endindex+1);
                    }
                    
                    return EvaluateExpressionRecursive(remain, mathFunctions);
                }
                
            }
        }
        
        // 处理括号
    while (expression.Contains("("))
    {
        int openingIndex = expression.LastIndexOf("(");
        int closingIndex = expression.IndexOf(")", openingIndex);

        if (closingIndex < 0)
        {
            throw new Exception("无效的表达式，缺少右括号： " + expression);
        }

        string subExpression = expression.Substring(openingIndex + 1, closingIndex - openingIndex - 1);

        float result = EvaluateExpressionRecursive(subExpression, mathFunctions);
        expression = expression.Remove(openingIndex, closingIndex - openingIndex + 1).Insert(openingIndex, result.ToString());
    }
        // 判断是否是数值
        if (float.TryParse(expression, out float value))
        {
            return value;
        }

        

        // 判断是否是乘方运算
        int involutionIndex = expression.IndexOf("^");
        if (involutionIndex >= 0)
        {
            // 递归计算左侧和右侧表达式的结果
            string leftExpression = expression.Substring(0, involutionIndex);
            string rightExpression = expression.Substring(involutionIndex + 1);
            float leftValue = EvaluateExpressionRecursive(leftExpression, mathFunctions);
            float rightValue = EvaluateExpressionRecursive(rightExpression, mathFunctions);

            // 执行乘方运算
            float result = Mathf.Pow(leftValue, rightValue);
            return result;
        }

        // 判断是否是乘法或除法运算
        
        int multiplyIndex = expression.IndexOf("+");
int divideIndex = expression.IndexOf("-");
if (multiplyIndex >= 0 || divideIndex >= 0)
{
    int operatorIndex = multiplyIndex >= 0 ? multiplyIndex : divideIndex;

    string leftExpression = expression.Substring(0, operatorIndex);
    string rightExpression = expression.Substring(operatorIndex + 1);
    
    // 处理负数开头的情况
    if (operatorIndex == 0)
    {
        leftExpression = "-" + leftExpression;
    }
    
    float leftValue = EvaluateExpressionRecursive(leftExpression, mathFunctions);
    float rightValue = EvaluateExpressionRecursive(rightExpression, mathFunctions);

    float result = 0;
    if (multiplyIndex >= 0)
    {
        result = leftValue + rightValue;
    }
    else
    {
        result = leftValue - rightValue;
    }

    return result;
}

        // 判断是否是加法或减法运算
        int plusIndex = expression.IndexOf("*");
        int minusIndex = expression.IndexOf("/");
        if (plusIndex >= 0 || minusIndex >= 0)
        {
            // 找到加法和减法运算符的索引
            int operatorIndex = plusIndex >= 0 ? plusIndex : minusIndex;

            // 递归计算左侧和右侧表达式的结果
            string leftExpression = expression.Substring(0, operatorIndex);
            string rightExpression = expression.Substring(operatorIndex + 1);
            float leftValue = EvaluateExpressionRecursive(leftExpression, mathFunctions);
            float rightValue = EvaluateExpressionRecursive(rightExpression, mathFunctions);

            // 执行加法或减法运算
            float result = 0;
            if (plusIndex >= 0)
            {
                result = leftValue * rightValue;
            }
            else
            {
                result = leftValue / rightValue;
            }

            return result;
        }

        throw new Exception("无效的表达式：" + expression);
    }
}