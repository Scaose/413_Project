using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {

	public float moveSpeed;
	public float rotateSpeed;

	void Start () {
	
	}

	void Update () {

	}

	public void Move(Vector3 direction){
		transform.Translate((transform.forward*direction.z + transform.right*direction.x) *Time.deltaTime*moveSpeed);
	}

	public void MoveForwardWithRotation(Quaternion destRot){
		//Quaternion v = Quaternion.Slerp(transform.rotation, destRot, Time.deltaTime*rotateSpeed);
		//transform.eulerAngles = destRot;
		if(destRot.y>90.0f){
			Debug.Log ("hi");
			//MoveBackward();
		}
		else{
			//MoveForward();
		}
	}
}
