using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

sealed class InputPlayerSystem : IEcsRunSystem
{
    readonly EcsFilter<PlayerTag, DirectionComponent, PlayerParticleComponent> _directionFilter = null;
    float _moveX;
    float _moveZ;
    bool _onParticleSystem;
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
        if (Input.GetKey(KeyCode.P))
        {
            foreach (var i in _directionFilter)
            {
                StartParticleSystem(_directionFilter.Get3(i).particleSystem);
            }
        }
        
    }

    void SetDirection()
    {
        _moveX = Input.GetAxis("Horizontal");
        _moveZ = Input.GetAxis("Vertical");
    }

    void StartParticleSystem(ParticleSystem playerParticleSystem)
    {
        if (_onParticleSystem == false)
        {
            _onParticleSystem = true;
            playerParticleSystem.Play(); 
        }
        else
        {
            _onParticleSystem = false;
            playerParticleSystem.Stop();
        }
    }
}
