using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump = false;
		public bool sprint;
		public bool attack;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		private PlayerInput playerInput;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
			playerInput.actions["Jump"].started += OnJump;
			playerInput.actions["Move"].performed += OnMove;
			playerInput.actions["Move"].canceled += OnMove;
			playerInput.actions["Look"].performed += OnLook;
			playerInput.actions["Look"].canceled += OnLook;
			playerInput.actions["Sprint"].performed += OnSprint;
			playerInput.actions["Sprint"].canceled += OnSprint;
			playerInput.actions["Shoot"].performed += OnAttack;
			playerInput.actions["Shoot"].canceled += OnAttack;
        }

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        public void OnMove(CallbackContext value)
		{
			MoveInput(value.ReadValue<Vector2>());
		}

		public void OnLook(CallbackContext value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.ReadValue<Vector2>());
			}
		}

		public void OnJump(CallbackContext value)
		{
			JumpInput(true);
		}

		public void OnSprint(CallbackContext value)
		{
			SprintInput(value.ReadValueAsButton());
		}
		public void OnAttack(CallbackContext value)
		{
			AttackInput(value.ReadValueAsButton());
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void AttackInput(bool newAttackState)
		{
			attack = newAttackState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}