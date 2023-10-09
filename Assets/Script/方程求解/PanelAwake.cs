using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelAwake : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;

    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;

    
    // 每次方程求解界面激活时初始化所有内容
    void OnEnable()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        panel4.SetActive(false);
        panel5.SetActive(false);
        panel6.SetActive(false);

        text1.text="";
        text2.text="";
        text3.text="";
        text4.text="";
        text5.text="";
        text6.text="";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
