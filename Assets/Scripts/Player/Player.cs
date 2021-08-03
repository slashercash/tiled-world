using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string currentStateName;
    public float speed = 3.0f;
    public float pivotToBottom = 0.5f;
    public float maxInclineGradient = 0.55f;
    public float maxDeclineGradient = 1.05f;
    public Vector2Int DirectionInput { get; set; }
    public Vector3 TargetPosition { get; set; }
    public PlayerState_Idle idleState = new PlayerState_Idle();
    public PlayerState_Walk walkState = new PlayerState_Walk();
    private PlayerState currentState;

    private void Start()
    {
        TargetPosition = transform.position;
        currentState = idleState;
    }

    private void Update()
    {
        currentState = currentState.DoState(this);
        currentStateName = currentState.ToString();
    }
}
