using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMove : MonoBehaviour
{
    public enum State{
        move,
        stop,
        inbetween
    }

    public State state;

    public     
    PlayerInput _pi;
    Rigidbody _rb;
    public GameObject Player;

    public float radius = 1.7f;

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // Start is called before the first frame update
    void Start()
    {
        state = StoneMove.State.stop;

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
        if (_pi.GetInteract() && Vector3.Distance(Player.transform.position, transform.position) <= radius){
            state = StoneMove.State.move;
            Debug.Log("Close enough");
        }
        else{
            state = StoneMove.State.stop;
        }
    }

    public void MoveStone(){
        
    }
}
