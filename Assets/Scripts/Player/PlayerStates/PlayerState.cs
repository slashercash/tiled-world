using UnityEngine;

public abstract class PlayerState
{
    public abstract PlayerState DoState(Player player);

    public bool UpdateTargetPosition(Player player)
    {
        if (player.DirectionInput != Vector2Int.zero)
        {
            var x = player.DirectionInput.x;
            var y = 0;
            var z = x == 0 ? player.DirectionInput.y : 0;
            player.TargetPosition += new Vector3Int(x, y, z);
            return true;
        }
        return false;
    }
}