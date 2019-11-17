using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public void CollisionDetected(InteractItem childInteraction)
     {
         Debug.Log("child collided");
     }
}
