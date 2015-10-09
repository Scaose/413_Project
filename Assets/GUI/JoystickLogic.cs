using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickLogic : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler{
	
	public float maxDis, adjustedMaxDis;
	public playerControl player;

	private Vector2 _orgPos, _currPos;
	private bool _isTouch = false;
	private Vector2 _canvasScale, _screenScale;

	void Start(){
		if(GameObject.FindGameObjectWithTag("Player")){
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>();
		}
		if(transform.parent){
			if(transform.parent.GetComponent<CanvasScaler>()){
				_canvasScale = ((CanvasScaler)transform.parent.GetComponent<CanvasScaler>()).referenceResolution;
			}
		}
		_screenScale = new Vector2(Screen.width, Screen.height);
		_orgPos = new Vector2(transform.position.x, transform.position.y);
		_currPos = _orgPos;
		adjustedMaxDis = AdjustMaxDistance();
	}

	void Update(){
		transform.position = new Vector3(_currPos.x, _currPos.y, 0);
		if(_isTouch && Vector2.Distance(_orgPos, _currPos)>maxDis/8.0f){
			//float r = Mathf.Atan2(_currPos.y-_orgPos.y, _currPos.x-_orgPos.x);
			//float joystickPolar = (-(r*180.0f/Mathf.PI))+90.0f;
			//Debug.Log (joystickPolar);
			player.Move(new Vector3(_currPos.x-_orgPos.x, 0, _currPos.y -_orgPos.y).normalized);
			/*if(joystickPolar>=-45.0f && joystickPolar < 45.0f){ //front
				player.MoveForwardWithRotation(Quaternion.Euler(0, 0f, 0));
			}
			else if(joystickPolar>=45.0f && joystickPolar < 135.0f){  //right
				player.MoveForwardWithRotation(Quaternion.Euler(0, 90.0f, 0));
			}
			else if(joystickPolar>=135.0f && joystickPolar <225.0f){  //back
				player.MoveForwardWithRotation(Quaternion.Euler(0, 180.0f, 0));
			}
			else{ //left
				player.MoveForwardWithRotation(Quaternion.Euler(0, -90.0f, 0));
			}*/
		}
	}

	void OnJoyStickTouch(){
		if(!_isTouch){
			_isTouch = true;
		}
	}

	void OnJoyStickDrag(Vector2 inPos){
		Vector2 newPos = new Vector2(inPos.x, inPos.y);
		if((Vector2.Distance(_orgPos, newPos) <= adjustedMaxDis) && _isTouch){

		}
		else{
			Debug.Log ("Bounded");
			if(_isTouch){
				float r = adjustedMaxDis / Vector2.Distance(_orgPos, inPos);
				newPos.x = r * inPos.x + (1-r) * _orgPos.x;
				newPos.y = r * inPos.y + (1-r) * _orgPos.y;
			}
		}
		_currPos = newPos;
	}

	void OnJoyStickEnded(){
		_isTouch = false;
		_currPos = _orgPos;
	}

	private float AdjustMaxDistance(){
		return maxDis / (float)(_canvasScale.x/_canvasScale.y) * (float)(_screenScale.x/_screenScale.y);
	}

	public void OnPointerDown(PointerEventData e){
		OnJoyStickTouch();
	}

	public void OnDrag(PointerEventData e){
		OnJoyStickDrag(e.position);
	}

	public void OnPointerUp(PointerEventData e){
		OnJoyStickEnded();
	}
	
}
