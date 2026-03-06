using UnityEngine;

public class PParryState : IState
{
    private PlayerController _player;
    private AnimatorStateInfo _stateInfo;

    public PParryState(PlayerController player)
    {
        _player = player;
    }
    
    public void Enter()
    {
        NoteManager.Instance.noteJudge.ExecuteJudgment(_player.currentStateAnim);
    }

    public void Update()
    {
        _stateInfo = _player.animator.GetCurrentAnimatorStateInfo(0);

        if (_player.inputSystem.Player.Parry.triggered)
        {
            _player.animator.Play("Parry", 0, 0);
            NoteManager.Instance.noteJudge.ExecuteJudgment(_player.currentStateAnim);
            return;
        }

        if (_player.inputSystem.Player.Attack.triggered)
        {
            _player.ChangeState(_player.Attack);
            return;
        }

        if (_player.inputSystem.Player.Guard.triggered)
        {
            _player.ChangeState(_player.Guard);
            return;
        }
        
        if (_stateInfo.IsName("Parry") && _stateInfo.normalizedTime >= 1f)
           _player.ChangeState(_player.Idle);
    }

    public void Exit()
    {
        // 패리 노트판정 중지
    }
}
