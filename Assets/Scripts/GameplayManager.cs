using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : Singleton<GameplayManager>
{
	public int SheepCount = 0;
	public int LooseCondition;
	public bool Day = true;
	public float DayDuration;
	public float ShiftDuration;
	
	public Light GlobalLight;

	public List<Light> DogLights;
	public GameObject Dog1;
	public GameObject Dog2;
	public GameObject Wolf1;
	public GameObject Wolf2;
	
	private float _currentShiftTime;
	private float _currentDayTime;

	private bool _nightShift;
	private bool _dayShift;

	public Text SheepsCountText;

	public Image PopUp;
	public Sprite WinSprite;
	public Sprite LooseSprite;

	private void Start()
	{
		_currentShiftTime = ShiftDuration;
		_currentDayTime = DayDuration;
	}

	public void Update()
	{
		SheepsCountText.text = "" + SheepCount;
		
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

		if (_currentDayTime > 0)
		{
			_currentDayTime -= Time.deltaTime;
		}
		else
		{
			_currentDayTime = DayDuration;
			if (Day)
			{
				SwitchToNight();
			}
			else
			{
				SwitchToDay();
			}
		}
		
		//Day night cycle
		

		if (Input.GetKeyDown(KeyCode.A))
		{
			SwitchToNight();
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			SwitchToDay();
		}

		if (SheepCount < LooseCondition)
		{
			GameOver();
		}

		if (Wolf1.activeSelf == false /*&& Wolf2.activeSelf == false*/)
		{
			GameWon();
		}
	}
	
	public void AddSheep()
	{
		SheepCount++;
	}

	public void SwitchToNight()
	{
		_nightShift = true;
		Day = false;
	}
	
	public void SwitchToDay()
	{
		_dayShift = true;
		Day = true;
	}

	public void GameOver()
	{
		Debug.Log("game over");
		//Pause();
	}

	public void GameWon()
	{
		Debug.Log("game won");
		ShowPopup(WinSprite);
		Pause();
	}

	public void Pause()
	{
		Time.timeScale = 0;
	}
	
	public void UnPause()
	{
		Time.timeScale = 1;
	}

	public void ShowPopup(Sprite sprite)
	{
		PopUp.sprite = sprite;
		PopUp.gameObject.SetActive(true);
	}
}
