using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	bool shooting, gameover;
	public int speed;
	public Transform Detonator;
	public int RecycleOffset;
	// Use this for initialization
	void Start () {
		GameOver();
		GameManager.Instance.GameStart += GameStart;
		GameManager.Instance.GameOver += GameOver;
	}
	
	void GameStart()
	{
		shooting = false;
		gameover = false;
	}
	
	void GameOver()
	{
		this.renderer.enabled = false;
		this.collider.enabled = false;
		gameover = true;
	}
	// Update is called once per frame
	void Update () {
		
		if(!gameover && Input.GetButtonDown("Fire1") && Jumper.numberPowerup>0 && !shooting)
		{
			
			shooting = true;
			Jumper.numberPowerup--;
			this.transform.localPosition = Jumper.Position;
			//this.transform.Translate(speed,0,0);
			this.renderer.enabled = true;
			this.collider.enabled = true;
		}
		else if(shooting)
		{
			if(this.transform.localPosition.x < RecycleOffset + Jumper.Position.x)
				this.transform.Translate(speed,0,0);
			else
				Recycle();
		}
	}
	
	void Recycle()
	{
		shooting = false;
		this.renderer.enabled = false;
		this.collider.enabled = false;
	}
	
	void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.tag);
		
		if(other.tag == "Barrier")
		{
			Recycle();
			var det = (Transform)Instantiate(Detonator);
			det.localPosition = this.transform.localPosition;
			BarrierManager.Instance.Recycle((Transform)other.GetComponent(typeof(Transform)));
		}
	}
}
