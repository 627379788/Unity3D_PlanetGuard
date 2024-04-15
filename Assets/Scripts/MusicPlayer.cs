using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Start()
    {
        int MusicObjLen = FindObjectsOfType<MusicPlayer>().Length;
        if (MusicObjLen > 1) {
            Destroy(gameObject);
        }else {
            DontDestroyOnLoad(gameObject);
        }
    }
}
