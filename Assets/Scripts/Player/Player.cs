using System;
using Cinemachine;
using Helpers;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public bool IsActive { get; private set; } = false;

        CinemachineBrain _brain;
        CinemachineVirtualCamera _camera;

        void Start()
        {
            _brain = Camera.main.GetComponent<CinemachineBrain>();
        }

        void Update()
        {
            if (_brain != null)
            {
                ICinemachineCamera activeCam = _brain.ActiveVirtualCamera;
                
                IsActive = activeCam.Name == Cameras.playerFollowCamera;
            }
        }
    }
}
