using UnityEngine;

public class IdleState : IPlayerState
{
    public IPlayerState DoState(Player player)
    {
        if (player.DirectionInput.x != 0)
        {
            player.TargetPosition += new Vector3Int(player.DirectionInput.x, 0, 0);
            return player.walkState;
        }
        else if (player.DirectionInput.y != 0)
        {
            player.TargetPosition += new Vector3Int(0, 0, player.DirectionInput.y);
            return player.walkState;
        }

        return player.idleState;
    }
}
