using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.InteractableObjects
{
    public class InteractableObjectsSystem : MonoBehaviour
    {
        [SerializeField] private List<InteractableObj> _interactables;

        public event Action<bool> PauseEnabled;

        public void Init()
        {
            foreach (var item in _interactables)
            {
                item.PauseEnabled += OnPauseEnabled;
            }
        }

        private void OnDisable()
        {
            foreach (var item in _interactables)
            {
                item.PauseEnabled -= OnPauseEnabled;
            }
        }

        private void OnPauseEnabled(bool isEnable)
        {
            PauseEnabled?.Invoke(isEnable);
        }
    }
}
