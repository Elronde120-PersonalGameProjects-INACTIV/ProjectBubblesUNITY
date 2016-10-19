using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour {

    public Transform player;
    public float PersuitMoveSpeed;
    public float PatrolMoveSpeed;
    public float range;
   public float rotSpeed = 1f;
   public float accuracyWP = 50.0f;

    
    //Waypoints need to be at same level as origin, otherwise we get flying enimies when they should be grounded. unless they are actually flying enemies.
    public GameObject[] waypoints;
    int currentWP = 0;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = player.position - this.transform.position;
        float distanceToEnemy = Vector3.Distance(transform.position, player.transform.position);
        direction.y = 0;

        if (distanceToEnemy < range)
        {
            Persuing();
        }

        if(distanceToEnemy > range)
        {
            Patrol();
        }

    }
    
     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, range);

    }
    private void Persuing()
    {
        Vector3 direction = player.position - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);



        if (direction.magnitude > 3)
        {
            this.transform.Translate(0, 0, PersuitMoveSpeed * Time.deltaTime);

        }
    }
    void Patrol()
    {
        Vector3 direction = player.position - this.transform.position;
        if (waypoints.Length <= 0)
        {
            Debug.LogWarning("No Waypoints set for patrol!");
            return;
        }
        if(Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
        {
            currentWP = Random.Range(0, waypoints.Length);

           // currentWP++;
           // if(currentWP >= waypoints.Length)
           // {
           //     currentWP = 0;
           // }
        }
        direction = waypoints[currentWP].transform.position - transform.position;
        this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
        this.transform.Translate(0, 0, Time.deltaTime * PatrolMoveSpeed);
    }
}
