using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private LevelSelect levelSelector;
    [SerializeField] private PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
    }

    /// <summary>
    /// Initialise the game scene.
    /// </summary>
    private void LoadGame()
    {
        // load environment
        levelSelector.ChangeAssets(2);//(int)DataSelectionManager.SelectedArena);

        // TODO: load players

    }
}
