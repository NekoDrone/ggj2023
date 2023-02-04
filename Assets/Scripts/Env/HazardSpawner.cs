using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    private GameObject activeHazard;
    
    void Start()
    {
        InvokeRepeating("SpawnHazard", 3.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActiveHazard(GameObject hzd)
    {
        this.activeHazard = hzd;
    }

    void SpawnHazard()
    {
        Vector3 position = new Vector3(Random.Range(-4f, 4f), 10, 0);
        Instantiate(activeHazard, position, Quaternion.identity);
    }
}
