using System;
using Singletons;
using UnityEngine;

namespace Player
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int health = 100;
        [SerializeField] GameObject playerFollowCamera;
        
        Player _player;
        
        bool _inGas = false;
        float _damageTimer = 0f;
        float _damageInterval = 0.125f;     // 1 second

        void Start()
        {
            _player = GetComponent<Player>();
            
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
            if (!_player.IsStillAlive) return;
            
            health = Mathf.Max(0,  health - amount);
            
            HealthManager.Instance.SetHealthTextDisplay(health);

            if (health < 1)
            {
                GameOverSequence();
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

        void GameOverSequence()
        {
            /*
             * When player's health drops to 0 perform the following sequence:
             * 1. Stop player movement
             * 2. Disable player follow camera
             * 3. Activate Game Over sequence in Health Manager
             */
            
            // Step 1
            _player.IsStillAlive = false;
            
            // Step 2
            playerFollowCamera.SetActive(false);
            
            // Step 3
            HealthManager.Instance.GameOverDisplay();
        }
    }
}
