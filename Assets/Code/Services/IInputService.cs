using UnityEngine;

namespace Code.Services
{
    public interface IInputService
    {
        Vector2 Axis { get; }
        bool IsJumpPressed { get; }
        bool IsFirePressed { get; }
    }
}