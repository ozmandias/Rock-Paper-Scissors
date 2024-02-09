using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class opponent : MonoBehaviour {

	[SerializeField] Text opponentChoiceText;
	int opponentCurrentChoice = -1;
	int opponentScore = 0;

	// Use this for initialization
	void Start () {
		clearOpponentChoiceText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void opponentPlayGame() {
		Debug.Log("opponentPlayGame");
		opponentCurrentChoice = Random.Range(0,3);
		Debug.Log("opponentChoice: " + opponentCurrentChoice);
	}

	public int getOpponentChoice() {
		return opponentCurrentChoice;
	}

	public void resetOpponentChoice() {
		opponentCurrentChoice = -1;
	}

	public int getOpponentScore() {
		return opponentScore;
	}

	public void addOpponentScore() {
		opponentScore = opponentScore + 1;
	}

	public void setOpponentChoiceText(string opponent_choice_text) {
		opponentChoiceText.text = opponent_choice_text;
	}

	public void clearOpponentChoiceText() {
		opponentChoiceText.text = "";
	}
}
