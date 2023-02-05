using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameDetector : MonoBehaviour
{
    [Tooltip("P1 = Left side of the arena")]
    [SerializeField] private bool isPlayerOneSide = true;    // left side
    [SerializeField] private EndGameManager endGameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        endGameManager.TriggerEndGame(isPlayerOneSide);
    }
}
