using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System; 

public class 数据存储与计算 : MonoBehaviour
{
    public List<double> ListX = new List<double>();
    public List<int> ListFreq = new List<int>();
    public Text avgtext;
    public Text maxtext;
    public Text mintext;
    public Text sumtext;
    public Text counttext;
    public Text youpianfangchatext;
    public Text youpianbiaozhunchatext;
    public Text wupianfangchatext;
    public Text wupianbiaozhunchatext;
    public Text error;
    
    public

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
        if(ListX.Count != ListFreq.Count || ListX.Count==0 || ListFreq.Count==0)
        {
            error.text="输入有误，请检查";
        }
        else
        {
            calculate();
        }
    }

    public void calculate()
    {
        //单变量计算
        int count=0;
        for(int j=0;j<ListFreq.Count;j++)
        {
            count+=ListFreq[j];
        }
        
        double s=0,max=ListX[0],min=ListX[0];
        for(int i=0;i<ListX.Count;i++)
        {
            s+=ListX[i]*ListFreq[i];
            max= ListX[i]>=max?ListX[i]:max;
            min= ListX[i]<=min?ListX[i]:min;
        }
        double avg = s/count;
        
        double var=0;
        
        for(int k=0;k<ListX.Count;k++)
        {
           var+=(ListX[k]-avg)*(ListX[k]-avg)*ListFreq[k];
        }
        avgtext.text="样本均值="+avg.ToString();
        maxtext.text="样本数据最大值="+max.ToString();
        mintext.text="样本数据最小值="+min.ToString();
        sumtext.text="样本数据总和="+s.ToString();
        counttext.text="样本数据个数="+count.ToString();
        youpianfangchatext.text="有偏方差="+(var/count).ToString();
        youpianbiaozhunchatext.text="有偏标准差="+Math.Sqrt(var/count).ToString();
        wupianfangchatext.text="无偏方差="+(var/(count-1)).ToString();
        wupianbiaozhunchatext.text="无偏标准差="+Math.Sqrt(var/(count-1)).ToString();
    }
    
}
