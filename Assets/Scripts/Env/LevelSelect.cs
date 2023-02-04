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
    private EnvLoader loader;
    // Start is called before the first frame update
    void Start()
    {
        loader = GetComponent<EnvLoader>();
    }

    public void ChangeAssets(int levelcode)
    {
        Sprite[] sprites = new Sprite[4];
        sprites = loader.GetLevelAssets(levelcode);
        floor.GetComponent<SpriteRenderer>().sprite = sprites[0];
        mid.GetComponent<SpriteRenderer>().sprite = sprites[1];
        back.GetComponent<SpriteRenderer>().sprite = sprites[2];
        bg.GetComponent<SpriteRenderer>().sprite = sprites[3];
        float[] parallaxStrengths = new float[4];
        parallaxStrengths = loader.GetParallaxStrengths(levelcode);
        floor.GetComponent<ParallaxEffect>().SetParallaxStrength(parallaxStrengths[0]);
        mid.GetComponent<ParallaxEffect>().SetParallaxStrength(parallaxStrengths[1]);
        back.GetComponent<ParallaxEffect>().SetParallaxStrength(parallaxStrengths[2]);
        bg.GetComponent<ParallaxEffect>().SetParallaxStrength(parallaxStrengths[3]);
    }

}
