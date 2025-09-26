using System;
using Cinemachine;
using Helpers;
using UnityEngine;

namespace Singletons
{
    public class CameraManager : MonoBehaviour
    {
        public static CameraManager Instance { get; private set; }
        
        [SerializeField] CinemachineVirtualCamera[] cameras;
        
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

        void Start()
        {
            SetActiveCamera(Cameras.startCamera);
        }

        public void SetActiveCamera(string cameraName)
        {
            foreach (var camera in cameras)
            {
                camera.Priority = (camera.name == cameraName) ? 10 : 1;
            }
        }
    }
}
