using Assets._ScaryCoffeeProject._CodeBase.Common;
using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.HolldableObjects
{
    public class HoldableObject : MonoBehaviour
    {
        [SerializeField] private HoldableObjectType _type;

        public HoldableObjectType HoldableType => _type;
    }
}
