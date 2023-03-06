using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class GroundCheckSystem : IEcsRunSystem
{
    readonly EcsFilter<PlayerTag, GroundCheckSphereComponent> _groundFilter = null;
    public void Run()
    {
        foreach(var i in _groundFilter)
        {
            ref var groundCheck = ref _groundFilter.Get2(i);
            groundCheck.isGrounded = Physics.CheckSphere(
                groundCheck.groundCheckSphere.position, 
                groundCheck.groundDistance, groundCheck.groudMask);
        }
    }
}
