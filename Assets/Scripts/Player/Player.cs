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

        void Update()
        {
            // Cache the cinemachine brain dynamically if it's missing
            if (_brain == null)
            {
                _brain = Camera.main?.GetComponent<CinemachineBrain>();
                return;
            }
            
            ICinemachineCamera activeCam = _brain.ActiveVirtualCamera;
            
            IsActive = (activeCam != null) && (activeCam.Name == Cameras.playerFollowCamera);
        }
    }
}
