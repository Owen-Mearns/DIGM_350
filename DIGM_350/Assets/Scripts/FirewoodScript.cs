using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirewoodScript : MonoBehaviour {
    private GameObject manager;
    [SerializeField] public string managerToFind;
    private void Start() {
        manager = GameObject.Find(managerToFind);
    }
    public void CollectFirewood() {
        manager.GetComponent<ItemManager>().IncreaseCollected();
        Destroy(gameObject);
    }
}
