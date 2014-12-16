using UnityEngine;
using System.Collections;

public class Puppet : MonoBehaviour {

    public GameObject master, player;
    public Camera cam, frontCam, backCam;
    private float masterPoint;
    private Ray ray = new Ray();
    private float hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        masterPoint = cam.ViewportToScreenPoint(master.transform.position).x;
        if (masterPoint > cam.pixelWidth / 2)
        {
            ray = frontCam.ScreenPointToRay(master.transform.position);
        }
        else
        {
            ray = backCam.ScreenPointToRay(master.transform.position);   
        }
        Plane playerPlane = new Plane(Vector3.forward, player.transform.position);

        if(playerPlane.Raycast(ray, out hit))
        {
            transform.position = ray.GetPoint(hit);
        }
	}
}
