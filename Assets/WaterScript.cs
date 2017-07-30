using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour {
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Owca"))
		{
			other.gameObject.GetComponent<SheepBehaviour>().DieBitch();
		}
	}
}
