using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBehaviour : MonoBehaviour
{

	private Vector3 sheepDirection;
	private CharacterController sheepCotroller;
	private Animator sheepAnimator;
	public float Gravity;

	public Vector3 islandCenter;
	public float baseSheepSpeed;
	public float sheepSpeed = 1.0f;
	
	
	public float minDirChangeTime = 0.5f;
	public float maxDirChangeTime = 2.5f;
	
	public float minRotChangeTime = 0.5f;
	public float maxRotChangeTime = 2.5f;

	public float minEscTime = 0.5f;
	public float maxEscTime = 2f;

	public float escRotationTIme = 0.3f;
	
	// Use this for initialization
	void Awake()
	{
		sheepAnimator = GetComponent<Animator>();
		sheepCotroller = GetComponent<CharacterController>();
		sheepDirection = Quaternion.Euler(0,Random.Range(0,360),0) * transform.forward;
		sheepDirection = sheepDirection.normalized;
		transform.rotation = transform.rotation * Quaternion.FromToRotation(transform.forward, sheepDirection);
		StartCoroutine(WaitForXSeconds());
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 moveVec = sheepDirection * sheepSpeed;
		moveVec.y -= Gravity * Time.deltaTime;
		sheepCotroller.SimpleMove(moveVec);
	}


	private IEnumerator WaitForXSeconds()
	{
		sheepAnimator.SetBool("move", true);
		yield return new WaitForSeconds(Random.Range(minDirChangeTime, maxDirChangeTime));
		Quaternion randRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
		Vector3 sheepDirectionCache = (randRotation * transform.forward).normalized;
		float rotationTime = Random.Range(minRotChangeTime, maxRotChangeTime);
		sheepAnimator.SetBool("move", false);
		StartCoroutine(LerpRotation(transform.rotation, transform.rotation * randRotation, rotationTime, sheepDirectionCache));
	}

	private IEnumerator LerpRotation(Quaternion currentRotation, Quaternion endRotation, float rotationTime, Vector3 newSheepDirection)
	{
		sheepDirection = Vector3.zero;
		float timePassed = 0.0f;
		while (timePassed < rotationTime)
		{
			transform.rotation = Quaternion.Slerp(currentRotation, endRotation, timePassed/rotationTime);
			timePassed += Time.deltaTime;
			yield return null;
		}
		sheepDirection = newSheepDirection;
		StartCoroutine(WaitForXSeconds());
	}

	private IEnumerator RunTowardCenter()
	{
		sheepSpeed = 1.5f * baseSheepSpeed;
		StartCoroutine(LerpRotation(transform.rotation, Quaternion.LookRotation(islandCenter), escRotationTIme,
			(islandCenter - transform.position).normalized));
		yield return new WaitForSeconds(Random.Range(minEscTime, maxEscTime));
		sheepSpeed = baseSheepSpeed;

	}

	private IEnumerator Die()
	{
		while (transform.localScale.x > 0.05)
		{
			transform.localScale = transform.localScale - new Vector3(0.05f, 0.05f, 0.05f);
			yield return null;
		}
	}
	
	public void getBarkedAt()
	{
		StopAllCoroutines();
		StartCoroutine(RunTowardCenter());
	}

	public void DieBitch()
	{
		GameplayManager.Instance.SheepCount--;
		StopAllCoroutines();
		StartCoroutine(Die());
	}

}

