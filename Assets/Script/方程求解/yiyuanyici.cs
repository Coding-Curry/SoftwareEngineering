using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yiyuanyici : MonoBehaviour
{
    public Text texta;
    public Text textc;
    public Text resulttext;
    private string result;
    public double answer;
    
    // Start is called before the first frame update
    public void calculate()
    {
        string text = texta.text;
        double a=float.Parse(text);
        text = textc.text;
        double c=float.Parse(text);
       if(a==0)
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
           answer=c/a;
          result="x="+answer.ToString();
       }
       resulttext.text=result;
    }

    

    
}
