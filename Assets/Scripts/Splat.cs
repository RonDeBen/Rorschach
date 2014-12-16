using UnityEngine;
using System.Collections;

public class Splat : MonoBehaviour {

    public GameObject[] splats;

    public void splatter(Vector3 pos)
    {
        int splatter = Random.RandomRange(0, splats.Length);
        Instantiate(splats[splatter], pos, Quaternion.identity);
    }
}
