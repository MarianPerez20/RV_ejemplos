using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; // Necesario si usas TextMeshPro

public class GameTimer : MonoBehaviour
{
    public float countdownTime = 300f; // Tiempo en segundos (5 minutos)
    public TextMeshProUGUI timerText; // Referencia al texto del temporizador
    public GameObject gameOverUI; // UI que muestra el final del juego

    private bool isGameOver = false;

    void Start()
    {
        // Opcional: Oculta la UI de fin de juego al principio
        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }

    void Update()
    {
        if (isGameOver) return;

        countdownTime -= Time.deltaTime; // Reduce el tiempo restante
        if (countdownTime <= 0)
        {
            EndGame(); // Llamar a la función para finalizar el juego
        }

        UpdateTimerUI(); // Actualiza el texto del temporizador
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(countdownTime / 60);
            int seconds = Mathf.FloorToInt(countdownTime % 60);
            timerText.text = $"{minutes:00}:{seconds:00}"; // Formato mm:ss
        }
    }

    void EndGame()
    {
        isGameOver = true;
        countdownTime = 0;

        if (gameOverUI != null)
            gameOverUI.SetActive(true); // Muestra la UI de fin de juego

        // Detén el tiempo del juego si es necesario
        Time.timeScale = 0;

        Debug.Log("Fin del juego");
    }
}
