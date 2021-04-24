﻿using UnityEngine;

// Need to call base.Awake() for every child of that class!
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null && Instance != this as T)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this as T;
    }
}
