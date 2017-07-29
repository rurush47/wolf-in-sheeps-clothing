using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{

	private BoxCollider _collider;
	// Use this for initialization
	void Start ()
	{
		_collider = GetComponent<BoxCollider>();
	}

	void Update () {
		
	}

	private void OnTriggerStay(Collider other)
	{
		Debug.Log("Collides");

		if (other.gameObject.CompareTag("Owca") && Input.GetButton("Jump"))
		{
			Destroy(other.gameObject);
		}
	}
}
