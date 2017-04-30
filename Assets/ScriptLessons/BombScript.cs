using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {

	public AudioClip wick;

	private Renderer rend;

	void Start () {
		rend = gameObject.GetComponentInChildren<Renderer> ();
		wait();
		playAudioWick ();
	}

	void Update () {}

	private void playAudioWick(){
		GetComponent<AudioSource>().PlayOneShot(wick,2f);
	}

	private void changeMaterial(){
		if (rend.material.GetColor ("_Color") == Color.black) {
			rend.material.SetColor ("_Color", Color.red);
		} else {rend.material.SetColor ("_Color",Color.black);
		}
		wait ();

	}
	private void wait(){
		Invoke ("changeMaterial", 0.1f);
	}
}
