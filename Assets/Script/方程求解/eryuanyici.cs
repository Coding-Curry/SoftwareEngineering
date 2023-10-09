using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; 

public class eryuanyici : MonoBehaviour
{
    public Text texta1;
    public Text textb1;
    public Text textc1;
    public Text texta2;
    public Text textb2;
    public Text textc2;
    public Text resulttext;
    private string result;
    public double answer1;
    public double answer2;
    

    public void calculate()
    {
        double a1=double.Parse(texta1.text);
        double b1=double.Parse(textb1.text);
        double c1=double.Parse(textc1.text);
        double a2=double.Parse(texta2.text);
        double b2=double.Parse(textb2.text);
        double c2=double.Parse(textc2.text);
        //初始化系数矩阵

        // 计算方程组的解
        double determinant = a1 * b2 - a2 * b1;
        double determinantx = b1*c2-b2*c1;
        double determinanty = a1*c2-a2*c1;
        //计算D，Dy，Dx
        if (determinant == 0)
        {
           
           if(determinantx !=0 || determinanty !=0) // 方程组无解
            {
                result="方程组无解";
            }
            else
            {
                result="方程组有无穷多组解";
            }
        }
        else
        {
            // 计算解的x和y值
            double answer1 = (c1 * b2 - c2 * b1) / determinant;
            double answer2= (a1 * c2 - a2 * c1) / determinant;
            result="x="+answer1.ToString()+"     y="+answer2.ToString();
            
        }
        
       
       
       resulttext.text=result;
    }

    

    
}
