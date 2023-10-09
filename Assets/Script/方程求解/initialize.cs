using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialize : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
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
      panel1.gameObject.SetActive(false);
      panel2.gameObject.SetActive(true);
    }
}
