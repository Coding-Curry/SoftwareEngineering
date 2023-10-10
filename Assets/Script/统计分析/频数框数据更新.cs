using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class 频数框数据更新 : MonoBehaviour
{
    public 数据存储与计算 storage;
    public TMP_InputField self;
    public 频数框点击 other;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void renew()
    {
        if(other.isdone())//防止首次输入未完成就更新
        {
            if(self.text=="")
          {
            storage.ListFreq[other.index]=0;
            self.text="0";
          }
          else
          {
              storage.ListFreq[other.index]=int.Parse(self.text);
          }
            

        }
        
    }
}
