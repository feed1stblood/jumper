using UnityEngine;
using System.Collections;
using System.Linq;
public class GUITextManager : MonoBehaviour {
	public GUIText GameOverText, ScoreText, NumPowerupText;
	public GUIText[] InstructionText;
	// Use this for initialization
	void Start () {
		GameManager.Instance.GameStart += GameStart;
		GameManager.Instance.GameOver += GameOver;
		GameOverText.enabled = false;
	}
	
	void GameStart()
	{
		foreach(var obj in InstructionText)
			obj.enabled = false;
		GameOverText.enabled = false;
	}
	
	void GameOver()
	{		
		foreach(var obj in InstructionText)
			obj.enabled = true;
		GameOverText.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		ScoreText.text = "Score:"+Jumper.distance.ToString("f0");
		NumPowerupText.text = "Capsule:"+Jumper.numberPowerup.ToString();
	}
}
