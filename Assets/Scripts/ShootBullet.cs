using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour
{
    public GameObject bullet, player;
    public Camera frontCam, backCam;
    public float bulletSpeed = 1;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    private bool flipped = false;
    private float mouseX;

    void shoot()
    {
        mouseX = Input.mousePosition.x;

        if (mouseX > Screen.width / 2 && !flipped)
        {
            flipped = true;
        }
        else if (mouseX < Screen.width / 2 && flipped)
        {
            flipped = false;
        }

        Vector3 myPos = transform.position;

        Vector3 targetPos = new Vector3();
        Plane playerPlane = new Plane(Vector3.forward, transform.position);
        Ray ray = new Ray();
        if (flipped)
        {
            ray = backCam.ScreenPointToRay(Input.mousePosition);
        }
        else
        {
            ray = frontCam.ScreenPointToRay(Input.mousePosition);
        }    
        float hitdist= 0.0f;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            targetPos = ray.GetPoint(hitdist);
        }
        Vector3 dir = targetPos - myPos;
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        GameObject bulletClone = Instantiate(bullet, myPos, Quaternion.Euler(0f, 0f, rot_z - 90)) as GameObject;
        /*if (side == -1) bulletClone.layer = LayerMask.NameToLayer("OnlyLeft");
        else if (side == 0) bulletClone.layer = LayerMask.NameToLayer("Both");
        else bulletClone.layer = LayerMask.NameToLayer("OnlyRight");*/
        //Physics.IgnoreCollision(bulletClone.collider, player.collider);
        bulletClone.rigidbody.velocity = dir.normalized * bulletSpeed;

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool leftPressed = Input.GetMouseButton(0);
        bool rightPressed = Input.GetMouseButton(1);
        if ((leftPressed || rightPressed) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            /*int side = 0;
            if (leftPressed && rightPressed) side = 0;
            else if (leftPressed) side = -1;
            else if (rightPressed) side = 1;*/
            shoot();
        }
    }
}
