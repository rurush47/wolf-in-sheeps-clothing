using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AColliderDog : MonoBehaviour
{

    // DOG

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
        // BITE SHEEP
		if (other.gameObject.CompareTag("Owca") && Input.GetButton(AnimalController.AttackButton) && !_onCooldown)
		{
			other.enabled = false;
			crunch.clip = crunchSound; 
			crunch.Play();
            //kill ship here
            //			Destroy(other.gameObject);

            // write memo about sheep
            int sheep_id = other.gameObject.GetComponent<SheepBehaviour>().sheep_id;
            GameplayManager.Instance.nightly_memorials.Add(SheepManager.Instance.bios_dog[sheep_id]);

            other.gameObject.GetComponent<SheepBehaviour>().DieBitch();
		}
		
        // BITE WOLF
		if (other.gameObject.CompareTag("Wilk") && Input.GetButton(AnimalController.AttackButton)  && !_onCooldown)
		{
			other.enabled = false;
			crunch.Play();
            Debug.Log("wilk-owca hapnięta");
            //make obj inactive!
            other.gameObject.SetActive(false);
		}
		
        // BARK
		if (other.gameObject.CompareTag("Owca") && Input.GetButton(AnimalController.WofButton)  && !_onCooldown)
		{
			crunch.clip = wofSound;
			crunch.Play();
			other.GetComponent<SheepBehaviour>().getBarkedAt();
		}

		_onCooldown = true;
	}
}
