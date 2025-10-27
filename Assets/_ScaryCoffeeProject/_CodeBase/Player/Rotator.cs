using Assets._ScaryCoffeeProject._CodeBase.Services.InputSystem;
using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.Player
{
    public class Rotator
    {
        private readonly IInput _input;
        private readonly float _sensitivityHorizontal;
        private readonly Transform _transform;

        public Rotator(IInput input, float sensitivityHorizontal, Transform transform)
        {
            _input = input;
            _sensitivityHorizontal = sensitivityHorizontal;
            _transform = transform;
        }

        public void RotateCharacterLeftRight()
        {
            _transform.Rotate(0, _input.MouseX * _sensitivityHorizontal, 0);
        }
    }
}