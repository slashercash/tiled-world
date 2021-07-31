using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string currentStateName;
    public float speed = 5.0f;
    public Vector2Int DirectionInput { get; set; }
    public Vector3Int TargetPosition { get; set; }
    public IdleState idleState = new IdleState();
    public WalkState walkState = new WalkState();
    private IPlayerState currentState;

    private void Start()
    {
        TargetPosition = Vector3Int.RoundToInt(transform.position);
        currentState = idleState;
    }

    private void Update()
    {
        currentState = currentState.DoState(this);
        currentStateName = currentState.ToString();
    }
}
