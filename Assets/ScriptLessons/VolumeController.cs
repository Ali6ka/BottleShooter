using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class VolumeController : MonoBehaviour {
	public Slider volumeSlider;

	public void Awake(){
		if (volumeSlider) {
			GetComponent<AudioSource> ().volume = PlayerPrefs.GetFloat ("CurVol");
			volumeSlider.value = GetComponent<AudioSource> ().volume;
		}
	}

	public void VolumeControl(float volumeControl)
	{
		GetComponent<AudioSource> ().volume = volumeControl;
		
		PlayerPrefs.SetFloat ("CurVol", GetComponent<AudioSource> ().volume);
		PlayerPrefs.Save ();
	}
	private void Update()
	{
		VolumeControl(volumeSlider.value);
	}
	void OnApplicationQuit() {
		PlayerPrefs.SetFloat ("CurVol", GetComponent<AudioSource> ().volume);
		PlayerPrefs.Save ();
	}
}
