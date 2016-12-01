using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {
	public Vector3 RotationVelocity;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(RotationVelocity * Time.deltaTime);
	}
}
