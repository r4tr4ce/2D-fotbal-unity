using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxVelocity = 20f;          // Maximum speed for the ball
    public AudioClip goalSound;              // Sound to play when a goal is scored
    public AudioClip bounceSound;            // Sound to play when the ball bounces
    public Transform resetPosition;          // Position to reset the ball after a goal

    private Rigidbody2D rb;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        // Assign default reset position if not set in Inspector
        if (resetPosition == null)
        {
            Debug.LogWarning("Reset position not assigned in BallController. Using default position.");
            resetPosition = transform; // Assuming default position is the ball's current position
        }
    }

    void Update()
    {
        // Limit the ball's maximum speed
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Play bounce sound when colliding with ground or players
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground"))
        {
            PlaySound(bounceSound);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the ball enters a goal trigger
        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Ball entered goal: " + other.gameObject.name); // Check if this log appears
            PlaySound(goalSound);
            ResetBallPosition();

            // Update the score based on which goal was hit
            UpdateScore(other.gameObject.name);
        }
    }


    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    private void ResetBallPosition()
    {
        // Reset the ball to the starting position and stop its movement
        if (resetPosition != null)
        {
            transform.position = resetPosition.position;
            rb.velocity = Vector2.zero;
        }
        else
        {
            Debug.LogError("Reset position is not assigned in BallController!");
        }
    }

    private void UpdateScore(string goalObjectName)
    {
        // Attempt to find GameManager in scene
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            gameManager.UpdateScore(goalObjectName);
        }
        else
        {
            Debug.LogWarning("GameManager not found in scene. Score update skipped.");
        }
    }
}
