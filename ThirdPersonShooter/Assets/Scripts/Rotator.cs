using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float speed = 2.5f; 
	private Vector3 dest = new Vector3(0,0,0);
	private int dirCntr = 1;
	private float[] angles = new float[4] {0f, 90f, 180f, 270f};

	void Update() {
		if (Input.GetButtonUp ("RBumper")) {	
			dirCntr += 1;
			if (dirCntr > 3) dirCntr = 0;
		} else if (Input.GetButtonUp ("LBumper")) {
			dirCntr -= 1;
			if (dirCntr < 0) dirCntr = 3;
		}

		dest = new Vector3 (0, angles[dirCntr], 0);

		Quaternion newRot = Quaternion.Euler (dest); // get the equivalent quaternion
		transform.rotation = Quaternion.Slerp (transform.rotation, newRot, speed * Time.deltaTime);

		print ("transform.rotation.eulerAngles.y: " + Mathf.Round(Mathf.Abs(transform.rotation.eulerAngles.y)) + " dest.y: " + Mathf.Abs(dest.y));
	}
}
