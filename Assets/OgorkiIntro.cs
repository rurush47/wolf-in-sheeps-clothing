using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OgorkiIntro : MonoBehaviour
{
	private AudioSource introSound;
	public float runTime = 5.0f;
	public float currentTime;
	
	// Use this for initialization
	void Start ()
	{
		introSound = GetComponent<AudioSource>();
		introSound.PlayOneShot(introSound.clip);
		currentTime = runTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTime < 0)
		{
			SceneManager.LoadScene("MainMenu");
		}
		else
		{
			currentTime -= Time.deltaTime;
		}
	}

	private IEnumerator IntroTimer()
	{
		float timeElapsed = 0.0f;
		while (timeElapsed < runTime)
		{
			timeElapsed += Time.deltaTime;
			yield return null;
		}
		Debug.Log("Koniec");
	}
}
