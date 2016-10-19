using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	

	[SerializeField]
	private float distanceAway;
	[SerializeField]
	private float distanceOg;
	[SerializeField]
	private float smooth;
	public Transform target;
	private Vector3 targetPosition;

	private Camera _camera;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		


	}
	void LateUpdate(){
		targetPosition = target.position + Vector3.up * distanceOg - target.forward * distanceAway;
		Debug.DrawRay (target.position, Vector3.up * distanceOg, Color.red);
		Debug.DrawRay(target.position , -1f *target.forward * distanceAway, Color.blue);
		Debug.DrawLine (target.position, targetPosition, Color.magenta);
	
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * smooth);
		transform.LookAt (target);
	}


}
