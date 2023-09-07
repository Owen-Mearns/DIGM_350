using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCond : MonoBehaviour
{
    public List<GameObject> images = new List<GameObject>();
    // Start is called before the first frame update
    void OnEnable()
    {
        if(GirdleHandler.girdleGivenBack == true)
        {
           images[1].gameObject.SetActive(true);
        } else {
           images[0].gameObject.SetActive(true);
        }
    }

 
}
