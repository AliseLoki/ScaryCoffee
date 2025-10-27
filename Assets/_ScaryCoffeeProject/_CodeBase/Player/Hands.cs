using System.Collections.Generic;
using Assets._ScaryCoffeeProject._CodeBase.Common;
using Assets._ScaryCoffeeProject._CodeBase.HolldableObjects;
using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.Player
{
    public class Hands : MonoBehaviour
    {
        [SerializeField] private List<HoldableObject> _itemsInHands;

        public void TakeItemInHands(HoldableObjectType type)
        {
            foreach (var item in _itemsInHands)
            {
                if (item.HoldableType == type)
                    item.gameObject.SetActive(true);
                else
                    item.gameObject.SetActive(false);
            }
        }

        public bool CheckIfHasRequiredItem(HoldableObjectType type)
        {
            foreach (var item in _itemsInHands)
            {
                if (item.HoldableType == type && item.gameObject.activeSelf)
                    return true;
            }

            return false;
        }

        public void ClearHands()
        {
            foreach (HoldableObject item in _itemsInHands)
                item.gameObject.SetActive(false);
        }
    }
}
