using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnsEqual : MonoBehaviour
{
    public Text text1;
    public Text text2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()//给ANS赋值
    {
        text2.text=text1.text;
    }
}
