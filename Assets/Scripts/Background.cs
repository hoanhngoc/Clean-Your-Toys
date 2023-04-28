using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public Sprite[] backgrounds;
    public Image backgroundImage; // the image component that displays the background

    void Start()
    {
        // choose a random background from the array
        int index = Random.Range(0, backgrounds.Length);
        Sprite newBackground = backgrounds[index];

        // set the background image to the new background
        backgroundImage.sprite = newBackground;
    }
}
