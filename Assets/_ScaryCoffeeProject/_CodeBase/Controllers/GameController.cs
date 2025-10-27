using System;
using Assets._ScaryCoffeeProject._CodeBase.Controllers;
using Assets._ScaryCoffeeProject._CodeBase.InteractableObjects;
using Assets._ScaryCoffeeProject._CodeBase.LighSystem;
using Assets._ScaryCoffeeProject._CodeBase.Player;
using Assets._ScaryCoffeeProject._CodeBase.Services.AudioSystem;
using Assets._ScaryCoffeeProject._CodeBase.Services.InputSystem;
using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.GameStateMachine
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private AudioService _audioService;
        [SerializeField] private LightController _lightController;
        [SerializeField] private InteractableObjectsSystem _interactableObjectsSystem;
        [SerializeField] private PlayerCore _player;
        [SerializeField] private UIController _uiController;

        [SerializeField] private GameObject _npc;
        [SerializeField] private GameObject _blood;

        private bool _isPaused;

        private void Awake()
        {
            Init();
            SubscribeToDependencies();
        }

        private void Start()
        {
            StartGame();
        }

        private void Update()
        {
            if (_isPaused) return;
            _player.UpdatePlayer();
        }

        private void OnDisable()
        {
            UnsubscribeFromDependencies();
        }

        private void UnsubscribeFromDependencies()
        {
            _player.InteractionEnabled -= OnInteractionEnabled;
            _player.PauseEnabled -= OnPauseEnabled;
            _player.ScaryModeEnabled -= OnScaryModeEnabled;

            _interactableObjectsSystem.PauseEnabled -= OnPauseEnabled;

            _lightController.DarkEnabled -= OnDarkEnabled;
        }

        private void SubscribeToDependencies()
        {
            _player.InteractionEnabled += OnInteractionEnabled;
            _player.PauseEnabled += OnPauseEnabled;
            _player.ScaryModeEnabled += OnScaryModeEnabled;

            _interactableObjectsSystem.PauseEnabled += OnPauseEnabled;

            _lightController.DarkEnabled += OnDarkEnabled;
        }

        private void OnDarkEnabled(bool isEnable)
        {
            _uiController.TurnOffTheLight(isEnable);

            OnPauseEnabled(isEnable);

            if (isEnable == false)
            {
                _npc.SetActive(false);
                _blood.SetActive(true);
                // убрать нпс
                // нарисовать след крови
                // 
            }
        }

        private void OnScaryModeEnabled(bool isEnable)
        {
            _lightController.Blink();
        }

        private void OnPauseEnabled(bool isEnable)
        {
            _isPaused = isEnable;
        }

        private void OnInteractionEnabled(bool isEnable)
        {
            _uiController.ChangeCursorColor(isEnable);
        }

        private void Init()
        {
            _player.Init(new DesktopInput());
            _interactableObjectsSystem.Init();
        }

        private void StartGame()
        {

        }
    }
}
