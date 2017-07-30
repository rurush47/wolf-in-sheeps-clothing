using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSound : MonoBehaviour
{
	public AudioSource AudioSource;
	private float _currentTime;
	public float SoundInterval;
	// Use this for initialization
	void Start ()
	{
		AudioSource = GetComponent<AudioSource>();
		_currentTime = SoundInterval;
	}
	
	// Update is called once per frame
	void Update () {
		if (_currentTime > 0)
		{
			_currentTime -= Time.deltaTime;
		}
		else
		{
			AudioSource.Play();
			_currentTime = SoundInterval;
		}
	}
}
