using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public float triggerDist = 5f;
    public float shootDelay = 1f;
    public float bulletSpeed = 10f;
    public GameObject bullet, player;
    private float nextFire = 0.0f;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(player.transform.position, transform.position) < triggerDist && Time.time > nextFire)
        {
            nextFire = Time.time + shootDelay;
            shoot();
        }
	}

    void shoot()
    {
        Vector3 dir = player.transform.position - transform.position;
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, rot_z - 90)) as GameObject;
        bulletClone.rigidbody.velocity = dir.normalized * bulletSpeed;
    }
}
