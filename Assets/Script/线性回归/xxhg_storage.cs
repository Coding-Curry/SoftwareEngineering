using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xxhg_storage : MonoBehaviour
{
    public List<float> ListX = new List<float>();
    public List<float> ListY = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float Average()
    {
        float s=0;
        for(int i=0;i<ListY.Count;i++)
        {
            s+=ListY[i];
        }
        return s/ListY.Count;
    }
}
