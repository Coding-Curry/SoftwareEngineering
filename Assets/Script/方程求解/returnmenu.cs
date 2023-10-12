using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnmenu : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public GameObject panel7;
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
       panel1.gameObject.SetActive(false);
       panel2.gameObject.SetActive(true);
       panel3.gameObject.SetActive(false);
       panel4.gameObject.SetActive(false);
       panel5.gameObject.SetActive(false);
       panel6.gameObject.SetActive(false);
       panel7.gameObject.SetActive(false);
       menu.gameObject.SetActive(true);
    }
}
