using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepManager : MonoBehaviour
{
	[Range(1, 200)] 
	public int sheepCount = 20;
	public GameObject sheepPrefab;
	public GameObject plane;
	
	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < sheepCount; i++)
		{
			Instantiate(sheepPrefab,
				new Vector3(Random.Range(-50.0f, 50.0f), 0, Random.Range(-50.0f, 50.0f)),
				Quaternion.Euler(0.0f, Random.Range(0, 360), 0.0f));
		}

		GameplayManager.Instance.SheepCount += sheepCount;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
