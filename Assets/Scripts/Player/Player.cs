using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string currentStateName;
    public float speed = 3.0f;
    public float pivotToTop = 0.625f;
    public float pivotToBottom = 0.5f;
    public float maxStep = 0.5f;
    public float verticalAccuracy = 0.25f;
    public Vector2Int DirectionInput { get; set; }
    public Vector3 TargetPosition { get; set; }
    public float Buffer { get; set; }
    public float EvenGroundDistance { get; set; }
    public float BufferMaxstep { get; set; }
    public float MaxGroundDistance { get; set; }
    public float MinGroundDistance { get; set; }
    public float PartialVerticalAccuracy { get; set; }
    public PlayerState_Idle idleState = new PlayerState_Idle();
    public PlayerState_Walk walkState = new PlayerState_Walk();
    private PlayerState currentState;

    private void Start()
    {
        TargetPosition = transform.position;
        Buffer = verticalAccuracy / 2;
        EvenGroundDistance = pivotToTop + pivotToBottom;
        BufferMaxstep = maxStep + Buffer;
        MaxGroundDistance = EvenGroundDistance + BufferMaxstep;
        MinGroundDistance = EvenGroundDistance - BufferMaxstep;
        PartialVerticalAccuracy = 1 / Buffer;
        currentState = idleState;
    }

    private void Update()
    {
        currentState = currentState.DoState(this);
        currentStateName = currentState.ToString();
    }
}
