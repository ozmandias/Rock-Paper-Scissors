using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

	[SerializeField] Text playerChoiceText;
	int currentChoice = -1;
	int currentScore = 0;

	// Use this for initialization
	void Start () {
		clearPlayerChoiceText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateCurrentChoice(int choiceNumber) {
		currentChoice = choiceNumber;
		Debug.Log("playerChoice: " + currentChoice);
	}

	public int getPlayerChoice() {
		return currentChoice;
	}

	public void resetPlayerChoice() {
		currentChoice = -1;
	}

	public int getPlayerScore() {
		return currentScore;
	}

	public void addPlayerScore() {
		currentScore = currentScore + 1;
	}

	public void setPlayerChoiceText(string player_choice_text) {
		playerChoiceText.text = player_choice_text;
	}

	public void clearPlayerChoiceText() {
		playerChoiceText.text = "";
	}
}
