using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AColliderDog : MonoBehaviour {

	private BoxCollider _collider;
	public AnimalController AnimalController;
	private bool _attack;
	
	void Start ()
	{
		_collider = GetComponent<BoxCollider>();
	}

	void Update () {
		if (Input.GetButton(AnimalController.AttackButton))
		{
			_attack = true;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Owca") && _attack)
		{
			Destroy(other.gameObject);
			_attack = false;
		}
		
		if (other.gameObject.CompareTag("Wilk") && _attack)
		{
			Destroy(other.gameObject);
			_attack = false;
		}
	}
}
