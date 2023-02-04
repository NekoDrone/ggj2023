using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class PlayerIcon
{
    public PlayerClass playerClass;
    public string playerName;
    public Sprite playerIcon;
    public string skillName;
    public Sprite skillIcon;
}

public class CombatUI_Player : MonoBehaviour
{
    [SerializeField] private PlayerIcon[] playerIconsList;
    Dictionary<PlayerClass, string> playerNames;
    Dictionary<PlayerClass, Sprite> playerIcons;
    Dictionary<PlayerClass, string> skillNames;
    Dictionary<PlayerClass, Sprite> skillIcons;

    [Header("P1 UI Objects")]
    [SerializeField] private TMP_Text player1Name;
    [SerializeField] private Image player1Icon;
    [SerializeField] private TMP_Text player1SkillName;
    [SerializeField] private Image player1Skill;
    [Header("P2 UI Objects")]
    [SerializeField] private TMP_Text player2Name;
    [SerializeField] private Image player2Icon;
    [SerializeField] private TMP_Text player2SkillName;
    [SerializeField] private Image player2Skill;

    // Start is called before the first frame update
    void Awake()
    {
        playerNames = new Dictionary<PlayerClass, string>();
        playerIcons = new Dictionary<PlayerClass, Sprite>();
        skillNames = new Dictionary<PlayerClass, string>();
        skillIcons = new Dictionary<PlayerClass, Sprite>();

        foreach (PlayerIcon p in playerIconsList)
        {
            playerNames.Add(p.playerClass, p.playerName);
            playerIcons.Add(p.playerClass, p.playerIcon);
            skillNames.Add(p.playerClass, p.skillName);
            skillIcons.Add(p.playerClass, p.skillIcon);
        }
    }
    
    public void SetPlayer1(PlayerClass pClass)
    {
        player1Name.text = playerNames[pClass];
        player1Icon.sprite = playerIcons[pClass];
        player1SkillName.text = skillNames[pClass];
        player1Skill.sprite = skillIcons[pClass];
    }

    public void SetPlayer2(PlayerClass pClass)
    {
        player2Name.text = playerNames[pClass];
        player2Icon.sprite = playerIcons[pClass];
        player2SkillName.text = skillNames[pClass];
        player2Skill.sprite = skillIcons[pClass];
    }
}
