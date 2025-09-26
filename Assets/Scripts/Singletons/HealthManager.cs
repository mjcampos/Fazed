using System;
using TMPro;
using UnityEngine;

namespace Singletons
{
    public class HealthManager : MonoBehaviour
    {
        public static HealthManager Instance { get; private set; }
        
        [SerializeField] TextMeshProUGUI healthText;

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

        public void SetHealthTextDisplay(int amount)
        {
            healthText.text = amount.ToString();
        }
    }
}
