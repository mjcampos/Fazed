using System;
using Singletons;
using UnityEngine;

namespace Player
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int health = 100;
        
        bool _inGas = false;
        float _damageTimer = 0f;
        float _damageInterval = 0.125f;     // 1 second
        
        bool _isGameOver = false;

        void Start()
        {
            HealthManager.Instance.SetHealthTextDisplay(health);
        }

        void Update()
        {
            if (_inGas)
            {
                _damageTimer += Time.deltaTime;

                if (_damageTimer >= _damageInterval)
                {
                    TakeDamage(1);      // Lose 1 health
                    _damageTimer = 0f;
                }
            }
        }

        void TakeDamage(int amount)
        {
            if (_isGameOver)  return;
            
            health = Mathf.Max(0,  health - amount);
            
            HealthManager.Instance.SetHealthTextDisplay(health);

            if (health < 1)
            {
                Debug.Log("Player loses");
                _isGameOver = true;
            }
        }

        public void OnGasHit()
        {
            _inGas = true;
        }

        void LateUpdate()
        {
            // Reset gas flag each frame; only stays true if gas calls OnGasHit again
            _inGas = false;
        }
    }
}
