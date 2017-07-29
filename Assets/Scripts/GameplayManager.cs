﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : Singleton<GameplayManager>
{
	public int SheepCount = 0;
	public bool Day = true;
	public float DayDuration;
	public float ShiftDuration;
	
	public Light GlobalLight;
	public Light Dog1Light;
	public Light Dog2Light;

	public List<Light> DogLights;
	public GameObject Dog2;
	public GameObject Wolf1;
	public GameObject Wolf2;
	private float _currentShiftTime;
	private bool _nightShift;
	private bool _dayShift;

	private void Start()
	{
		_currentShiftTime = ShiftDuration;
	}

	public void Update()
	{
		if (_nightShift == true)
		{
			if (_currentShiftTime > 0)
			{
				GlobalLight.intensity = Mathf.Lerp(0, 1, _currentShiftTime / ShiftDuration);
				foreach (var light in DogLights)
				{
					light.intensity = Mathf.Lerp(8, 0, _currentShiftTime / ShiftDuration);
				}

				_currentShiftTime -= Time.deltaTime;
			}
			else
			{
				_nightShift = false;
				_currentShiftTime = ShiftDuration;
			}
		}
		
		if (_dayShift == true)
		{
			if (_currentShiftTime > 0)
			{
				GlobalLight.intensity = Mathf.Lerp(1, 0, _currentShiftTime / ShiftDuration);
				foreach (var light in DogLights)
				{
					light.intensity = Mathf.Lerp(0, 8, _currentShiftTime / ShiftDuration);
				}
				
				_currentShiftTime -= Time.deltaTime;
			}
			else
			{
				_dayShift = false;
				_currentShiftTime = ShiftDuration;
			}
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			SwitchToNight();
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			SwitchToDay();
		}
	}
	
	public void AddSheep()
	{
		SheepCount++;
	}

	public void SwitchToNight()
	{
		_nightShift = true;
	}
	
	public void SwitchToDay()
	{
		_dayShift = true;
	}
}
