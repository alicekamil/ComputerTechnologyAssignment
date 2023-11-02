using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

[UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
    public partial class GetPlayerInputSystem : SystemBase
    {
        private Move _movementActions;
        private Entity _playerEntity;

        protected override void OnCreate()
        {
            RequireForUpdate<PlayerTag>();
            RequireForUpdate<PlayerMoveInput>();

            _movementActions = new Move();
        }
         protected override void OnStartRunning()
         {
             _movementActions.Enable();
             _movementActions.Movement.PlayerShoot.performed += OnPlayerShoot;
             _playerEntity = SystemAPI.GetSingletonEntity<PlayerTag>();
         }
        protected override void OnUpdate()
        {
            var curMoveInput = _movementActions.Movement.PlayerMovement.ReadValue<Vector2>();
            
            SystemAPI.SetSingleton(new PlayerMoveInput { Value = curMoveInput}); // Creating new instance 
        }
        
        protected override void OnStopRunning()
        {
            _movementActions.Movement.PlayerShoot.performed -= OnPlayerShoot;
            _movementActions.Disable();
            _playerEntity = Entity.Null;
        }

        private void OnPlayerShoot(InputAction.CallbackContext obj)
        {
            if (!SystemAPI.Exists(_playerEntity)) return;
            
            SystemAPI.SetComponentEnabled<FireProjectileTag>(_playerEntity, true);
        }
    }
