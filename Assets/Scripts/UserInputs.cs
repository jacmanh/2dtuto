using UnityEngine;

public class UserInputs : MonoBehaviour
{
  public float MoveSpeed = 5f;

  private Vector2 movement;

  private SpriteRenderer spriteRenderer;
  private Animator animator;
  private Rigidbody2D rigidBody;
  private static readonly int Move = Animator.StringToHash("Move");

  void Start()
  {
    animator = GetComponent<Animator>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    rigidBody = GetComponent<Rigidbody2D>();
  }
  void FixedUpdate()
  {
    MovePosition(movement);
  }
  void Update()
  {
    movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    AnimatePlayer(movement);
  }

  void MovePosition(Vector2 movement)
  {
    // Vector3 newPosition = new Vector3(movement.x * MoveSpeed, movement.y * MoveSpeed);
    // transform.position += newPosition * Time.deltaTime;
    rigidBody.velocity = new Vector2(movement.x * MoveSpeed, movement.y * MoveSpeed);
  }

  void AnimatePlayer(Vector2 movement)
  {
    animator.SetBool(Move, isMoving());
    // Avoid flipping sprite if only Vertical is triggered
    if (movement.x != 0)
    {
      spriteRenderer.flipX = movement.x < 0;
    }
  }

  bool isMoving()
  {
    return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
  }
}
