using Assets._ScaryCoffeeProject._CodeBase.Services.InputSystem;
using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.Player
{
    public class HeadCamera
    {
        private readonly IInput _input;
        private readonly float _sensitivityVert;
        private readonly float _minVert;
        private readonly float _maxVert;
        private readonly Transform _transform;

        private float _rotationVert = 0;

        public HeadCamera(IInput input, float sensitivityVert, float minVert, float maxVert, Transform transform)
        {
            this._input = input;
            this._sensitivityVert = sensitivityVert;
            this._minVert = minVert;
            this._maxVert = maxVert;
            this._transform = transform;
            Cursor.visible = false;
        }

        public void RotateCameraUpDown()
        {
            _rotationVert -= _input.MouseY * _sensitivityVert;
            _rotationVert = Mathf.Clamp(_rotationVert, _minVert, _maxVert);

            _transform.localEulerAngles = new Vector3(_rotationVert, _transform.localEulerAngles.y, 0);
        }
    }
}