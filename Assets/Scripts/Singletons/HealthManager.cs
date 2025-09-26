using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Singletons
{
    public class HealthManager : MonoBehaviour
    {
        public static HealthManager Instance { get; private set; }
        
        [SerializeField] TextMeshProUGUI healthText;
        [SerializeField] TextMeshProUGUI gameOverText;
        [SerializeField] Image blackScreen;
        [SerializeField] float fadeDuration = 1f;

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

        public void GameOverDisplay()
        {
            StartCoroutine(FadeToBlack());
        }

        IEnumerator FadeToBlack()
        {
            float elapsed = 0f;
            Color blackScreenColor = blackScreen.color;
            Color gameOverColor = gameOverText.color;

            while (elapsed < fadeDuration)
            {
                elapsed += Time.deltaTime;
                
                blackScreenColor.a = Mathf.Clamp01(elapsed / fadeDuration);
                gameOverColor.a = Mathf.Clamp01(elapsed / fadeDuration);
                
                blackScreen.color = blackScreenColor;
                gameOverText.color = gameOverColor;
                
                yield return null;
            }

            blackScreenColor.a = 1f;
            gameOverColor.a = 1f;
            
            blackScreen.color = blackScreenColor;
            gameOverText.color = gameOverColor;
        }
    }
}
