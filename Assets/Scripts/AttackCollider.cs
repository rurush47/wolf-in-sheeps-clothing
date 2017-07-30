	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{

    // WOLF

	public Wolf AnimalController;
	public float AttackCooldown;
	private float _currentCooldownTimer;
	private bool _attack;
	private bool _onCooldown;

	private void Start()
	{
		_currentCooldownTimer = AttackCooldown;
	}

	void Update () {
		if (_onCooldown == false)
		{
			if (Input.GetButton(AnimalController.AttackButton))
			{
				_onCooldown = true;
			}
		}
		else
		{
			if (_currentCooldownTimer > 0)
			{
				_currentCooldownTimer -= Time.deltaTime;
			}
			else
			{
				_currentCooldownTimer = AttackCooldown;
				_onCooldown = false;
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Owca") && Input.GetButton(AnimalController.AttackButton) && !_onCooldown &&
		    !GameplayManager.Instance.Day)
		{
			other.enabled = false;
			GetComponent<AudioSource>().Play();

            // write memo about sheep
            int sheep_id = other.gameObject.GetComponent<SheepBehaviour>().sheep_id;
            GameplayManager.Instance.nightly_memorials.Add(SheepManager.Instance.bios_wolf[sheep_id]);
            
            other.gameObject.GetComponent<SheepBehaviour>().DieBitch();
			AnimalController.EyesOn();
		}
		_onCooldown = true;
	}
}
