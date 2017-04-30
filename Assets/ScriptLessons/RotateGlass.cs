using UnityEngine;
using System.Collections;

public class RotateGlass : MonoBehaviour {
	private int rot;
	// Use this for initialization
	void Start () {
		rot = Random.Range (1, 5);
	}
	
	// Update is called once per frame
	void Update () {
		if(rot==1){transform.Rotate (new Vector3 (Time.deltaTime, -(Time.deltaTime * 50), Time.deltaTime*20));}
		else if(rot==2){transform.Rotate (new Vector3 (Time.deltaTime*80, Time.deltaTime, Time.deltaTime*30));}
		else if(rot==3){transform.Rotate (new Vector3 (-(Time.deltaTime*50), Time.deltaTime*40, Time.deltaTime));}
		else if(rot==4){transform.Rotate (new Vector3 (Time.deltaTime*30, Time.deltaTime*30, -(Time.deltaTime*60)));}
	}
}
