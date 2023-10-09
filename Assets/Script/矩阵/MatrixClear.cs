using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatrixClear : MonoBehaviour
{
    public Text[] text;
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
        for(int i=0;i<text.Length;i++)
        {
        text[i].text="";
        }

    }
}
