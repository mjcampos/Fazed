using System;
using Helpers;
using Singletons;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CameraManager.Instance.SetActiveCamera(Cameras.endCamera);
        }
    }
}
