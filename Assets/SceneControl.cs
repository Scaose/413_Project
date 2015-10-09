using UnityEngine;
using System.Collections;

public class SceneControl : MonoBehaviour {
	public float comboMaxTime;
	private float _comboStartTime;
	private SceneUIControl _ui;
	private int _currMax;

	void Start () {
		_ui = new SceneUIControl();
		ResetComboAndTime();
	}

	void Update () {
		if(Time.time - _comboStartTime > comboMaxTime){
			_ui.AddCurrToMaxCount(_currMax);
			ResetComboAndTime();
		}
	}

	protected void ResetComboAndTime(){
		_currMax = 0;
		_comboStartTime = Time.time;
	}

	protected void ResetComboTime(){
		_comboStartTime = Time.time;
	}

	public void UpdateCombo(){
		_currMax++;
		_ui.AddCurrentCount();
		ResetComboTime();
	}
	public void UpdateCombo(int num){
		_ui.AddCurrentCount(num);
		ResetComboTime();
	}
}
