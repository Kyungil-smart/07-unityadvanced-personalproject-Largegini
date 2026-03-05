using UnityEngine;

public class PGuardState : IState
{
    private PlayerController _player;
    private AnimatorStateInfo _stateInfo;
    
    public PGuardState(PlayerController player)
    {
        _player = player;
    }
    
    public void Enter()
    {
        
    }

    public void Update()
    {
        _stateInfo = _player.animator.GetCurrentAnimatorStateInfo(0);
        
        if (!_player.onGuard)
            _player.ChangeState(_player.Idle);
    }

    public void Exit()
    {
        // 가드 판정 중지
    }
}
