using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

sealed class InputPlayerSystem : IEcsRunSystem
{
    readonly EcsFilter<PlayerTag, DirectionComponent> _directionFilter = null;
    float _moveX;
    float _moveZ;
    public void Run()
    {
        SetDirection();
        foreach (var i in _directionFilter)
        {
            ref var directionComponent = ref _directionFilter.Get2(i);
            ref var direction = ref directionComponent.direction;
            direction.x = _moveX;
            direction.z = _moveZ;   
        }
    }

    void SetDirection()
    {
        _moveX = Input.GetAxis("Horizontal");
        _moveZ = Input.GetAxis("Vertical");
    }
}
