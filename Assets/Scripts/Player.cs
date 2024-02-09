using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController Character;
    private Vector3 Direction;

    public Sprite DeadClio;

    public float gravity = 9.8f * 2f;
    public float JumpForce = 8f;

    private void Awake()
    {
        Character = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        Direction = Vector3.zero;
    }

    private void Update()
    {
        Direction += Vector3.down * gravity * Time.deltaTime;

        if (Character.isGrounded)
        {
            Direction = Vector3.down;

            if (Input.GetButton("Jump"))
            {
                Direction = Vector3.up * JumpForce;
            }
        }

        Character.Move(Direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) {
            GameManager.Instance.GameOver();
        }
    }

    public void ChangeSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = DeadClio;
    }

}
