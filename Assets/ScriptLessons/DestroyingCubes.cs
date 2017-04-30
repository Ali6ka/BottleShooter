using UnityEngine;
using System.Collections;

public class DestroyingCubes : MonoBehaviour {
	public Transform Bot;

	void Start(){
		foreach (Transform child in Bot) {
			Destroy(child.gameObject,0.4f);
		}
	}
}



	

