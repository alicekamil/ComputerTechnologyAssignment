using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct PlayerMoveInput : IComponentData
{
    public float2 Value; // Burst compatible float
}

public struct PlayerMoveSpeed : IComponentData
{
    public float Value;
}

public struct PlayerTag : IComponentData {}

public struct FireProjectileTag : IComponentData, IEnableableComponent {}

public struct ProjectilePrefab : IComponentData
{
    public Entity Value;
}