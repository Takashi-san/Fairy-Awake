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

    public static class Const {
        public const float TimeToReset = 2f;
    }

    public float radius = 1.7f;
    public float timer = Const.TimeToReset;
    [SerializeField] int _velToMove = 2;
    float _dist_x;
    float _dist_z;

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
        switch (state)
        {
            case StoneMove.State.stop:
                if (_pi.GetInteract() && Vector3.Distance(Player.transform.position, transform.position) <= radius){
                    state = StoneMove.State.move;
                    Debug.Log("Close enough");
                    Debug.Log("State = move");
                    _dist_x= transform.position.x - Player.transform.position.x;
                    _dist_z= transform.position.z - Player.transform.position.z;
                    Debug.Log("X: " + _dist_x + ", Z: " + _dist_z);
                }
                _rb.useGravity = true;
                break;
            case StoneMove.State.inbetween:
                
                timer -= Time.deltaTime;
                if (timer <= 0){
                    timer = Const.TimeToReset;
                    state = StoneMove.State.stop;
                    _rb.velocity = Vector3.zero;
                    _rb.useGravity = true;
                }
                break;
            case StoneMove.State.move:
                _rb.useGravity = false;
                if( Mathf.Abs(_dist_z) <  Mathf.Abs(_dist_x)){
                    _rb.velocity = new Vector3(_velToMove * _dist_x / Mathf.Abs(_dist_x), 0, 0);
                }
                else {
                    _rb.velocity = new Vector3(0, 0, _velToMove * _dist_z / Mathf.Abs(_dist_z));
                }
                state = StoneMove.State.inbetween;
                break;
            default:
                state = StoneMove.State.stop;
                break;
        }
    }

    public void MoveStone(){
        
    }
}
