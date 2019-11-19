using UnityEngine;

public class InteractItem : MonoBehaviour
{
	bool _interact = false;
	public string item;
    // Start is called before the first frame update
    void OnTriggerStay (Collider c){
        if (c.gameObject.tag == "Interactable"){
			_interact = Input.GetKeyDown(KeyCode.E);
			item = c.gameObject.name;
		}
    }

	public bool GetInteract (){
		return _interact;
	}
}
