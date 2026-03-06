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
        NoteManager.Instance.noteJudge.ExecuteJudgment(_player.currentStateAnim);
    }

    public void Update()
    {
        // 홀드시 첫 판정 유지
        _stateInfo = _player.animator.GetCurrentAnimatorStateInfo(0);
        
        if (!_player.onGuard)
            _player.ChangeState(_player.Idle);
    }

    public void Exit()
    {
        // 땠을 때 판정
        NoteManager.Instance.noteJudge.ExecuteJudgment(_player.currentStateAnim);
        // 가드 판정 중지
    }
}
