using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config paramaters
    [SerializeField] AudioClip myAudioClip;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
    GameStatus gameStatus;
    // cached reference
    Level level;
    //state variables
    [SerializeField] int timesHit; //Serialized for debugging
    [SerializeField] bool isSpecial;



    void Start()
    {
        CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>();
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
        AudioSource.PlayClipAtPoint(myAudioClip, Camera.main.transform.position);
        if (tag == "Breakable")
        {
            HandleHit(collision);
        }

    }
    private void HandleHit(Collision2D collision)
    {
        if (gameStatus.instantDestory)
        {
            DestroyBlock();
        }
        else
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                DestroyBlock();
                //Special Block Check
                if (isSpecial == true)
                {
                    int randomNumber = 1 /*UnityEngine.Random.Range(1, 4);*/ ;
                    FindObjectOfType<AbilityManager>().HandleAbility(randomNumber); //Allows Ability Manager to handle ability
                }
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array");
        }
      
    }

    private void DestroyBlock()
    {
            GameStatus gameStatus = FindObjectOfType<GameStatus>();
            Destroy(gameObject);
            level.RemoveBreakableBlock();
            gameStatus.AddScore();
            TriggerSparklesVFX();
        
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position , transform.rotation);
        Destroy(sparkles, 2);
    }
}
