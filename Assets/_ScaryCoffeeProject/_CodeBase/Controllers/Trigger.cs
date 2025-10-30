using System;
using Assets._ScaryCoffeeProject._CodeBase.Player;
using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.Controllers
{
    public class Trigger : MonoBehaviour
    {
        public event Action Chasing;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerCore playerCore))
            {
                Chasing?.Invoke();
            }
        }
    }
}
