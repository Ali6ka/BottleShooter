using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class SetColliders : MonoBehaviour {

	public bool _SetColliders;


// Update is called once per frame
	void Update () {
		if (_SetColliders == true) {
			foreach(Transform child in transform){
				child.gameObject.AddComponent<BoxCollider>();

			}

				}
	
	}
}
