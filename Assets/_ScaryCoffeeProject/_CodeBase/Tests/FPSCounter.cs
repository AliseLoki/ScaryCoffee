using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.Tests
{
    public class FPSCounter : MonoBehaviour
    {
        private const string FPS = "FPS: ";
        [SerializeField] private TMP_Text _fpsText;

        private float _timer;

        private void Start()
        {
            StartCoroutine(FPSCountRoutine());
        }

        private IEnumerator FPSCountRoutine()
        {
            while (true)
            {
                _timer += (Time.unscaledDeltaTime - _timer) * 0.1f;
                float fps = 1f / _timer;
                _fpsText.text = FPS + Mathf.Ceil(fps).ToString();

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
