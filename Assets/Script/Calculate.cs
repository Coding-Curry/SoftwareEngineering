using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class Calculate : MonoBehaviour
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
                .Replace("π", "3.141592653589793238462643383279502884197169399375105820974944592307816406286208998628034825342117067982148086513282306647093844609550582231725359408128481117450284102701938521105559644622948954930381964428810975665933446128475648233786783165271201909145648566923460348610454326648213393607260249141273724587006606315588174881520920")
                .Replace("e", "2.718281828459045235360287471352662497757247093699959574966967627724076630353547594571382178525166427")
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
            int index = 0;
        while (index < expression.Length - 6)
        {
            bool foundFunction = false;

            foreach (var mathFunction in mathFunctions)
            {
                string functionName = mathFunction.Key;

                if (expression.IndexOf(functionName + "(", index) == index)
                {
                    // 寻找右括号
                    int closingIndex = expression.IndexOf(")", index + functionName.Length + 1);
                    if (closingIndex < 0)
                    {
                        throw new Exception("无效的表达式，缺少右括号：" + expression);
                    }

                    string argumentExpression = expression.Substring(index + functionName.Length + 1, closingIndex - index - functionName.Length - 1);
                    float argumentValue = EvaluateExpressionRecursive(argumentExpression, mathFunctions);

                    // 替换函数表达式的部分为结果值
                    string argumentString = expression.Substring(index, closingIndex - index + 1);
                    expression = expression.Replace(argumentString, mathFunction.Value(argumentValue).ToString());
                    foundFunction = true;
                    
                    // 更新索引位置
                    index += mathFunction.Value(argumentValue).ToString().Length;
                    
                    break;
                }
            }

            if (!foundFunction)
            {
                index++;
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
            // 找到乘法和除法运算符的索引
            int operatorIndex = multiplyIndex >= 0 ? multiplyIndex : divideIndex;

            // 递归计算左侧和右侧表达式的结果
            string leftExpression = expression.Substring(0, operatorIndex);
            string rightExpression = expression.Substring(operatorIndex + 1);
            float leftValue = EvaluateExpressionRecursive(leftExpression, mathFunctions);
            float rightValue = EvaluateExpressionRecursive(rightExpression, mathFunctions);

            // 执行乘法或除法运算
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