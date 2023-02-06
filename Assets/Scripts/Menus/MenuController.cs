using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuGroup;
    [SerializeField] private GameObject SettingsGroup;
    [SerializeField] private GameObject ArenaSelectGroup;
    [SerializeField] private GameObject CreditsGroup;
    [SerializeField] private GameObject CharSelectGroup;
    private GameObject CurrGroup;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonClicked()
    {
        MainMenuGroup.SetActive(false);
        CurrGroup = ArenaSelectGroup;
        ArenaSelectGroup.SetActive(true);
    }

    public void SettingsButtonClicked()
    {
        MainMenuGroup.SetActive(false);
        CurrGroup = SettingsGroup;
        SettingsGroup.SetActive(true);
    }

    public void CreditsButtonClicked()
    {
        MainMenuGroup.SetActive(false);
        CurrGroup = CreditsGroup;
        CreditsGroup.SetActive(true);
    }

    public void BackButtonClicked()
    {
        CurrGroup.SetActive(false);
        CurrGroup = MainMenuGroup;
        MainMenuGroup.SetActive(true);
    }

    public void ArenaButtonClicked()
    {
        CurrGroup.SetActive(false);
        CurrGroup = CharSelectGroup;
        CharSelectGroup.SetActive(true);
    }
}
