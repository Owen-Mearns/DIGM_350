using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirewoodScript : MonoBehaviour {
    private GameObject manager;
    private void Start() {
        manager = GameObject.Find("FirewoodManager");
    }
    public void CollectFirewood() {
        manager.GetComponent<ItemManager>().IncreaseCollected();
        Destroy(gameObject);
    }
}
