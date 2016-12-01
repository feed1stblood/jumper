using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public delegate void GameEventHandler();
	public event GameEventHandler GameStart, GameOver;
	
	bool gameStarted = false;
	static GameManager instance;
	public static GameManager Instance{get{return instance;}}
	// Use this for initialization
	void Start () {
		
	}
	
	void Awake () {
		instance = this;
	}
	// Update is called once per frame
	void Update () {
		
		if(!gameStarted&&Input.GetButtonDown("Jump"))
		{
			
			OnGameStart();
			
		}
	}
	
	public void OnGameStart()
	{
		gameStarted = true;
		if(GameStart!=null)
		{
			
			GameStart();
		}
	}
	
	public void OnGameOver()
	{
		gameStarted = false;
		if(GameOver!=null)
		{
			GameOver();
		}
	}
}
