using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AColliderDog : MonoBehaviour
{
	public AnimalController AnimalController;
	public float AttackCooldown;
	private float _currentCooldownTimer;
	private bool _onCooldown;
	private AudioSource crunch;

	private void Start()
	{
		crunch = GetComponent<AudioSource>();
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
		if (other.gameObject.CompareTag("Owca") && Input.GetButton(AnimalController.AttackButton) && !_onCooldown)
		{
			crunch.Play();
			//kill ship here
			GameplayManager.Instance.SheepCount--;
			other.gameObject.GetComponent<ParticleSystem>().Play();
			other.gameObject.GetComponent<SheepBehaviour>().DieBitch();

//			Destroy(other.gameObject);

			gameObject.GetComponentInParent<CharacterController>().Move(Vector3.forward);
		}
		
		if (other.gameObject.CompareTag("Wilk") && Input.GetButton(AnimalController.AttackButton)  && !_onCooldown)
		{
			crunch.Play();
			Debug.Log("owca hapnięta");
			//make obj inactive!
			other.gameObject.SetActive(false);
		}		
		
		if (other.gameObject.CompareTag("Owca") && Input.GetButton(AnimalController.WofButton)  && !_onCooldown)
		{
			crunch.Play();
			other.gameObject.GetComponent<SheepBehaviour>().getBarkedAt();
		}
	}
}
