using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

    public EnemyGenerator eg;
    public string scene;
	// Use this for initialization
	void Start () {
        gameObject.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (eg.end)
        {
            gameObject.renderer.enabled = true;

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    Application.LoadLevel(scene);
                }                
            }
        }
	}
}
