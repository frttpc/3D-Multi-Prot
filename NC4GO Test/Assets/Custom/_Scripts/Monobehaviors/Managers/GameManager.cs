using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frttpc
{
    public class GameManager : MonoBehaviour
    {
        public enum State
        {
            WaitingToStart,
            Countdown,
            Playing,
            Paused,
            GameOver
        }

        private State gameState;

        private float waitingTimer = 1f;
        private float countdownTimer = 3f;
        private bool isPaused = false;
        private bool isLocalPlayerReady = false;

        public event Action OnGamePaused;
        public event Action OnGameResumed;
        public event Action OnCountdownStart;
        public event Action OnGameStart;

        public static GameManager Instance;

        private void Awake()
        {
            Instance = this;

            gameState = State.WaitingToStart;
        }

        private void Start()
        {
            PauseGame();
        }

        private void Update()
        {
            switch (gameState)
            {
                case State.WaitingToStart:
                    waitingTimer -= Time.unscaledDeltaTime;
                    if (waitingTimer < 0)
                        gameState = State.Countdown;
                    break;
                case State.Countdown:
                    countdownTimer -= Time.unscaledDeltaTime;
                    if (countdownTimer < 1)
                        gameState = State.Playing;
                    OnCountdownStart?.Invoke();
                    break;
                case State.Playing:
                    ResumeGame();
                    OnGameStart?.Invoke();
                    break;
                case State.Paused:
                    break;
                case State.GameOver:
                    break;
            }
        }

        public void PauseGame()
        {
            gameState = State.Paused;
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            gameState = State.Playing;
            Time.timeScale = 1;
        }

        public float GetCountdownTimer() => countdownTimer;
    }
}