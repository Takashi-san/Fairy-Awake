using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabSystem : MonoBehaviour
{   
    bool grabEvent;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update() 
    {
        if (!GetComponentInParent<PlayerInput>().GetGrab() && grabEvent)
        {
            grabEvent = false;
        }
        if (GetComponentInParent<PlayerInput>().GetGrab())
        {
            grabEvent = true;
        }    
    }
    void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.layer == 10 && grabEvent)
        {   
            // #DUVIDA: O Item vira filho do gameobject como o planejado mas não ele se movimenta junto
            other.gameObject.transform.SetParent(this.gameObject.GetComponentInParent<Transform>());
            // Debug.Log(this.gameObject.GetComponentInParent<Transform>().name);
        }
    }
}

