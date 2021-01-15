using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject sparkles;
    [SerializeField] Sprite[] sprites;
    [SerializeField] int maxHits = 1;

    [SerializeField] int currentHits = 0;


    Level level;
    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.incrementBlockCount();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            ++currentHits;
            {
                if (currentHits >= maxHits)
                {
                    DestroyBlock();
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = sprites[currentHits - 1];
                }
            }
        }
    }

    private void DestroyBlock()
    {
        sparkleEffect();
        FindObjectOfType<GameState>().addScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.decrementBlockCount();
        Destroy(gameObject);

    }
    private void sparkleEffect()
    {
        GameObject sparkle = Object.Instantiate(sparkles, transform.position, transform.rotation);
        Destroy(sparkle, 1f);
    }
}
