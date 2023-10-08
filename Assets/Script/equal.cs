using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class equal : MonoBehaviour
{
    public Text text;
    public Text text2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    static float EvaluateExpression(string expression)
    {
        try
        {
            var result = new System.Data.DataTable().Compute(expression, null);
            return Convert.ToInt32(result);
        }
        catch (Exception)
        {
            Console.WriteLine("无法计算给定的算式。请确认输入的格式是否正确。");
            return 0;
        }
    }
    public void click()
    {
        string value = text.text;
        text2.text=text.text+"=";
        string stringValue = EvaluateExpression(value).ToString();
        text.text=stringValue;
    }
}
