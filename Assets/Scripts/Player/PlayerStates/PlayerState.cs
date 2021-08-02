using UnityEngine;

public abstract class PlayerState
{
    public abstract PlayerState DoState(Player player);

    public bool UpdateTargetPosition(Player player)
    {
        if (player.DirectionInput == Vector2Int.zero)
            return false;

        var x = player.DirectionInput.x;
        var y = 0;
        var z = x == 0 ? player.DirectionInput.y : 0;
        var newTargetPosition = player.TargetPosition + new Vector3Int(x, y, z);
        var colliderOnNewTargetPosition = Physics.Linecast(player.TargetPosition, newTargetPosition);

        if (!colliderOnNewTargetPosition)
        {
            player.TargetPosition = newTargetPosition;
            return true;
        }
        return false;
    }
}