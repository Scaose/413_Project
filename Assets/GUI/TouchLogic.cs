using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TouchLogic : MonoBehaviour {
	
	void Update () {
		Debug.Log(Input.touchCount);
		if(Input.touchCount > 0){
			//Touch[] touches = Input.touches;
			for (int i=0; i<Input.touchCount; i++){
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit)){
					Debug.Log (hit.transform.name);
				}
			}
		}
	}

	bool IsPointerOverUI(int fingerID){
		return EventSystem.current.IsPointerOverGameObject(fingerID);
	}
}
