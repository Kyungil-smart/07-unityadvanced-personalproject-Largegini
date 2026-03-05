using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   public Animator animator;
   
   private StateMachine _stateMachine;
   
   public PIdleState Idle { get; private set; }
   public PAttackState Attack { get; private set; }
   public PParryState Parry{get; private set;}
   public PGuardState Guard { get; private set; }
   
   public PlayerInputSystem inputSystem;

   public PStateAnimIndex currentStateAnim {get; private set;}

   public bool onGuard;
   
   private void Awake()
   {
      Idle = new PIdleState(this);
      Attack = new PAttackState(this);
      Parry = new PParryState(this);
      Guard = new PGuardState(this);
      
      inputSystem = new PlayerInputSystem();
      _stateMachine = new StateMachine();
      
      onGuard = false;
   }

   private void Start()
   {
      animator =  GetComponent<Animator>();
      
      _stateMachine.ChangeState(Idle);
      currentStateAnim = PStateAnimIndex.Idle;
   }

   private void OnEnable()
   {
      inputSystem.Enable();

      inputSystem.Player.Attack.performed += OnAttack;
      inputSystem.Player.Parry.performed += OnParry;
      
      inputSystem.Player.Guard.performed += OnGuard;
      inputSystem.Player.Guard.performed += OnGuard;
      inputSystem.Player.Guard.canceled += OnGuard;
   }

   private void Update()
   {
      _stateMachine.Update();
      animator.SetInteger("AnimState", (int)currentStateAnim);
   }

   private void OnDisable()
   {
      inputSystem.Player.Attack.performed -= OnAttack;
      inputSystem.Player.Parry.performed -= OnParry;
      
      inputSystem.Player.Guard.performed -= OnGuard;
      inputSystem.Player.Guard.performed -= OnGuard;
      inputSystem.Player.Guard.canceled -= OnGuard;
      
      inputSystem.Disable();
   }

   public void ChangeState(IState state)
   {
      _stateMachine.ChangeState(state);
      
      if (state is PIdleState)
      {
         currentStateAnim = PStateAnimIndex.Idle;
      }
   }

   private void OnAttack(InputAction.CallbackContext ctx)
   {
      if (ctx.performed) { currentStateAnim = PStateAnimIndex.Attack; }
   }

   private void OnParry(InputAction.CallbackContext ctx)
   {
      if (ctx.performed) { currentStateAnim = PStateAnimIndex.Parry; }
   }

   private void OnGuard(InputAction.CallbackContext ctx)
   {
      onGuard = !onGuard;
      
      currentStateAnim = PStateAnimIndex.Guard;
   }
}
