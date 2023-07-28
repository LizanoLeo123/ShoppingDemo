using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int sceneToLoad;
    public Image playerImage;
    public Sprite[] skins;
    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    private void Start()
    {
        int lastSkin = PlayerPrefs.GetInt("skin");
        if (lastSkin != 0)
        {
            playerImage.sprite = skins[lastSkin];
        }
        else
        {
            playerImage.sprite = skins[0];
        }
    }

    public void ResetSkin()
    {
        PlayerPrefs.SetInt("skin", 0);
        playerImage.sprite = skins[0];
    }
}
