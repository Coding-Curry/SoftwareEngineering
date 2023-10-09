using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MatrixAdd : MonoBehaviour
{
    public Text text1,text2,text3,text4;
    public Text[] matrix1,matrix2,summatrix;
    public GameObject Error;
            
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        int row1,line1,row2,line2;
        row1=int.Parse(text1.text);
        line1=int.Parse(text2.text);
        row2=int.Parse(text3.text);
        line2=int.Parse(text4.text);
        
        if(row1!=row2 || line1!=line2)//判断能否进行加运算
        {
            StartCoroutine(ShowAndHideGameObject());//报错运行
        }
        else
        {
            for(int i=0;i<=15;i++)//筛选加入加运算的矩阵部分
            {if((i%4)<=line1-1 && i<4*row1)
            {
                if(matrix1[i].text==""||matrix2[i].text=="")
                {
                    StartCoroutine(ShowAndHideGameObject());
                }
                int m=int.Parse(matrix1[i].text);//转换变量形式
                int n=int.Parse(matrix2[i].text);
                int k=m+n;
                string k1 = Convert.ToString(k);
                summatrix[i].text=k1;
            }
                
            }
        }
    }
      private IEnumerator ShowAndHideGameObject()
    {
        // 显示GameObject
        Error.SetActive(true);

        // 等待两秒
        yield return new WaitForSeconds(2f);

        // 隐藏GameObject
        Error.SetActive(false);
    }
}
