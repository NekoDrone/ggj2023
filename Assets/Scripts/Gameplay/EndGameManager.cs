using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharacterWinLoseSprite
{
    public PlayerClass playerClass;
    public GameObject winSprite;
    public GameObject loseSprite;
}

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameObject endGameCanvas;
    [SerializeField] private GameObject combatUICanvas;

    [Header("Character Win/Lose Sprites")]
    [SerializeField] private CharacterWinLoseSprite[] characterSprites;
    private Dictionary<PlayerClass, CharacterWinLoseSprite> sprites;

    bool endGame = false;

    // Start is called before the first frame update
    void Awake()
    {
        sprites = new Dictionary<PlayerClass, CharacterWinLoseSprite>();
        foreach (CharacterWinLoseSprite c in characterSprites)
        {
            sprites.Add(c.playerClass, c);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerEndGame(bool playerOneLost)
    {
        if (endGame)    // JIC; end game can only be triggered once
            return;

        // enable end game UI
        endGameCanvas.SetActive(true);
        // disable combat UI
        combatUICanvas.SetActive(false);

        // set winner and loser sprites on end game screen
        if (playerOneLost)  // player 1 (left side) lost
        {
            // set winner as player 2
            sprites[playerManager.Player2.PlayerClass].winSprite.SetActive(true);

            // set loser as player 1
            sprites[playerManager.Player1.PlayerClass].loseSprite.SetActive(true);

        }
        else    // player 2 (right side) lost
        {
            // set winner as player 1
            sprites[playerManager.Player1.PlayerClass].winSprite.SetActive(true);

            // set loser as player 2
            sprites[playerManager.Player2.PlayerClass].loseSprite.SetActive(true);
        }

        /*
        if (playerOneLost)  // player 1 (left side) lost
        {
            // activate winning animation for player 2
            playerManager.Player2.TriggerWin();

            // activate death animation for player 1
            playerManager.Player1.TriggerLose();

        }
        else    // player 2 (right side) lost
        {
            // activate winning animation for player 1
            playerManager.Player1.TriggerWin();

            // activate death animation for player 2
            playerManager.Player2.TriggerLose();
        }*/
    }
}
