using System;
using System.Collections;
using System.Collections.Generic;
using Assets._ScaryCoffeeProject._CodeBase.Services.AudioSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ScaryCoffeeProject._CodeBase.LighSystem
{
    public class LightController : MonoBehaviour
    {
        [SerializeField] private List<Light> _lights;
        [SerializeField] private Image _image;

        [SerializeField] private float _duration = 0.03f;
        [SerializeField] private float _defaultLightIntensity = 10f;
        [SerializeField] private float _lightBlinkingIntensity = 0.1f;
        [SerializeField] private float _darkDuration = 2f;

        [SerializeField] private AudioClip _lightBlinking;
        [SerializeField] private AudioClip _manScreaming;

        private float _timer = 0;

        public event Action<bool> DarkEnabled;

        public void Blink()
        {
            StartCoroutine(BlinkRoutine());
        }

        private IEnumerator BlinkRoutine()
        {
            _timer = 0;

            AudioService.Instance.AudioSource.PlayOneShot(_lightBlinking);

            while (_timer <= _duration)
            {
                _timer += Time.deltaTime;
                SetLightIntensity(0);
                yield return new WaitForSeconds(_lightBlinkingIntensity);
                SetLightIntensity(_defaultLightIntensity);
                yield return new WaitForSeconds(_lightBlinkingIntensity);
            }

            DarkEnabled?.Invoke(true);
            AudioService.Instance.AudioSource.PlayOneShot(_manScreaming);

            yield return new WaitForSeconds(_darkDuration);

            DarkEnabled?.Invoke(false);
        }

        private void SetLightIntensity(float intensity)
        {
            foreach (Light light in _lights)
                light.intensity = intensity;
        }
    }
}
