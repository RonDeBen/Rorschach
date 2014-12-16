using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class WalkerAI : MonoBehaviour {

    public GameObject[] points;
    public float speed = 5f;
    private GameObject waypoint;
    private int index = 0;
	// Use this for initialization
	void Start () {
        waypoint = points[0];
        transform.position = waypoint.transform.position;
        index = 1;
        waypoint = points[1];
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = waypoint.transform.position - transform.position;
        rigidbody.velocity = dir.normalized * speed;
        if (Mathf.Abs(waypoint.transform.position.x - transform.position.x) < 0.2f && Mathf.Abs(waypoint.transform.position.y - transform.position.y) < 0.2f)
        {
            if (index < points.Length - 1)
            {
                index++;
                waypoint = points[index];
            }
            else
            {
                waypoint = points[0];
                index = 0;
            }
        }
	}
}
