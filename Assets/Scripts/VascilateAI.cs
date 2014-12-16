using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class VascilateAI : MonoBehaviour {
    public GameObject FollowThis;
    public float speed, cooldown;
    private float wait;
    private float dist;
    public bool shouldFollow = false;
    public int reverse = 1;
    void Start()
    {
        //FollowThis = GameObject.Find("player");
        dist = Mathf.Sqrt(Mathf.Pow(transform.position.x - FollowThis.transform.position.x, 2) + Mathf.Pow(transform.position.y - FollowThis.transform.position.y, 2));
        wait = dist % 3;
        StartCoroutine(redLight(wait));
        shouldFollow = true;
    }


    void Update()
    {
        if (shouldFollow)
        {
            Vector3 dir = FollowThis.transform.position - transform.position;
            rigidbody.velocity = dir.normalized * speed * reverse;

            float diffX = FollowThis.transform.position.x - transform.position.x;
            float diffY = FollowThis.transform.position.y - transform.position.y;

            //maybe
            float angle = Mathf.Atan2(diffY, diffX) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
        else
            rigidbody.velocity = Vector3.zero;
    }

    IEnumerator redLight(float wait)
    {
        yield return new WaitForSeconds(wait);
        //shouldFollow = !shouldFollow;
        reverse *= -1;
        StartCoroutine(redLight(cooldown));
    }

    IEnumerator lel(float wait)
    {
        yield return new WaitForSeconds(wait);
        StartCoroutine(redLight(cooldown));
    }
}
