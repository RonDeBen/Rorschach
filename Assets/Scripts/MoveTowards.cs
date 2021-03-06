using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MoveTowards : MonoBehaviour {
    public GameObject FollowThis;
    public float speed;
    public bool shouldFollow = true;
    public EnemyGenerator eg;
	void Start () {
        eg = GameObject.Find("EnemySpawner").GetComponent("EnemyGenerator") as EnemyGenerator;
        FollowThis = GameObject.Find("player");
	}


    void Update () {
        if (shouldFollow && !eg.end)
        {
            Vector3 dir = FollowThis.transform.position - transform.position;
            rigidbody.velocity = dir.normalized * speed;

            float diffX = FollowThis.transform.position.x - transform.position.x;
            float diffY = FollowThis.transform.position.y - transform.position.y;


            float angle = Mathf.Atan2(diffY, diffX) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
	}
}
