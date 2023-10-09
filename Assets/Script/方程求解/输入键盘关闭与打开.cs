using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 输入键盘关闭与打开 : MonoBehaviour
{
    public GameObject panel;
    public Text text;
    public Text number;//数字输入内容
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(number.text != "")
        { 
           text.gameObject.SetActive(false);//输入数字后取消显示提示信息
        } 
        else
        {
            text.gameObject.SetActive(true);
        }
    }

    public void click()
    {
        panel.SetActive(!panel.activeSelf);
    }
}
