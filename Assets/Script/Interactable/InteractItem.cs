using UnityEngine;

public class InteractItem : MonoBehaviour
{
	InputManager _inputManager;
	bool _interact = false;
	public string item;

	void Start(){
		_inputManager = FindObjectOfType<InputManager>().GetComponent<InputManager>();

		if (!_inputManager) {
			Debug.LogError("No InputManager found in the scene!");
		}
	}

    void OnTriggerStay (Collider c){
        if (c.gameObject.tag == "Interactable"){
			_interact = _inputManager.GetInteract();
			item = c.gameObject.name;
		}
    }

	public bool GetInteract (){
		return _interact;
	}
}
