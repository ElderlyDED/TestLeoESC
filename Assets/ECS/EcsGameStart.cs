using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class EcsGameStart : MonoBehaviour
{
    EcsWorld world;
    EcsSystems system;

    void Start()
    {
        world = new EcsWorld();
        system = new EcsSystems(world);
        system.ConvertScene();
        AddInjections();
        AddOneFrames();
        AddSystem();
        system.Init();
    }

    void AddInjections()
    {

    }

    private void AddSystem()
    {
        system.Add(new PlayerJumpSendEventSystem())
            .Add(new InputPlayerSystem())
            .Add(new MovementSystem())
            .Add(new PlayerJumpSystem());
    }

    void AddOneFrames()
    {
        system.OneFrame<PlayerJumpEvent>();
    }

    void Update()
    {
        system.Run();
    }

    void OnDestroy()
    {
        if (system == null) return;

        system.Destroy();
        system = null;
        world.Destroy();
        world = null;
    }
}
