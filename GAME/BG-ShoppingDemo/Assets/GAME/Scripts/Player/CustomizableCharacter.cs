using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CODE BY GoldenEvolution https://www.youtube.com/watch?v=t2UUHI4eudI
// I needed something that works quick and simple due to time limitation.
public class CustomizableCharacter : MonoBehaviour
{
    // This script should be added to the main character and won't be used for accessories

    public int skinNr;

    // This is where the spritesheets go
    // In the inspector, set the size to, for example 5, if you have 5 spritesheets
    // Then open your sprite sheet and add EACH INDIVIDUAL SPRITE in here
    // This means if your spritesheet has 10 frames, the Sprites element in the inspector needs to contain these 10 sprites
    // Might not be the most optimal solution for this problem but it works.
    
    public Skins[] skins;
    SpriteRenderer spriteRenderer;

    // This spriteNr is helpful to easily add more accessories using the CustomizableAccessories.cs script
    public int spriteNr;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (skinNr > skins.Length - 1) skinNr = 0;
        else if (skinNr < 0) skinNr = skins.Length - 1;
    }

    void LateUpdate()
    {
        SkinChoice();
    }

    void SkinChoice()
    {
        if (spriteRenderer.sprite.name.Contains("BaseCharacter"))
        {
            //Get the number of the sprite out of the sprite renderer sprite name
            string spriteName = spriteRenderer.sprite.name;
            spriteName = spriteName.Replace("BaseCharacter_", "");
            spriteNr = int.Parse(spriteName);

            //Replace current sprite
            spriteRenderer.sprite = skins[skinNr].sprites[spriteNr];
        }
    }

    // UI Element - Linked to a button to select the next skin
    public void SkinPlus()
    {
        skinNr++;
    }

    // UI Element - Linked to a button to select the previous skin
    public void SkinMin()
    {
        skinNr--;
    }
}

[System.Serializable]
public struct Skins
{
    public Sprite[] sprites;
}
