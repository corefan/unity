using UnityEngine;
using System.Collections;

public class HuntTarget : MonoBehaviour {

	Transform target;
	NavMeshAgent nav;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		nav.SetDestination (target.position);
	}
}
