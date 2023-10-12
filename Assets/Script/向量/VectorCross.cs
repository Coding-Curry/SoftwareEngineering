using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class VectorCross : MonoBehaviour
{
    public Text[] vector1;
    public Text[] vector2;
    public Text[] sumVector;
    
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
                if(vector1[i].text==""||vector2[i].text=="")
                {
                    StartCoroutine(ShowAndHideGameObject());
                }
            }
                int m11=int.Parse(vector1[0].text);//转换变量形式
                int m12=int.Parse(vector1[1].text);
                int m13=int.Parse(vector1[2].text);
                int m21=int.Parse(vector2[0].text);
                int m22=int.Parse(vector2[1].text);
                int m23=int.Parse(vector2[2].text);
                Vector3 Vector1=new Vector3(m11,m12,m13);
                Vector3 Vector2=new Vector3(m21,m22,m23);
                Vector3 crossProduct = Vector3.Cross(Vector1, Vector2);
                int intX = Mathf.RoundToInt(crossProduct.x);
                int intY = Mathf.RoundToInt(crossProduct.y);
                int intZ = Mathf.RoundToInt(crossProduct.z);
                string k1 = Convert.ToString(intX);
                string k2 = Convert.ToString(intY);
                string k3 = Convert.ToString(intZ);
                sumVector[0].text=k1;
                sumVector[1].text=k2;
                sumVector[2].text=k3;
                
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
