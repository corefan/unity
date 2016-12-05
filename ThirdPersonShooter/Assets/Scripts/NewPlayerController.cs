using UnityEngine;
using System.Collections;

public class NewPlayerController : MonoBehaviour {

	public float speed;            // The speed that the player will move at.

	Vector3 movement;                   // The vector to store the direction of the player's movement.
	public GameObject player;          // Reference to the player's rigidbody.
	Rigidbody playerRigidbody;
	Animator anim;

	void Awake() {
		playerRigidbody = GetComponent <Rigidbody> ();
		anim = GetComponentInChildren <Animator> ();
	}

	void Update() {
		Vector3 lookDirection = Camera.main.transform.right * Input.GetAxis("Horizontal2") + Camera.main.transform.forward*Input.GetAxis("Vertical2");
		lookDirection.y = 0.0f;
		if (lookDirection.sqrMagnitude > 0.0f) {
			player.transform.rotation = Quaternion.LookRotation(lookDirection,Vector3.up);
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
			//player.transform.localEulerAngles = new Vector3(player.transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, player.transform.localEulerAngles.z); 

			Vector3 targetDirection = new Vector3(h, 0f, v);
			targetDirection = Camera.main.transform.TransformDirection(targetDirection);
			targetDirection.y = 0.0f;

			movement.Set (targetDirection.x, targetDirection.y, targetDirection.z);

			movement = movement.normalized * speed * Time.deltaTime;

			//player.transform.rotation = Quaternion.LookRotation ((player.transform.right * h) + (player.transform.forward * v), Vector3.up);
			Vector3 lookDirection = Camera.main.transform.right * h + Camera.main.transform.forward * v;
			lookDirection.y = 0.0f;
			if (lookDirection.sqrMagnitude > 0.0f) {
				player.transform.rotation = Quaternion.LookRotation(lookDirection,Vector3.up);
			}

			playerRigidbody.position = transform.position + movement;
			//anim.SetFloat ("Speed_f", 1f);

		}
	}
}
