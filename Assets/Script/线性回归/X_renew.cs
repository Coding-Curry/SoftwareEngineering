using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class X_renew : MonoBehaviour
{
    public xxhg_storage storage;
    public TMP_InputField self;
    public inputfieldX_press other;
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
            storage.ListX[other.index]=0f;
            self.text="0.0";
          }
          else
          {
              storage.ListX[other.index]=float.Parse(self.text);
          }
            
        }
        
    }
}
