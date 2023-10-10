using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class 输入框点击 : MonoBehaviour
{
    private bool flag=false;
    public TMP_InputField self;
    public 输入列生成 other;
    public int index;

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
        if(self.text != "" && !flag)
        {
            flag=true;
            other.inputFieldTMPPrefab=self;
            other.OnInputEndEdit();
            index=other.index++;
        }
    }
    public bool isdone()
    {
        return flag;
    }
}
