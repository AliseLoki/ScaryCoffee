using System;
using Assets._ScaryCoffeeProject._CodeBase.Common;
using Assets._ScaryCoffeeProject._CodeBase.Services.AudioSystem;
using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.InteractableObjects
{
    public abstract class InteractableObj : MonoBehaviour, IInteractableObj
    {
        [SerializeField] protected SelectedObject SelectedObject;
        [SerializeField] protected HoldableObjectType _type;
        [SerializeField] private InteractableObjectType _interactableObjType;
        [SerializeField] private AudioClip _clip;

        public event Action<bool> PauseEnabled;

        public HoldableObjectType Type => _type;

        public InteractableObjectType InteractableObjType => _interactableObjType;

        private void OnEnable()
        {
            SelectedObject.Hide();
        }

        public void Pause(bool isPaused)
        {
            PauseEnabled?.Invoke(isPaused);
        }

        public void DisableInteraction()
        {
            SelectedObject.Hide();
        }

        public void EnableInteraction()
        {
            SelectedObject.Show();
        }

        public virtual void Use()
        {
            AudioService.Instance.AudioSource.PlayOneShot(_clip);
        }
    }
}
