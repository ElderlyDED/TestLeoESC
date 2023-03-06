using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

sealed class MovementSystem : IEcsRunSystem
{
    readonly EcsWorld _world = null;
    readonly EcsFilter<ModelComponent, MovableComponent, DirectionComponent> _movableFilter = null;
    public void Run()
    {
        foreach (var i in _movableFilter)
        {
            ref var modelComponent = ref _movableFilter.Get1(i);
            ref var movableComponent = ref _movableFilter.Get2(i);
            ref var directionComponent = ref _movableFilter.Get3(i);
            ref var direction = ref directionComponent.direction;
            ref var transform = ref modelComponent.modelTransform;
            ref var characterController = ref movableComponent.characterController;
            ref var speed = ref movableComponent.speed;
            var rawDirection = ((transform.right * direction.x) + (transform.forward * direction.z));
            ref var velocity = ref movableComponent.velocity;
            velocity.y += movableComponent.gravity * Time.deltaTime;
            characterController.Move(rawDirection * speed);
            characterController.Move(velocity * Time.deltaTime);
        }
    }
}

