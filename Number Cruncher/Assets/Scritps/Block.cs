using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    Level level;
    [SerializeField] int maxHits;
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] hitSprites;
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TriggerSparklesVFX();
        if (tag == "Breakable")
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShownNextHitSprite();
        }
    }

    private void ShownNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array.");
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        FindObjectOfType<GameSession>().AddToScore();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
