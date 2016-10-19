using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {
	//layerMask is the name of a layer which is set in the inspector.
    public LayerMask whatIsGround;
    public bool Grounded;
	// [] signifys an array or a list of items or numbers.
    private Collider[] groundCollisions;
	//transform is the same as a gameobject.
	public Transform groundChecker;
	public float groundCheckRadius = 0.5f;
    
  
	
	// Update is called once per frame
	void Update () {
		//this puts a circle around whatever is put into the groundChecker transform, and looks for objects that have the whatIsGround layer (which is ground in the inspector).
		groundCollisions = Physics.OverlapSphere(groundChecker.position, groundCheckRadius, whatIsGround);

		//if the circle is hitting anything with the ground layer, we can jump. else we cant jump.
        if (groundCollisions.Length > 0) Grounded = true;
        else Grounded = false;
       
	}
}
