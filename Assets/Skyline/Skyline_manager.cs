using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skyline_manager : MonoBehaviour {
	public Transform Prefab;
	public int RecycleOffset,Number;
	public Vector3 StartPosition, MinSize, MaxSize;
	Queue<Transform> queue;
	
	// Use this for initialization
	void Start () {
		queue = new Queue<Transform>(Number);
		GameManager.Instance.GameStart += GameStart;
		GameManager.Instance.GameOver += GameOver;
		enabled = false;
	}
	
	void GameStart()
	{
		for(int i=0;i<Number;i++)
		{			
			Create();
			
		}
		enabled = true;
	}
	
	void GameOver()
	{
		this.enabled = false;
		//enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(queue.Count>0 && queue.Peek().localPosition.x + RecycleOffset < Jumper.Position.x )
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
		obj.localScale = new Vector3(
			Random.Range(MinSize.x,MaxSize.x),
			Random.Range(MinSize.y,MaxSize.y),
			Random.Range(MinSize.z,MaxSize.z)
			);
		var pos = new Vector3(
			StartPosition.x + obj.localScale.x/2f,
			StartPosition.y + obj.localScale.y/2f,
			StartPosition.z);
		obj.localPosition = pos;
		queue.Enqueue(obj);
		StartPosition.x += obj.localScale.x;
	}
	
	void Create()
	{
		Create((Transform)Instantiate(Prefab));
	}
}
