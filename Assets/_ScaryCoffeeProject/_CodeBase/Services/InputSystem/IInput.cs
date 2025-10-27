using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.Services.InputSystem
{
    public interface IInput
    {
        Vector3 Axis { get; }

        public float MouseX { get; }
        public float MouseY { get; }
    }
}