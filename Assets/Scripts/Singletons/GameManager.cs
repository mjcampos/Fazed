using System;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] GameObject playerFollowCamera;

    void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
            
        Instance = this;
    }

    public void GameOverSequence()
    {
        // Disable the player Follow Camera
        playerFollowCamera.SetActive(false);
    }
}
