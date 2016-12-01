using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
	public Vector3 RotateV;
	public int minOffset;
	public int maxOffset;
	public int recycleOffset;
	public int yRange;
	// Use this for initialization
	void Start () {
		GameManager.Instance.GameStart += GameStart;
		this.renderer.enabled = false;
		
	}
	
	void GameStart()
	{
		this.renderer.enabled = true;
		Spawn();
	}
	
	void Spawn()
	{
		this.transform.localPosition = new Vector3(
			Jumper.Position.x + Random.Range(minOffset,maxOffset),
			Random.Range(-yRange,yRange),
			0);			
	}
	

	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(RotateV);
		if(transform.localPosition.x + recycleOffset < Jumper.Position.x)
		{
			Spawn();
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Player")
		{
			Jumper.numberPowerup++;
		}
		Spawn();
	}
}
