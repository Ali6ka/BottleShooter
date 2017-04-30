using UnityEngine;
using System.Collections;

public class ExplosionDie : MonoBehaviour {
	public float Radius;
	public float Force;
	public Transform Bot;
	private ParticleRenderer exp;

	// Use this for initialization
	void Start () {
		exp = Bot.GetComponentInChildren<ParticleRenderer>();

		if (Bot.tag!="Finish"){
			foreach (Transform child in Bot) {
				child.gameObject.AddComponent<Rigidbody> ();
				if (Bot.name == "GreenBottleDie") {
					child.gameObject.GetComponent<Rigidbody> ().drag = 3f;
				}
				child.gameObject.GetComponent<Rigidbody>().mass = 0.01f;
				child.gameObject.GetComponent<Rigidbody>().AddExplosionForce (Force, transform.position, Radius, 3);
			}
			Destroy (gameObject, 2);
		} else {
			setVelScale();
			Destroy(gameObject, 3.5f);
		}
	}

	private void wait(){
		Invoke ("setVelScale", 0.001f);
	}

	private void setVelScale(){
		exp.velocityScale +=0.1f;
		wait();
	}

}
