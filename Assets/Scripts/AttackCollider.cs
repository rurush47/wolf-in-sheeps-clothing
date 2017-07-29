using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{

	public Wolf AnimalController;
	private bool _attack;
	
	void Update () {
		if (Input.GetButton(AnimalController.AttackButton))
		{
			_attack = true;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (/*other.gameObject.CompareTag("Owca") &&*/ _attack && !GameplayManager.Instance.Day)
		{
			Debug.Log("kaczka");
			Destroy(other.gameObject);
			AnimalController.EyesOn();
		}
		_attack = false;
	}
}
