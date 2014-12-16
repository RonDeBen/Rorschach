using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class BulletExplode : MonoBehaviour {

    public Camera cam;
    public float size = 3.5f;
    public float cooldown = 0.5f;
    //private ParticleSystem ps;

    void Start()
    {
        cam = GameObject.Find("Front Camera").GetComponent<Camera>();
    }

	void Update () {
        if (cam.WorldToViewportPoint(transform.position).x < 0
            || cam.WorldToViewportPoint(transform.position).x > 1
            || cam.WorldToViewportPoint(transform.position).y < 0
            || cam.WorldToViewportPoint(transform.position).y > 1)
        {
            Destroy(gameObject);
            //StartCoroutine(explode(cooldown));
        }
    }
        IEnumerator explode(float cooldown){
            //gameObject.particleSystem.startSize = size;
            yield return new WaitForSeconds(cooldown);
            Destroy(gameObject);
        }

}
