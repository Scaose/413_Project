using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class btnControl : MonoBehaviour, IPointerClickHandler {
	public SceneControl sc;

	void Start () {
		sc = GameObject.Find("Scene").GetComponent<SceneControl>();
	}

	void Update () {
	
	}
	public void OnPointerClick(PointerEventData data){
		sc.UpdateCombo();
	}
}
