using UnityEngine;
using System.Collections;

public class ParticleSystemManager : MonoBehaviour {
	public ParticleSystem[] systems;
	// Use this for initialization
	void Start () {
		GameManager.Instance.GameStart += GameStart;
		GameManager.Instance.GameOver += GameOver;
		GameOver();
	}
	
	void GameStart()
	{
		foreach(var system in systems)
			system.enableEmission = true;
	}
	
	void GameOver()
	{
		foreach(var system in systems)
			system.enableEmission = false;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
