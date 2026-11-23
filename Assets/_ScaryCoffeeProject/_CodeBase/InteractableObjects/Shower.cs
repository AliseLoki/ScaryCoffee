using System.Collections;
using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.InteractableObjects
{

    public class Shower : InteractableObj
    {
        [SerializeField] private GameObject _effects;

        private float _timer;
        private float _showerTime = 5f;

        public override void Use()
        {
            Pause(true);
            _effects.SetActive(true);
            base.Use();
            StartCoroutine(ShowerRoutine());
        }

        private IEnumerator ShowerRoutine()
        {
            while (_timer < _showerTime) 
            {
                _timer += Time.deltaTime;
                yield return null;
            }

            _timer = 0;
            _effects.SetActive(false);
            Pause(false);
        }
    }
}