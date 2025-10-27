using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.InteractableObjects
{
    public class Tray : InteractableObj
    {
        [SerializeField] private GameObject _coffee;

        public override void Use()
        {
            base.Use();
            _coffee.SetActive(true);
        }
    }
}
