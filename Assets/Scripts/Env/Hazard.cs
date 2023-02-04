using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name == "FloorPlatform") HazardImpact();
        else if(coll.gameObject.name.StartsWith("Player"))
        {
            HazardImpact();
            //coll.GameObject.GetComponent<SomeScript>().Stun(); implement stun script here.
        }
    }

    void HazardImpact()
    {
        Destroy(gameObject);
    }
}
