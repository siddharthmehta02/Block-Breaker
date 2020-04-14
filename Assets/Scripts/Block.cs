using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] int maxHits=2;
    [SerializeField] int timesHit; //TODO remove later
    [SerializeField] Sprite[] hitSprites;

    public Level level;
    public GameStatus gamestatus;

 

    public void Start()
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag=="Breakable")
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
            ShowNextHitSprite();
        }
    }

    public void ShowNextHitSprite()
    {
        GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit-1];
    }

    private void DestroyBlock()
    {
        
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.blockDestoyed();
        TriggerSparkleVFX();
    }

    private void TriggerSparkleVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles,1f);
        
    }
}
