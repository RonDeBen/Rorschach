using UnityEngine;
using System.Collections;

public class TurretSpawn : MonoBehaviour {

    public GameObject turret,player;
    public int amount;
    private float randX, randY;
	// Use this for initialization
	void Start () {
        for (int k = 0; k < amount; k++)
        {
            do{            
                randX = Random.Range(0.0f, 20f);
            }while (Mathf.Abs(randX - player.transform.position.x) < 5f);
            do
            {
                randY = Random.Range(0.0f, 30f);
            } while (Mathf.Abs(randY - player.transform.position.y) < 5f);
            Instantiate(turret, new Vector3(Random.Range(0.0f, 20f), Random.Range(0.0f, 30f), 0), transform.rotation);
        }
	}
}
