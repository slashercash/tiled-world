using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string currentStateName;
    public float speed = 3.0f;
    public Vector2Int DirectionInput { get; set; }
    public Vector3Int TargetPosition { get; set; }
    public PlayerState_Idle idleState = new PlayerState_Idle();
    public PlayerState_Walk walkState = new PlayerState_Walk();
    private PlayerState currentState;

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
