using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; private set; }

    [Header("PlayerPrefs Keys")]
    [SerializeField] private string themeKey = "Theme";
    [SerializeField] private string volumeKey = "Volume";
    [SerializeField] private string durationKey = "Duration";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("SettingsManager already exists in " + Instance.gameObject.name + ", deleting SettingsManager in " + gameObject.name);
            Destroy(this);
        }
    }

    public int GetTheme()
    {
        return PlayerPrefs.GetInt(themeKey, 0);
    }

    public void SetTheme(int theme)
    {
        PlayerPrefs.SetInt(themeKey, theme);
    }

    public float GetVolume()
    {
        return PlayerPrefs.GetFloat(volumeKey, 1f);
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat(volumeKey, volume);
    }

    public float GetDuration()
    {
        return PlayerPrefs.GetInt(durationKey, 180);
    }

    public void SetDuration(int duration)
    {
        PlayerPrefs.SetInt(durationKey, duration);
    }

    /// <summary>
    /// Called when clicking Back button
    /// </summary>
    public void SaveSettings()
    {
        PlayerPrefs.Save();
    }
}
