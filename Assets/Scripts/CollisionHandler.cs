using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem CrashVFX;
    // void OnCollisionEnter(Collision other) {
    //     Debug.Log(this.name + "碰撞" + other.gameObject.name);
    //     ReloadLevel();
    // }

    void OnTriggerEnter(Collider other) {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        GetComponent<PlayerControl>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        CrashVFX.Play();
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel() {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildIndex);
    }
}
