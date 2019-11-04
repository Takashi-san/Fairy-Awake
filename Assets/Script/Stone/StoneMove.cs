using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public enum State{
        move,
        stop,
        inbetween
    }

    public State state;

    
    PlayerInput _pi;
    Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        state = Stone.State.stop;

        _pi = gameObject.GetComponent<PlayerInput>();
        _rb = gameObject.GetComponent<Rigidbody>();

		if (!_pi) {
			Debug.LogError("No PlayerInput in the object!");
		}
        if (!_rb) {
			Debug.LogError("No RigidBody in the object!");
		}
    }

    // Update is called once per frame
    void Update()
    {
        if (_pi.GetInteract()){
            state = Stone.State.move;
        }
        else{
            state = Stone.State.stop;
        }
    }

    public void MoveStone(){
        
    }
}
