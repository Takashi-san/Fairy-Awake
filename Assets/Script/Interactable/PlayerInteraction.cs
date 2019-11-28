using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    InteractItem _interactArea;
    

    void Start(){
        _interactArea = gameObject.GetComponentInChildren<InteractItem>();
    }

    public string ObjectToInteracte(){
        return _interactArea.item;
    }
    

	public bool GetInteractArea (){
        if(_interactArea.GetInteract()) 
            Debug.Log(_interactArea.item);
		return _interactArea.GetInteract();
	}
    
}
