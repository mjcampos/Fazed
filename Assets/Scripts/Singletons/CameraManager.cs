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

        GameObject _instructionsCanvas;
        
        void Awake()
        {
            // Singleton setup
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
                
            Instance = this;

            InstructionSetup();
        }

        public void SetActiveCamera(string cameraName)
        {
            foreach (var camera in cameras)
            {
                camera.Priority = (camera.name == cameraName) ? 10 : 1;
            }
        }
        
        void InstructionSetup()
        {
            SetActiveCamera((_instructionsCanvas != null) ? Cameras.startCamera : Cameras.playerFollowCamera);
        }
    }
}
