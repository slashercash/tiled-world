using UnityEngine;

public class PlayerState_Walk : PlayerState
{
    public override PlayerState DoState(Player player)
    {
        var distance = Vector3.Distance(player.transform.position, player.TargetPosition);
        var maxDistance = Time.deltaTime * player.speed;

        if (distance <= maxDistance)
        {
            UpdateTargetPosition(player);
        }

        player.transform.position = Vector3.MoveTowards(player.transform.position, player.TargetPosition, maxDistance);

        return player.transform.position == player.TargetPosition ? (PlayerState)player.idleState : player.walkState;
    }
}