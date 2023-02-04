using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvLoader : MonoBehaviour
{
    [SerializeField] private Sprite floor1;
    [SerializeField] private Sprite mid1;
    [SerializeField] private Sprite back1;
    [SerializeField] private Sprite bg1;
    [SerializeField] private Sprite floor2;
    [SerializeField] private Sprite mid2;
    [SerializeField] private Sprite bg2;
    [SerializeField] private Sprite floor3;
    [SerializeField] private Sprite mid3;
    [SerializeField] private Sprite bg3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite[] GetLevelAssets(int levelcode)
    {
        Sprite[] res = new Sprite[4];
        if(levelcode == 0){
            levelcode = Random.Range(1, 4);
        }
        if(levelcode == 1){
            res[0] = floor1;
            res[1] = mid1;
            res[2] = back1;
            res[3] = bg1;
        }
        else if(levelcode == 2){
            res[0] = floor2;
            res[1] = mid2;
            res[2] = null;
            res[3] = bg2;
        }
        else if (levelcode == 3){
            res[0] = floor3;
            res[1] = mid3;
            res[2] = null;
            res[3] = bg3;
        }
        return res;
    }

    public float[] GetParallaxStrengths(int levelcode)
    {
        float[] res = new float[4];
        if(levelcode == 0){
            levelcode = Random.Range(1, 4);
        }
        if(levelcode == 1){
            res[0] = 1f;
            res[1] = 0.95f;
            res[2] = 0.7f;
            res[3] = 0f;
        }
        if(levelcode == 2){
            res[0] = 1f;
            res[1] = 0.95f;
            res[2] = 0f;
            res[3] = 0.7f;
        }
        if(levelcode == 3){
            res[0] = 0.95f;
            res[1] = 0.95f;
            res[2] = 0f;
            res[3] = 0.7f;
        }
        return res;
    }
}
