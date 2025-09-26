using System;
using UnityEngine;

namespace Gas
{
    public class GasCollision : MonoBehaviour
    {
        void OnParticleCollision(GameObject other)
        {
            if (other.CompareTag("Player"))
            {
                other.SendMessage("OnGasHit", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
