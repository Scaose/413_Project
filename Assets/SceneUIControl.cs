using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneUIControl{
	private static Text _txtCurrCom;
	private static Text _txtMaxCom;

	public SceneUIControl(){
		_txtCurrCom = GameObject.Find("txtCurrCount").GetComponent<Text>();
		_txtMaxCom = GameObject.Find("txtMaxCount").GetComponent<Text>();
	}

	public void AddCurrentCount(){
		int temp;
		if(int.TryParse(_txtCurrCom.text, out temp)){
			temp++;
			_txtCurrCom.text = temp.ToString();

		}
		else{
			throw new UnityException("Current's text parsing error");
		}
	}

	public void AddCurrentCount(int num){
		_txtCurrCom.text = num.ToString();
	}

	public void ResetCurrentCount(){
		_txtCurrCom.text = "0";
	}

	public void AddCurrToMaxCount(int currMax){
		int temp;
		if(int.TryParse(_txtMaxCom.text, out temp)){
			if(currMax > temp){
				_txtMaxCom.text = currMax.ToString();
			}
			ResetCurrentCount();
		}
	}
}
