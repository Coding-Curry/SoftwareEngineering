using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class VectorMinus : MonoBehaviour
{
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
            for(int i=0;i<3;i++)//向量相加
            {
                if(matrix1[i].text==""||matrix2[i].text=="")
                {
                    StartCoroutine(ShowAndHideGameObject());
                }
                int m=int.Parse(matrix1[i].text);//转换变量形式
                int n=int.Parse(matrix2[i].text);
                int k=m-n;
                string k1 = Convert.ToString(k);
                summatrix[i].text=k1;
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
