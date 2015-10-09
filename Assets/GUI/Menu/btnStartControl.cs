using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class btnStartControl : MonoBehaviour, IPointerClickHandler {

	public void OnPointerClick(PointerEventData data){
		Application.LoadLevel("BattleScene");
	}
}
