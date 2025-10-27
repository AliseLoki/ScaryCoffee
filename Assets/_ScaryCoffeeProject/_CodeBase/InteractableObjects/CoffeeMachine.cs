using System.Collections;
using Assets._ScaryCoffeeProject._CodeBase.Services.AudioSystem;
using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.InteractableObjects
{
    public class CoffeeMachine : InteractableObj
    {
        [SerializeField] private float _coffeePosY = 0.13f;
        [SerializeField] private float _coffeeDefauPoslY = 0.01f;
        [SerializeField] private float _maxDistanceDelta = 0.08f;
        [SerializeField] private float _poursingDuration = 2f;

        [SerializeField] private GameObject _cup;
        [SerializeField] private GameObject _coffee;
        [SerializeField] private GameObject _coffeeStream;

        [SerializeField] private AudioClip _takeCoffeeClip;

        private float _timer;
        private bool _hasCoffee;

        public bool HasCoffee => _hasCoffee;

        public override void Use()
        {
            if (!_hasCoffee)
            {
                base.Use();
                ActivatePrefabs(true);
                StartCoroutine(MakeCoffeeRoutine());
            }
            else
            {
                AudioService.Instance.AudioSource.PlayOneShot(_takeCoffeeClip);
                ActivatePrefabs(false);
                SetCoffeePosition(_coffeeDefauPoslY);
                _hasCoffee = false;
            }
        }

        private void SetCoffeePosition(float posY) => _coffee.transform.localPosition =
                new Vector3(_coffee.transform.localPosition.x, posY, _coffee.transform.localPosition.z);

        private void ActivatePrefabs(bool isActive)
        {
            _cup.SetActive(isActive);
            _coffeeStream.SetActive(isActive);
            _coffee.SetActive(isActive);
        }

        private IEnumerator MakeCoffeeRoutine()
        {
            while (_timer < _poursingDuration)
            {
                _timer += Time.deltaTime;
                FillInCoffee();
                yield return null;
            }

            _timer = 0;
            _hasCoffee = true;
            _coffeeStream.SetActive(false);
            Pause(false);
        }

        private void FillInCoffee() => _coffee.transform.localPosition = Vector3.MoveTowards(_coffee.transform.localPosition,
            new Vector3(_coffee.transform.localPosition.x, _coffeePosY, _coffee.transform.localPosition.z), _maxDistanceDelta * Time.deltaTime);
    }
}
