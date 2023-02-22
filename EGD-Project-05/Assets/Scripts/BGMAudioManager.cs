using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Implementation from https://www.youtube.com/watch?v=PHa5SNe1Mmk
public class BGMAudioManager : MonoBehaviour
{
    private static BGMAudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
