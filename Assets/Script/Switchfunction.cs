using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchfunction : MonoBehaviour
{
    public GameObject panel;
    public GameObject menu;
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
        panel.gameObject.SetActive(true);
        menu.SetActive(false);
    }
}
