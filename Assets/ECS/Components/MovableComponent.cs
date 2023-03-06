using System;
using UnityEngine;
[Serializable]
public struct MovableComponent
{
    public CharacterController characterController;
    public float speed;
    public Vector3 velocity;
    public float gravity;
}
