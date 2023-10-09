using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MatrixDialog : MonoBehaviour
{
    public Text textbotton;
    public Text[] txt;
    public GameObject[] box;
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
        for(int i=0;i<=txt.Length;i++)
        {
            if(txt[i].text=="" && box[i].gameObject.activeSelf==true) //判断当前要输入的方格
            {
                txt[i].text=textbotton.text;
                break;
            }
        }
        
    }
}
