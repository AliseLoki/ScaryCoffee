using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.InteractableObjects
{
    public class SelectedObject : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
