using UnityEngine;
using System.Collections;
public class BoundedCam : MonoBehaviour
{
    public GameObject focus, topLeft, topRight, bottomLeft, bottomRight;
    private Rect playerBound, cameraBound;
    private Vector3 bl;
    private float playerX, playerY, camX, camY;
    public Camera backCam;
    public EnemyGenerator eg;
    // Use this for initialization
    void Start()
    {        
        
        float frustumHeight = camera.orthographicSize * 2;
        float frustumWidth = frustumHeight * (Screen.width / Screen.height);
        playerBound = new Rect(topLeft.transform.position.x, topLeft.transform.position.y, topRight.transform.position.x - topLeft.transform.position.x, topLeft.transform.position.y - bottomLeft.transform.position.y);
        float x = topLeft.transform.position.x + (frustumWidth / 2.0f);
        float y = topLeft.transform.position.y - (frustumHeight / 2.0f);
        float width = (topRight.transform.position.x - frustumWidth / 2.0f) - x;
        float height = y - (bottomLeft.transform.position.y + frustumHeight / 2.0f);

        bl = new Vector3(x, bottomLeft.transform.position.y + frustumHeight / 2.0f, transform.position.z);

        cameraBound = new Rect(x, y, width, height);
    }
    // Update is called once per frame
    void Update()
    {
        if (!eg.end)
        {
            if (focus.rigidbody.velocity != Vector3.zero)
            {
                playerX = bottomLeft.transform.position.x - focus.transform.position.x;
                playerY = bottomLeft.transform.position.y - focus.transform.position.y;
                camX = (playerX * cameraBound.width) / playerBound.width;
                camY = (playerY * cameraBound.height) / playerBound.height;
                transform.position = new Vector3(bl.x - camX, bl.y - camY, transform.position.z);
            }
        }
        else
        {
            camera.orthographicSize = 7.5f;
            backCam.orthographicSize = camera.orthographicSize;
            transform.position = new Vector3(6.75f, 8f, -10f);
            backCam.transform.position = transform.position;
        }
    }
}