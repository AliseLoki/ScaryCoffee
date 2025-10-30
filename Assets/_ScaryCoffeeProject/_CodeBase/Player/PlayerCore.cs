using System;
using System.Collections;
using Assets._ScaryCoffeeProject._CodeBase.Services.InputSystem;
using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.Player
{
    public class PlayerCore : MonoBehaviour
    {
        //configs
        [SerializeField] private Hands _hands;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private CharacterController _controller;
        [SerializeField] private Camera _camera;

        private Mover _mover;
        private Rotator _rotator;
        private HeadCamera _headCamera;
        private Interactor _interactor;

        private float _timer;
        private float _timeForFall = 1;

        public event Action<bool> InteractionEnabled;
        public event Action<bool> PauseEnabled;
        public event Action<bool> ScaryModeEnabled;
        public event Action CompletelyDied;

        private void OnDisable()
        {
            UnsubscribeFromDependencies();
        }

        public void Init(IInput input)
        {
            _mover = new Mover(input, 6, _controller, this.transform);
            _rotator = new Rotator(input, 6, this.transform);
            _headCamera = new HeadCamera(input, 6, -45, 45, _camera.transform);
            _interactor = new Interactor(_camera.transform, _layerMask, 1, _hands);

            SubscribeToDependencies();
        }

        public void UpdatePlayer()
        {
            _mover.MoveCharacter();
            _rotator.RotateCharacterLeftRight();
            _headCamera.RotateCameraUpDown();
            _interactor.SendRaycast();
            _interactor.CheckInteraction();
        }

        private void SubscribeToDependencies()
        {
            _interactor.InteractionEnabled += OnInteractionEnabled;
            _interactor.PauseEnabled += OnPauseEnabled;
            _interactor.ScaryModeEnabled += OnScaryModeEnabled;
        }

        private void UnsubscribeFromDependencies()
        {
            _interactor.InteractionEnabled -= OnInteractionEnabled;
            _interactor.PauseEnabled -= OnPauseEnabled;
            _interactor.ScaryModeEnabled -= OnScaryModeEnabled;
        }

        private void OnScaryModeEnabled(bool isEnable)
        {
            ScaryModeEnabled?.Invoke(isEnable);
        }

        private void OnPauseEnabled(bool isEnable)
        {
            PauseEnabled?.Invoke(isEnable);
        }

        private void OnInteractionEnabled(bool isEnable)
        {
            InteractionEnabled?.Invoke(isEnable);
        }

        public void Die()
        {
            StartCoroutine(FallingRoutine());
        }

        private IEnumerator FallingRoutine()
        {
            Quaternion _targetRotation = Quaternion.Euler(-90, 0, 0);

            while (_timer < _timeForFall)
            {
                _timer += Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, 10f * Time.deltaTime);
                yield return null;
            }

            CompletelyDied?.Invoke();
        }
    }
}