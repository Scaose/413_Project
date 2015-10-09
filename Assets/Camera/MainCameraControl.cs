using UnityEngine;
using System.Collections;

public class MainCameraControl : MonoBehaviour {

	public Transform target;
	public float distanceAway;
	public float distanceY;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tarPos = target.transform.position + target.up * distanceY - target.forward * distanceAway;
		transform.position = tarPos;
		transform.LookAt(target);
	}
}
