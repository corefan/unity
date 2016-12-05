using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject target;
	private Vector3 offset;

	void Start () {
		offset = Camera.main.transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Camera.main.transform.position = target.transform.position + offset;
	}
}
