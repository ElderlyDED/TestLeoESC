using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct GroundCheckSphereComponent
{
    public LayerMask groudMask;
    public Transform groundCheckSphere;
    public float groundDistance;
    public bool isGrounded;
}
