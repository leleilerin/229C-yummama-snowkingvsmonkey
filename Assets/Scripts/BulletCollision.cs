using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private GameObject enemyPlayer;
    private bool isPlayer1;
    private float uptime = 5f;

    private void Start()
    {
        isPlayer1 = enemyPlayer.GetComponent<PlayerControl>().IsPlayer1();
    }

    private void Update()
    {
        Destroy(gameObject, uptime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (isPlayer1)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.instance.PlayerGotHit(isPlayer1);
                Destroy(gameObject);
                Debug.Log("destroy bc bullet");
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Player2"))
            {
                GameManager.instance.PlayerGotHit(isPlayer1);
                Destroy(gameObject);
                Debug.Log("destroy bc bullet");
            }
        }
        
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("hit wall");
        }
    }
}
