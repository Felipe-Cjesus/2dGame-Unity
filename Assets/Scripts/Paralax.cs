using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private float length;
    private float StartPos;
    private Transform cam;

    public float ParallaxEffect;


    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {

        float distance = cam.transform.position.x * ParallaxEffect;
        
        transform.position = new Vector3 (StartPos + distance, transform.position.y, transform.position.z);
    }
}
