using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class main_menu_volume : MonoBehaviour {

	public void Start(){
		gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat ("CurVol");
	}

	// Update is called once per frame
	/*void Update () {
		VolumeControl(gameObject.GetComponent<Slider>().value);
	}
	void Update(){
		gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat ("CurVol");
	}*/
	public void VolumeControl()
	{
		//PlayerPrefs.GetFloat ("CurVol",volumeControl);
		PlayerPrefs.SetFloat ("CurVol",gameObject.GetComponent<Slider>().value);
		//Debug.Log ();
	}
}
