using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores and loads the responses from the Player and Arena selection screens
/// </summary>
public class DataSelectionManager : MonoBehaviour
{
    public static ArenaSelection SelectedArena { get; private set; } = ArenaSelection.Random;
    public static PlayerClass SelectedP1Class { get; private set; } = PlayerClass.Carrot;
    public static PlayerClass SelectedP2Class { get; private set; } = PlayerClass.Daikon;

    /// <summary>
    /// To be called by Button OnClick callback
    /// </summary>
    public void SetSelectedArena(int selection)
    {
        SelectedArena = (ArenaSelection)selection;
    }

    /// <summary>
    /// To be called by Button OnClick callback
    /// </summary>
    public void SetSelectedPlayer1Class(int selection)
    {
        SelectedP1Class = (PlayerClass)selection;
    }

    /// <summary>
    /// To be called by Button OnClick callback
    /// </summary>
    public void SetSelectedPlayer2Class(int selection)
    {
        SelectedP2Class = (PlayerClass)selection;
    }
}
