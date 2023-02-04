using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardsLoader : MonoBehaviour
{
    [SerializeField] private GameObject hazard1;
    [SerializeField] private GameObject hazard2;
    [SerializeField] private GameObject hazard3;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public GameObject GetHazard(int levelcode)
    {
        if(levelcode == 0){
            levelcode = Random.Range(1, 4);
        }
        if(levelcode == 1){
            return hazard1;
        }
        if(levelcode == 2){
            return hazard2;
        }
        if(levelcode == 3){
            return hazard3;
        }
        else return hazard1;
    }
}
