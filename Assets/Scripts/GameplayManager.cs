using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
	public int SheepCount = 0;
	public int LooseCondition;
	public bool Day = true;
	public float DayDuration;
	public float ShiftDuration;
	public float LightIntensity;
	public float DirectionalLightIntensity = 0.12f;
	
	public Light GlobalLight;
	public Light DirectionalLight;

	public List<Light> DogLights;
	public GameObject Dog1;
	public GameObject Dog2;
	public GameObject Wolf1;
	public GameObject Wolf2;
	
	private float _currentShiftTime;
	private float _currentDayTime;

	private bool _nightShift;
	private bool _dayShift;

    public List<GameObject> Sheeps;
    public List<GameObject> Players;
    public Text SheepsCountText;

	public Image PopUp;
	public Sprite WinSprite;
	public Sprite LooseSprite;

	[Range(0.0f, 10.0f)] 
	public float ambientLightIntensity = 2.0f;

	private bool _gameOver;

    public List<string> nightly_memorials;

    public static GameplayManager Instance = null;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        nightly_memorials.Clear();
    }

	private void Start()
	{
		RenderSettings.ambientIntensity = ambientLightIntensity;
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
				GlobalLight.intensity = Mathf.Lerp(0, LightIntensity, _currentShiftTime / ShiftDuration);
				//DirectionalLight.intensity = Mathf.Lerp(0, DirectionalLightIntensity, _currentShiftTime / ShiftDuration);
				RenderSettings.ambientIntensity = Mathf.Lerp(0, ambientLightIntensity, _currentShiftTime / ShiftDuration);
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
				GlobalLight.intensity = Mathf.Lerp(LightIntensity, 0, _currentShiftTime / ShiftDuration);
				//DirectionalLight.intensity = Mathf.Lerp(DirectionalLightIntensity, 0, _currentShiftTime / ShiftDuration);
				RenderSettings.ambientIntensity = Mathf.Lerp(ambientLightIntensity, 0, _currentShiftTime / ShiftDuration);
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

		if (_gameOver && Input.GetKeyDown(KeyCode.S))
		{
			SceneManager.LoadSceneAsync("MainMenu");
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

        // END of the NIGHT
        StartCoroutine(DisplayMemorials());

    }

    public void GameOver()
	{
		Debug.Log("game over");
		ShowPopup(LooseSprite);
		Pause();
		_gameOver = true;
	}

	public void GameWon()
	{
		Debug.Log("game won");
		ShowPopup(WinSprite);
		Pause();
		_gameOver = true;
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

	public void DecreaseSheepCount()
	{
		SheepCount--;
	}

    private IEnumerator DisplayMemorials()
    {
        foreach (string memorial in nightly_memorials)
        {
            MemorialCanvasController.Instance.current_memorial_text = memorial;
            MemorialCanvasController.Instance.ToggleMenu();
            yield return new WaitForSeconds(0.2f);
        }
	    
	    nightly_memorials.Clear();
    }
    

}
