using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBehaviour : MonoBehaviour
{

	private Vector3 sheepDirection;
	private Rigidbody sheepRigidBody;
	
	// Use this for initialization
	void Start ()
	{
		sheepRigidBody = GetComponent<Rigidbody>();
		sheepDirection = Quaternion.Euler(0,Random.Range(0,360),0) * Vector3.forward;
		sheepDirection = sheepDirection.normalized;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		sheepRigidBody.MovePosition(transform.position + sheepDirection*Time.fixedDeltaTime);	
		
	}
}
