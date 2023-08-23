using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCond : MonoBehaviour
{
    public List<GameObject> images = new List<GameObject>();
    public bool hasGirdle;
    // Start is called before the first frame update
    void Start()
    {
        if(hasGirdle == true)
        {
           images[0].gameObject.SetActive(true);
        }
    }

 
}
