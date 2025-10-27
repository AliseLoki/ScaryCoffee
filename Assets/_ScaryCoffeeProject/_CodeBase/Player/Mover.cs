using Assets._ScaryCoffeeProject._CodeBase.Services.InputSystem;
using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.Player
{
    public class Mover
    {
        private readonly IInput _input;
        private readonly float _moveSpeed;
        private readonly CharacterController _characterController;
        private readonly Transform _transform;

        public Mover(IInput input, float moveSpeed, CharacterController characterController, Transform transform)
        {
            _input = input;
            _moveSpeed = moveSpeed;
            _characterController = characterController;
            _transform = transform;
        }

        public void MoveCharacter()
        {
            Vector3 movement = _input.Axis * _moveSpeed;
            movement = Vector3.ClampMagnitude(movement, _moveSpeed);

            movement.y = Physics.gravity.y;
            movement *= Time.deltaTime;

            movement = _transform.TransformDirection(movement);
            _characterController.Move(movement);
        }
    }
}
