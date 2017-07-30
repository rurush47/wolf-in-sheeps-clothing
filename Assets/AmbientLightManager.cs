using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientLightManager : MonoBehaviour
{

	[Range(0.0f, 10.0f)]
	public float intensity = 0.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		RenderSettings.ambientIntensity = intensity;
	}
}
