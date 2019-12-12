using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    bool _hasItem;
    void Start()
    {
        _hasItem = false;
    }

    void Update() {
        // Debug.Log(_hasItem);
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 10) {
            _hasItem = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.layer == 10 && _hasItem == true) {
            _hasItem = false;
        }
    }

    public bool HasItem() {
        return _hasItem;
    }
}
