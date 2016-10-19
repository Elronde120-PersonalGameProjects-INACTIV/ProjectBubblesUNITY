using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {
	
	[SerializeField]
	private int MoveSpeed;
	[SerializeField]
	private int jumpHeight;
	[SerializeField]
	private int rotateSpeed;

	public float jumptimer;
	private float jumpTimeCounter;
	GroundChecker groundChecker;

	Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		groundChecker = GetComponent<GroundChecker> ();
		rigidBody = GetComponent<Rigidbody> ();
		jumpTimeCounter = jumptimer;
	}
	
	// Update is called once per frame
	void Update () {



		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward * MoveSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.back * MoveSpeed *Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (Vector3.down * rotateSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (Vector3.up * rotateSpeed *Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.Space) && jumpTimeCounter > 0) {
			rigidBody.velocity = new Vector3 (rigidBody.velocity.x, jumpHeight);
		}
		if (groundChecker.Grounded == false) {
			jumpTimeCounter -= Time.deltaTime;
		}
		if (groundChecker.Grounded) {
			jumpTimeCounter = jumptimer;
		}
	}
}