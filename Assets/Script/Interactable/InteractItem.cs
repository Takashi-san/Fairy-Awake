using UnityEngine;

public class InteractItem : MonoBehaviour
{
	bool _interact = false;
    // Start is called before the first frame update
    void OnTriggerStay (Collider c){
        if (c.gameObject.tag == "Interactable"){
			_interact = Input.GetKeyDown(KeyCode.E);
		}
    }

	public bool GetInteract (){
		return _interact;
	}
}
