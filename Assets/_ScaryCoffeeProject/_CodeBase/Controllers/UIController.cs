using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ScaryCoffeeProject._CodeBase.Controllers
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Image _cursor;
        [SerializeField] private Image _darkView;
        [SerializeField] private CanvasGroup _blood;

        private float _timer;
        private float _fadeDuration = 2;
        private Coroutine _fadeRoutine;

        public void ChangeCursorColor(bool isEnable)
        {
            if (isEnable)
                _cursor.color = Color.red;
            else
                _cursor.color = Color.green;
        }

        public void TurnOffTheLight(bool isEnable)
        {
            _darkView.gameObject.SetActive(isEnable);
        }

        public void ShowDeathScreen()
        {
            if (_fadeRoutine == null)
                _fadeRoutine = StartCoroutine(FadeRoutine());
        }

        private IEnumerator FadeRoutine()
        {
            _blood.gameObject.SetActive(true);

            while (_timer < _fadeDuration)
            {
                _timer += Time.deltaTime;
                _blood.alpha = Mathf.Lerp(_blood.alpha, 1, 10 * Time.deltaTime);
                yield return null;
            }

            _timer = 0;
        }
    }
}
