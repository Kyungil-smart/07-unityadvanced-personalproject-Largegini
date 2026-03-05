using UnityEngine;

public class PAttackState : IState
{
    private PlayerController _player;
    private AnimatorStateInfo _stateInfo;

    public PAttackState(PlayerController player)
    {
        _player = player;
    }

    public void Enter()
    {
        
    }

    public void Update()
    {
        _stateInfo = _player.animator.GetCurrentAnimatorStateInfo(0);
        // 재입력시 처음부터 재생
        // 키 재입력시 애니메이션 초기화
        if (_player.inputSystem.Player.Attack.triggered)
        {
            _player.animator.Play("Attack", 0, 0f);
            return;
        }
        // 다른 키 입력 시 전환
        if (_player.inputSystem.Player.Parry.triggered)
        {
            _player.ChangeState(_player.Parry);
            return;
        }

        if (_player.inputSystem.Player.Guard.triggered)
        {
            _player.ChangeState(_player.Guard);
            return;
        }

        // 재입력이 없으면 애니메이션 끝까지 재생 후 idle로 복귀
        if (_stateInfo.IsName("Attack") && _stateInfo.normalizedTime >= 1f)
        {
            _player.ChangeState(_player.Idle);
        }
    }

    public void Exit()
    {
        // 어택 노트판정 중지
    }
}