using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float parallaxStrength = 0;
    [SerializeField] private GameObject cam;
    private float cameraPosition;
    
    void Start()
    {
        cameraPosition = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float delta = cam.transform.position.x * parallaxStrength;
        transform.position = new Vector3(cameraPosition + delta, transform.position.y, transform.position.z);
    }
}
