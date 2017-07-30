using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public class GameplayManager : Singleton<GameplayManager>
public class GameplayManager : MonoBehaviour
{
	public int SheepCount = 0;
	public int LooseCondition;
	public bool Day = true;
	public float DayDuration;
	public float ShiftDuration;
	public float LightIntensity;
	
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

    public List<GameObject> Sheeps;
    public List<GameObject> Players;
	public Text SheepsCountText;

	public Image PopUp;
	public Sprite WinSprite;
	public Sprite LooseSprite;

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
		_currentShiftTime = ShiftDuration;
		_currentDayTime = DayDuration;

        // register players in list
        //foreach (PlayerStruct player_data in GameController.Instance.player_data_list)
        //{
        //    Players.Add();
        //}
        Players.Add(Dog1);
        Players.Add(Wolf1);
        //Players.Add(Wolf2);

        //// DISABLED camera scaling
        //// register characters to camera
        //foreach (GameObject character in Players)
        //{
        //    CameraController.Instance.AddTarget(character.transform);
        //}
        //foreach (GameObject character in Sheeps)
        //{
        //    CameraController.Instance.AddTarget(character.transform);
        //}

    }

    public void Update()
	{
		SheepsCountText.text = "" + SheepCount;
		
		if (_nightShift == true)
		{
			if (_currentShiftTime > 0)
			{
				GlobalLight.intensity = Mathf.Lerp(0, LightIntensity, _currentShiftTime / ShiftDuration);
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
		
		// END of the NIGHT
		StartCoroutine(DisplayMemorials());

	}

	public void GameOver()
	{
		Debug.Log("game over");
		ShowPopup(LooseSprite);
		Pause();
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
