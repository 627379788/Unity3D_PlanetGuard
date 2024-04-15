using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyEffect;
    [SerializeField] GameObject HitEffect;
    [SerializeField] int health = 3;
    [SerializeField] int scorePerHit = 15;
    ScoreBoader scoreBoader;
    GameObject parentGameObject;


    void Start()
    {
        scoreBoader = FindObjectOfType<ScoreBoader>();
        parentGameObject = GameObject.FindWithTag("EnemyParent");
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        gameObject.AddComponent<Rigidbody>().useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessScore();
        if (health == 0) { 
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(enemyEffect, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }

    void ProcessScore()
    {
        GameObject vfx = Instantiate(HitEffect, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        health -= 1;
        scoreBoader.IncreaseScore(scorePerHit);
    }
}
