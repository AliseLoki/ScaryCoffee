using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ScaryCoffeeProject._CodeBase.Controllers
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Image _cursor;
        [SerializeField] private Image _darkView;

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
    }
}
