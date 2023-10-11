using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Yshengcheng : MonoBehaviour
{
    public TMP_InputField inputFieldTMPPrefab; // 父级输入框
    public Transform inputFieldParent; // 父级Transform，新Input Field将附加到此处
    public float spacing=60f;
    public xxhg_storage storage;
    public int index=0;

    public void OnInputEndEdit()
    {
        
            // 创建一个新的Input Field并将其附加到指定父级Transform下
            TMP_InputField newInputFieldTMP = Instantiate(inputFieldTMPPrefab,inputFieldParent);
            // 获取新Input Field的RectTransform
            RectTransform newInputFieldRectTransform = newInputFieldTMP.GetComponent<RectTransform>();

            // 将新Input Field的anchoredPosition向下偏移指定距离
            Vector2 newPosition = new Vector2(0.0f, -spacing);
            newInputFieldRectTransform.anchoredPosition += newPosition;
            newInputFieldTMP.text="";
            

            //把数据存储到storage
            storage.ListY.Add(float.Parse(inputFieldTMPPrefab.text));
            
    }
}
