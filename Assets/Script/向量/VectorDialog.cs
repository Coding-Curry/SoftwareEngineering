using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class VectorDialog : MonoBehaviour
{
    public Text textbotton;
    public Text[] txt;
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
        for(int i=0;i<=5;i++)
        {
            if(txt[i].text=="") //判断当前要输入的方格
            {
                txt[i].text=textbotton.text;
                break;
            }
        }
        
    }
}
