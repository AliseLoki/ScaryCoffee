using System;
using Assets._ScaryCoffeeProject._CodeBase.Common;
using Assets._ScaryCoffeeProject._CodeBase.InteractableObjects;
using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.Player
{
    public class Interactor
    {
        private readonly float _distance;
        private readonly Hands _hands;
        private readonly Transform _transform;
        private readonly LayerMask _layerMask;

        private InteractableObj _currentInteractable;

        public event Action<bool> InteractionEnabled;
        public event Action<bool> PauseEnabled;
        public event Action<bool> ScaryModeEnabled;

        public Interactor(Transform transform, LayerMask layerMask, float distance, Hands hands)
        {
            _transform = transform;
            _layerMask = layerMask;
            _distance = distance;
            _hands = hands;
        }

        public void SendRaycast()
        {
            if (Physics.Raycast(_transform.position, _transform.forward, out RaycastHit hit, _distance, _layerMask))
            {
                EnableInteraction(hit);
                InteractionEnabled?.Invoke(true);
            }
            else
            {
                DisableInteraction();
                InteractionEnabled?.Invoke(false);
            }
        }

        public void CheckInteraction()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_currentInteractable != null)
                    ReactToInput(_currentInteractable, _currentInteractable.Type);
            }
        }

        private void EnableInteraction(RaycastHit hit)
        {
            if (hit.collider.TryGetComponent(out InteractableObj interactable))
            {
                _currentInteractable = interactable;
                interactable.EnableInteraction();
            }
        }

        private void DisableInteraction()
        {
            if (_currentInteractable != null) _currentInteractable.DisableInteraction();
            _currentInteractable = null;
        }

        private void OnDrawGizmos()
        {
            Debug.DrawRay(_transform.position, _transform.forward, Color.green);
        }

        private void ReactToInput(InteractableObj interactableObj, HoldableObjectType type)
        {
            switch (interactableObj.InteractableObjType)
            {
                case InteractableObjectType.Conteiner:

                    UseContainer(interactableObj, type);
                    break;

                case InteractableObjectType.CoffeeMachine:

                    UseCoffeeMachine(interactableObj);
                    break;

                case InteractableObjectType.Tray:

                    UseTray(interactableObj);                  
                    break;
            }
        }

        private void UseTray(InteractableObj interactableObj)
        {
            if (_hands.CheckIfHasRequiredItem(HoldableObjectType.Coffee))
            {
                ScaryModeEnabled?.Invoke(true);
                GiveObject(interactableObj);
            }
        }

        private void UseCoffeeMachine(InteractableObj interactableObj)
        {
            CoffeeMachine coffeeMachine = interactableObj as CoffeeMachine;

            if (coffeeMachine.HasCoffee)
                TakeCoffee(coffeeMachine);
            else
                MakeCoffee(interactableObj);
        }

        private void MakeCoffee(InteractableObj interactableObj)
        {
            if (_hands.CheckIfHasRequiredItem(HoldableObjectType.Cup))
                GiveObject(interactableObj);
        }

        private void GiveObject(InteractableObj interactableObj)
        {
            PauseEnabled?.Invoke(true);
            interactableObj.Use();
            _hands.ClearHands();
        }

        private void TakeCoffee(CoffeeMachine coffeeMachine)
        {
            if (_hands.CheckIfHasRequiredItem(HoldableObjectType.Plate))
            {
                coffeeMachine.Use();
                _hands.TakeItemInHands(HoldableObjectType.Coffee);
            }
        }

        private void UseContainer(InteractableObj interactableObj, HoldableObjectType type)
        {
            _hands.TakeItemInHands(type);
            interactableObj.Use();
        }
    }
}
