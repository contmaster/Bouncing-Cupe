using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float jumpForce;

    public bool isTouched;

    private int jumperPlaneChance;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        jumperPlaneChance = Random.Range(1, 21);
        
        if (jumperPlaneChance == 1)
        {
            _animator.SetBool("IsJumper", true);
            jumpForce = 25f;
        }
        else
        {
            jumpForce = 15f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 jumpVelocity = rb.velocity;
                jumpVelocity.y = jumpForce;
                rb.velocity = jumpVelocity;

                if (isTouched == false)
                {
                    // randomValue = UnityEngine.Random.Range(1, 6);
                    // GameManager.Score += randomValue;
                    GameManager.score++;
                    isTouched = true;
                }

                _animator.SetBool("IsTouched", true);
                Destroy(gameObject, 1.5f);
            }
        }
    }
}
