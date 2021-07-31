using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputMove { get; set; }
    public IdleState idleState = new IdleState();
    public WalkState walkState = new WalkState();
    private IPlayerState currentState;

    private void OnEnable()
    {
        currentState = idleState;
    }

    private void Update()
    {
        currentState = currentState.DoState(this);
    }
}
