using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MatrixMultiple : MonoBehaviour
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
        int[] sum = new int[16];
        
        if(line1!=row2)//判断能否进行乘运算
        {
            StartCoroutine(ShowAndHideGameObject());//报错运行
        }
        else
        {
            for(int i=0;i<line2;i++)//筛选加入乘法运算的矩阵部分
            {
                for(int j=0;j<row1;j++)//结合矩阵的乘法规则进行计算
                {
                    if(line1==4)
                    {
                    int m1=int.Parse(matrix2[12+j].text);
                    int m2=int.Parse(matrix2[8+j].text);
                    int m3=int.Parse(matrix2[4+j].text);
                    int m4=int.Parse(matrix2[0+j].text);
                    int n1=int.Parse(matrix1[0+4*i].text);
                    int n2=int.Parse(matrix1[1+4*i].text);
                    int n3=int.Parse(matrix1[2+4*i].text);
                    int n4=int.Parse(matrix1[3+4*i].text);
                    sum[4*j+i]=m1*n1+m2*n2+m3*n3+m4*n4;
                    string k1=Convert.ToString(sum[4*j+i]);
                    summatrix[4*i+j].text=k1;
                }
                if(line1==3)
                    {
                    int m2=int.Parse(matrix2[8+j].text);
                    int m3=int.Parse(matrix2[4+j].text);
                    int m4=int.Parse(matrix2[0+j].text);
                    int n1=int.Parse(matrix1[0+4*i].text);
                    int n2=int.Parse(matrix1[1+4*i].text);
                    int n3=int.Parse(matrix1[2+4*i].text);
                    sum[4*j+i]=m2*n1+m3*n2+m4*n3;
                    string k1=Convert.ToString(sum[4*j+i]);
                    summatrix[4*i+j].text=k1;
                }
                    if(line1==2)
                    {
                    int m3=int.Parse(matrix2[4+j].text);
                    int m4=int.Parse(matrix2[0+j].text);
                    int n1=int.Parse(matrix1[0+4*i].text);
                    int n2=int.Parse(matrix1[1+4*i].text);
                    sum[4*j+i]=m3*n1+m4*n2;
                    string k1=Convert.ToString(sum[4*j+i]);
                    summatrix[4*i+j].text=k1;
                }
                if(line1==1)
                    {
                    int m4=int.Parse(matrix2[0+j].text);
                    int n1=int.Parse(matrix1[0+4*i].text);
                    sum[4*i+j]=m4*n1;
                    string k1=Convert.ToString(sum[4*j+i]);
                    summatrix[4*i+j].text=k1;
                }
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