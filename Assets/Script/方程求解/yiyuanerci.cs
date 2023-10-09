using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; 

public class yiyuanerci : MonoBehaviour
{
    public Text texta;
    public Text textb;
    public Text textc;
    public Text resulttext;
    private string result;
    public double answer1;
    public double answer2;
    

    public void calculate()
    {
        string text = texta.text;
        double a=double.Parse(text);
        text = textb.text;
        double b=double.Parse(text);
        text = textc.text;
        double c=double.Parse(text);
        //初始化系数
       if(a==0)
       {
           if(b==0)
          {
              if(c==0)
              {
                result="x为任意实数";
              }
              else
              {
                result="x无解";
              }
          }
          else
         {
            answer1=-c/b;
            result="x="+answer1.ToString();
         }
       }
       else
       {
           double delta=b*b-4*a*c;
           //虚数解
           if(delta<0)
           {
               delta=-delta;
               answer1=-b/2/a;
               answer2=Math.Abs(Math.Sqrt(delta)/2/a);
               if(answer1!=0)
               {
                   result="x1="+answer1.ToString()+"+"+answer2.ToString()+"i"+"    x2="+answer1.ToString()+"-"+answer2.ToString()+"i";
               }
               else
               {
                   result="x1="+answer2.ToString()+"i"+"    x2="+"-"+answer2.ToString()+"i";
               }
           }
           //实数解
           else if(delta==0)
           {
               answer1=-b/2/a;
               result="x1=x2="+answer1.ToString();
           }
           else
           {
               answer1=-b/2/a+Math.Sqrt(delta)/2/a;
               answer2=-b/2/a-Math.Sqrt(delta)/2/a;
               result="x1="+answer1.ToString()+"    x2="+answer2.ToString();
           }
       }
       
       
       resulttext.text=result;
    }

    

    
}
