using UnityEngine;

public class PIdleState : IState
{
    private PlayerController _player;
    
    public PIdleState(PlayerController player)
    {
        _player = player;
    }
    
    public void Enter()
    {
        
    }

    public void Update()
    {
        switch (_player.currentStateAnim)
        {
            case PStateAnimIndex.Attack :
                _player.ChangeState(_player.Attack);
                break;
            
            case PStateAnimIndex.Parry :
                _player.ChangeState(_player.Parry);
                break;
            
            case PStateAnimIndex.Guard :
                _player.ChangeState(_player.Guard);
                break;
            
            default :
                return;
        }
    }

    public void Exit()
    {
        
    }
}
