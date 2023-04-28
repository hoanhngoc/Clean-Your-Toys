using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toys : MonoBehaviour
{
    public Sprite[] sprites; // an array of sprites to choose from
    [SerializeField] private AudioClip hitsound;

    void Start()
    {
        // choose a random sprite from the array
        int index = Random.Range(0, sprites.Length);
        Sprite newSprite = sprites[index];

        // set the sprite to the new sprite
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            Debug.Log("is track");
            SoundManager.instance.PlaySound(hitsound);
            gameObject.SetActive(false);
        }
    }
}
