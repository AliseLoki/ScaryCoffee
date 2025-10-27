using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.Services.InputSystem
{
    public class DesktopInput : IInput
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string XMouse = "Mouse X";
        private const string YMouse = "Mouse Y";

        public Vector3 Axis => new(Input.GetAxis(Horizontal),0, Input.GetAxis(Vertical));

        public float MouseX => Input.GetAxis(XMouse);

        public float MouseY => Input.GetAxis(YMouse);
    }
}
