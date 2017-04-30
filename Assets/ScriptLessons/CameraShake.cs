using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	public Transform camTransform;
	private float shakeDuration; //длительность

	//амлитуда, чем больше тем сильнее эффект дрожания
	private float shakeAmount;
	private float decreaseFactor;
	
	Vector3 originalPos;

	void Start(){
		shakeDuration = 3f;
		shakeAmount = 0.2f;
		decreaseFactor = 1.0f;
	}

	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	
	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}
	
	void Update()
	{
		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}
	}
}