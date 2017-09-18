using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAndRight : MonoBehaviour {

    public Vector3 direction;
    public GameObject platform;
    public float right;
    public float left;

    void Start ()
    {
        direction = new Vector3 (0.03f, 0f, 0f);
        right = 3f;
        left = -3f;
    }
	
	void Update ()
    {
        float x_coordinate = platform.transform.position.x;
        if ((x_coordinate > right) | (x_coordinate < left))
        {
            direction = direction * (-1);
        }
        platform.transform.position = platform.transform.position + direction;

    }
}
