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
	public AudioClip wofSound;
	public AudioClip crunchSound;

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
			other.enabled = false;
			crunch.clip = crunchSound; 
			crunch.Play();
			//kill ship here
//			Destroy(other.gameObject);
			other.gameObject.GetComponent<SheepBehaviour>().DieBitch();
		}
		
		if (other.gameObject.CompareTag("Wilk") && Input.GetButton(AnimalController.AttackButton)  && !_onCooldown)
		{
			other.enabled = false;
			crunch.Play();
			Debug.Log("owca hapnięta");
			//make obj inactive!
			other.gameObject.SetActive(false);
		}

		_onCooldown = true;
	}
}
