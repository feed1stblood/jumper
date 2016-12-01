using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarrierManager: MonoBehaviour {
	public Vector3 StartPosition;
	public Vector3 MinSize,MaxSize;
	public Vector3 MinRotationV, MaxRotationV;
	public int YRange;
	public int RecycleOffset, Number;
	public float MaxInterval;
	public Transform Prefab;
	LinkedList<Transform> queue;
	
	public static BarrierManager Instance;
	
	// Use this for initialization
	void Start () {
		Instance = this;
		queue = new LinkedList<Transform>();
		GameManager.Instance.GameStart += GameStart;	
		GameManager.Instance.GameOver += GameOver;
		this.enabled = false;
	}
	
	void GameStart()
	{		
		this.enabled = true;
		for(int i=0;i<5;i++)
			Recycle();
		
		while(queue.Count<Number)
		{			
			Create();
		}
		
	}
	
	void GameOver()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		if(queue.Count>0 && queue.First.Value.localPosition.x + RecycleOffset < Jumper.Position.x)
		{
			Recycle();
			
		}
	}
	
	void Recycle()
	{
		if(queue.Count>0)
		{
			Recycle(queue.First.Value);
		}
	}
	
	public void Recycle(Transform obj)
	{
		queue.Remove(obj);
		Create(obj);
	}
	
	void Create(Transform obj)
	{
		obj.localScale = new Vector3(
			Random.Range(MinSize.x, MaxSize.x),
			Random.Range(MinSize.y, MaxSize.y),
			Random.Range(MinSize.z, MaxSize.z)
			);
		var pos = new Vector3(
			StartPosition.x + Random.Range(obj.localScale.x, MaxInterval),
			Random.Range(StartPosition.y - YRange, StartPosition.y + YRange),
			StartPosition.z);
		var rotV = new Vector3(
			Random.Range(MinRotationV.x,MaxRotationV.x),
			Random.Range(MinRotationV.y,MaxRotationV.y),
			Random.Range(MinRotationV.z,MaxRotationV.z)
			);
		obj.localPosition = pos;
		((Barrier)(obj.GetComponent(typeof(Barrier)))).RotationVelocity = rotV;
		if(!queue.Contains(obj))
			queue.AddLast(obj);
		StartPosition.x = pos.x;
	}
	
	void Create()
	{
		Create((Transform)Instantiate(Prefab));
	}
}
