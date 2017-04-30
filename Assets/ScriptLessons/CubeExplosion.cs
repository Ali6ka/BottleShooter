using UnityEngine;
using System.Collections;

public class CubeExplosion : MonoBehaviour {
	private float radius;
	private float force;

	// Use this for initialization
	void Start () {
		radius = Random.Range (0, 4);
		force = Random.Range (30, 50);
		if (tag!="Finish"){
			foreach (Transform child in transform) {
				child.gameObject.AddComponent<Rigidbody> ();
				if (name == "GreenBottleDie") {
					child.gameObject.GetComponent<Rigidbody> ().drag = 3f;
				} 
				child.gameObject.GetComponent<Rigidbody>().mass = 0.01f;
				child.gameObject.GetComponent<Rigidbody>().AddExplosionForce (force, transform.position, radius, 3);
			}
			Destroy (gameObject, 2);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
