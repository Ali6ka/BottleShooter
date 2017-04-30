using UnityEngine;
using System.Collections;

public class TransformObject : MonoBehaviour {
	public float moveSpeed = 10f;
	public float turnSpeed = 50f;
	public GameObject Camera;


	void Start () {

	}
	

	void Update () {
		if (Input.GetKey(KeyCode.W))
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
		if (Input.GetKey (KeyCode.S))
			transform.Translate (Vector3.back * moveSpeed * Time.deltaTime);
		if (Input.GetKey (KeyCode.D))
			transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);
		if (Input.GetKey (KeyCode.A))
			transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);
		if (Input.GetKeyDown (KeyCode.Space)) {
						transform.Translate (Vector3.up * 3 * Time.deltaTime);
				}
		
		if (Input.GetAxis ("Mouse X") > 0)
						transform.Rotate (Vector3.up, -turnSpeed * Time.deltaTime);
		if (Input.GetAxis ("Mouse X") < 0)
						transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
		if (Input.GetAxis ("Mouse Y") > 0)
						Camera.transform.Rotate (Vector3.left, turnSpeed * Time.deltaTime);

		if (Input.GetAxis ("Mouse Y") < 0)
			Camera.transform.Rotate (Vector3.left, -turnSpeed * Time.deltaTime);



		

	
}
}