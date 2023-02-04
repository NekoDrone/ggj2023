using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    ///<references> for currLevel levels
    /// 1 = Chopping Board
    /// 2 = Fridge
    /// 3 = Mookata
    ///</references>
    public int currLevel;
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject mid;
    [SerializeField] private GameObject back;
    [SerializeField] private GameObject bg;
    private EnvLoader envloader;
    private HazardsLoader hazloader;
    private HazardSpawner hazspawner;
    // Start is called before the first frame update
    void Awake()
    {
        envloader = GetComponent<EnvLoader>();
        hazloader = GetComponent<HazardsLoader>();
        hazspawner = GetComponent<HazardSpawner>();
    }

    void Start()
    {
        hazspawner.SetActiveHazard(hazloader.GetHazard(1));
        // ChangeAssets(3);
    }

    public void ChangeAssets(int levelcode)
    {
        if(levelcode == 3){
            mid.transform.position = new Vector3(0f,-2.1f,0f);
        }
        Sprite[] sprites = new Sprite[4];
        sprites = envloader.GetLevelAssets(levelcode);
        floor.GetComponent<SpriteRenderer>().sprite = sprites[0];
        mid.GetComponent<SpriteRenderer>().sprite = sprites[1];
        back.GetComponent<SpriteRenderer>().sprite = sprites[2];
        bg.GetComponent<SpriteRenderer>().sprite = sprites[3];
        float[] parallaxStrengths = new float[4];
        parallaxStrengths = envloader.GetParallaxStrengths(levelcode);
        floor.GetComponent<ParallaxEffect>().SetParallaxStrength(parallaxStrengths[0]);
        mid.GetComponent<ParallaxEffect>().SetParallaxStrength(parallaxStrengths[1]);
        back.GetComponent<ParallaxEffect>().SetParallaxStrength(parallaxStrengths[2]);
        bg.GetComponent<ParallaxEffect>().SetParallaxStrength(parallaxStrengths[3]);
        hazspawner.SetActiveHazard(hazloader.GetHazard(levelcode));

    }

}
