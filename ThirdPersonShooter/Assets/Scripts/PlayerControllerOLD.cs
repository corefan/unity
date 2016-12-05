using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;            // The speed that the player will move at.

	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
	//Animator anim;

	void Awake() {
		playerRigidbody = GetComponent <Rigidbody> ();
		//anim = GetComponent <Animator> ();
	}

	void Update() {
		Vector3 lookDirection = Camera.main.transform.right * Input.GetAxis("Horizontal2") + Camera.main.transform.forward*Input.GetAxis("Vertical2");
		lookDirection.y = 0.0f;
		if (lookDirection.sqrMagnitude > 0.0f) {
			transform.rotation = Quaternion.LookRotation(lookDirection,Vector3.up);
		}
	}

	void FixedUpdate() {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		Move (h, v);
	}

	void Move (float h, float v)
	{
		if (h != 0.0f || v != 0.0f) {
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z); 

			Vector3 targetDirection = new Vector3(h, 0f, v);
			targetDirection = Camera.main.transform.TransformDirection(targetDirection);
			targetDirection.y = 0.0f;

			movement.Set (targetDirection.x, targetDirection.y, targetDirection.z);

			movement = movement.normalized * speed * Time.deltaTime;

			transform.rotation = Quaternion.LookRotation ((transform.right * h) + (transform.forward * v), Vector3.up);
			playerRigidbody.position = transform.position + movement;
		}
	}
}
