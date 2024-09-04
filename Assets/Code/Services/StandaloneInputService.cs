using UnityEngine;

namespace Services
{
    public class StandaloneInputService : IInputService
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";
        private const string JumpButtonName = "Jump";
        private const string FireButtonName = "Fire1";

        public Vector2 Axis => 
            new(Input.GetAxisRaw(HorizontalAxisName), Input.GetAxisRaw(VerticalAxisName));
        
        public bool IsJumpPressed =>
            Input.GetButtonDown(JumpButtonName);
        
        public bool IsFirePressed =>
            Input.GetButtonDown(FireButtonName);
    }
}