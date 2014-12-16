using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour {
    public float cooldown, size;
    public int points;
    private EnemyGenerator eg;
    private Score s;
    private bool hit = false;
    private Splat spl;
	// Use this for initialization
	void Start () {
        eg = GameObject.Find("EnemySpawner").GetComponent<EnemyGenerator>();
        s = GameObject.Find("score").GetComponent<Score>();
        spl = GameObject.Find("splatter").GetComponent<Splat>();
	}

    void Update()
    {
        if (eg.end)
        {
            StartCoroutine(explode(cooldown));
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!hit && gameObject!=null)
        {
            hit = true;
            eg.enemies--;
            s.add(points);
            eg.maxEnemies = (int)(Mathf.Sqrt(s.score / 100));
            if (eg.maxEnemies < 1)
                eg.maxEnemies = 1;
            Destroy(gameObject.GetComponent<BoxCollider>());
            Destroy(collider.gameObject);
            StartCoroutine(explode(cooldown));
        }
    }


    IEnumerator explode(float cooldown)
    {
        /*gameObject.particleSystem.startSize = size;
        if (!gameObject.particleSystem.isPlaying)
        {
            gameObject.particleSystem.Play();
        }*/
        spl.splatter(transform.position);
        Destroy(gameObject);
        yield return new WaitForSeconds(cooldown);
    }
}
