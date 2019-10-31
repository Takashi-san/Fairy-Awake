using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabSystem : MonoBehaviour
{   
    PlayerInput _pi;

    // Start is called before the first frame update
    void Start()
    {
        _pi = GetComponent<PlayerInput>();
        if (!_pi) 
        {
            Debug.LogError("No PlayerInput in the object!");
        }
    }

    // Update is called once per frame
    void Update() 
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.layer == 10)
        {
            other.transform.Rotate((Vector3.up + Vector3.left) * 90);
            Debug.Log(other.gameObject.name);
        }
    }
}

