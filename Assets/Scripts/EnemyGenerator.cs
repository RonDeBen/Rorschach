using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

    public GameObject player; 

    [HideInInspector]
    public int enemies = 0;
    [HideInInspector]
    public float maxEnemies = 1;
    public GameObject enemy;
    public Camera cam;
    public float spawnTime;
    private Vector3 spawnHere;
    private GameObject enemyClone;
    [HideInInspector]
    public bool end = false;
    Plane playerPlane;
    Ray ray;
    float hit;

	void Start () {
	}
	
	void Update () {
        //print("Enemies: " + enemies + " maxEnemies: " + maxEnemies);
        if (enemies < maxEnemies && !end)
        {
            enemies++;
            StartCoroutine(spawning(spawnTime));
        }


        if (maxEnemies > 7)
        {
            Destroy(player);
            end = true;
        }
        //maxEnemies = (int)(Mathf.Sqrt(s.score / 100));
	}

    /*void Spawn()
    {
        playerPlane = new Plane(Vector3.forward, transform.position);
        ray = cam.ViewportPointToRay(new Vector3(Random.Range(1.0f, 0.0f), Random.Range(1.0f, 0.0f), 0.0f));
        
        if (playerPlane.Raycast(ray, out hit))
        {
            spawnHere = ray.GetPoint(hit);
            GameObject enemyClone = Instantiate(enemy, spawnHere, transform.rotation) as GameObject;
            StartCoroutine(spawning(spawnTime, enemyClone));
        }
    }*/



    IEnumerator spawning(float spawnTime)
    {
        yield return new WaitForSeconds(spawnTime);

        playerPlane = new Plane(Vector3.forward, transform.position);
        ray = cam.ViewportPointToRay(new Vector3(Random.Range(1.0f, 0.0f), Random.Range(1.0f, 0.0f), 0.0f));
        if (playerPlane.Raycast(ray, out hit))
        {
            spawnHere = ray.GetPoint(hit);
            enemyClone = Instantiate(enemy, spawnHere, transform.rotation) as GameObject;
            /*float v = Random.value;
            if (v < 0.33f) enemyClone.layer = LayerMask.NameToLayer("Both");
            else if (v < 0.67) enemyClone.layer = LayerMask.NameToLayer("OnlyRight");
            else enemyClone.layer = LayerMask.NameToLayer("OnlyLeft");*/
        }       
    }
}
