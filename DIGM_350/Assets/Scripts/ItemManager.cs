using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    public static int collectedWood = 0;
    public int quota; 
    public static bool quotaSatisfied = false;
    public void IncreaseCollected() {
        collectedWood++;
        if (collectedWood >= quota) {
            quotaSatisfied = true;
            Debug.Log("Quota satisfied");
        }
    }
}
