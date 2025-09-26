using UnityEngine;

namespace Player
{
    public class Health : MonoBehaviour
    {
        public void OnGasHit()
        {
            Debug.Log("Deduct health");
        }
    }
}
