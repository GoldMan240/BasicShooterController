using Infrastructure;
using Infrastructure.Services;
using UnityEngine;

namespace Services
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }
        bool IsJumpPressed { get; }
        bool IsFirePressed { get; }
    }
}