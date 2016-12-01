using UnityEngine;
using System.Collections;

public class Jumper : MonoBehaviour {
	public Transform Detonator;
	public static Vector3 Position;
	public static float distance;
	public float startX;
	public static int numberPowerup;
	
	
	
	// Use this for initialization
	void Start () {
		GameManager.Instance.GameStart += GameStart;
		GameManager.Instance.GameOver += GameOver;
		this.enabled = false;
		this.renderer.enabled = false;
		this.rigidbody.isKinematic = true;
	}
	
	
	void GameStart()
	{
		
		this.enabled = true;
		this.renderer.enabled = true;
		this.rigidbody.isKinematic = false;
		this.transform.localPosition = new Vector3 (
			this.transform.localPosition.x,
			0,
			0);
		startX = this.transform.localPosition.x;
		rigidbody.AddForce(10,0,0,ForceMode.VelocityChange);
		numberPowerup = 3;
		
	}
	
	void GameOver()
	{
		var det = (Transform)Instantiate(Detonator);
		det.localPosition = this.transform.localPosition;
		this.rigidbody.Sleep();
		renderer.enabled = false;
		this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(rigidbody.velocity.y > 10)
			rigidbody.AddForce(0,-1,0,ForceMode.VelocityChange);
		if(Input.GetButtonDown("Jump"))
		{
			rigidbody.AddForce(0,15,0,ForceMode.VelocityChange);			
			
		}
		Position = transform.localPosition;
		distance = transform.localPosition.x - startX;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Border"||other.tag=="Barrier")
		{
			GameManager.Instance.OnGameOver();
		}

		
	}
}
