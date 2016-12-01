using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BorderManager : MonoBehaviour {

	public Transform Border;
	public int RecycleOffset, SpawnOffset, Number;
	public Vector3 StartPosition, Size;
	public Quaternion Rotation;
	Queue<Transform> queue;
	
	// Use this for initialization
	void Start () {
		queue = new Queue<Transform>(Number);
		
		GameManager.Instance.GameStart += GameStart;	
		GameManager.Instance.GameOver += GameOver;
		this.enabled = false;
	}
	
	void GameStart()
	{		
		this.enabled = true;
				
		while(queue.Count<Number)
		{			
			Create();
		}
		
	}
	
	void GameOver()
	{
		this.enabled = false;
		//enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(queue.Peek().localPosition.x + RecycleOffset < Jumper.Position.x )
		{
			Recycle();
			
		}
	}
	
	void Recycle()
	{
		if(queue.Count>0)
		{
			Create(queue.Dequeue());
		}
	}
	
	void Create(Transform obj)
	{
		obj.localScale = Size;
		var pos = new Vector3(
			StartPosition.x + obj.localScale.x/2f,
			StartPosition.y + obj.localScale.y/2f,
			StartPosition.z);
		obj.localPosition = pos;
		obj.localRotation = Rotation;
		queue.Enqueue(obj);
		StartPosition.x += obj.localScale.x;
	}
	
	void Create()
	{
		Create((Transform)Instantiate(Border));
	}
}
