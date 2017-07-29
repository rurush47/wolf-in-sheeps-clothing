using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{

	private BoxCollider _collider;
	public Wolf AnimalController;
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
		if (/*other.gameObject.CompareTag("Owca") &&*/ _attack)
		{
			Debug.Log("kaczka");
			Destroy(other.gameObject);
			AnimalController.EyesOn();
		}
		_attack = false;
	}
}
