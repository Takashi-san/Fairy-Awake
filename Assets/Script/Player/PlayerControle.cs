using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControle : MonoBehaviour
{
    PlayerInput _pi;
    // Start is called before the first frame update
    void Start()
    {
        _pi = gameObject.GetComponent<PlayerInput>();

		if (!_pi) {
			Debug.LogError("No PlayerInput in the object!");
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
