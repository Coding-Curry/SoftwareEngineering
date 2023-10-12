using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sanyuanyici : MonoBehaviour
{
    public List<TMP_InputField> xishulist;
    public Text resulttext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        foreach(var xishu in xishulist)//检查所有系数非空
        {
            if(xishu.text=="")
            {
                return;
            }
        }
        calculate();
    }
    
    public void calculate()
    {
        float  a1,a2,a3,b1,b2,b3,c1,c2,c3,d1,d2,d3;
        int i=0;
        //初始化系数
        a1=float.Parse(xishulist[i++].text);
        a2=float.Parse(xishulist[i++].text);
        a3=float.Parse(xishulist[i++].text);
        b1=float.Parse(xishulist[i++].text);
        b2=float.Parse(xishulist[i++].text);
        b3=float.Parse(xishulist[i++].text);
        c1=float.Parse(xishulist[i++].text);
        c2=float.Parse(xishulist[i++].text);
        c3=float.Parse(xishulist[i++].text);
        d1=float.Parse(xishulist[i++].text);
        d2=float.Parse(xishulist[i++].text);
        d3=float.Parse(xishulist[i++].text);


        // 使用克莱姆法则解三元一次方程组
        float determinant = a1*(b2*c3-c2*b3)-b1*(a2*c3-c2*a3)+c1*(a2*b3-b2*a3);
        float determinantx = b1*(c2*d3-c3*d2)-c1*(b2*d3-b3*d2)+d1*(b2*c3-b3*c2);
        float determinanty = a1*(c2*d3-c3*d2)-c1*(a2*d3-a3*d2)+d1*(a2*c3-a3*c2);
        float determinantz = a1*(b2*d3-b3*d2)-b1*(a2*d3-a3*d2)+d1*(a2*b3-a3*b2);


        if (Mathf.Approximately(determinant, 0.0f))
        {
            if(Mathf.Approximately(determinantx, 0.0f) && Mathf.Approximately(determinanty, 0.0f) && Mathf.Approximately(determinantz, 0.0f))
            {
                resulttext.text="方程组无唯一解";
                return;
            }
            else
            {
                resulttext.text="方程组无解";
                return;
            }
        }
        else
        {
            float x = determinantx / determinant;
            float y = -determinanty / determinant;
            float z = determinantz / determinant;
            resulttext.text="x="+x.ToString()+"\ny="+y.ToString()+"\nz="+z.ToString();
        }
    }
}
