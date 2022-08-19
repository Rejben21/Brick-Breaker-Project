using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball instance;

    public new Rigidbody2D rigidbody { get; private set; }

    public float moveSpeed = 500;

    private void Awake()
    {
        instance = this;

        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        this.transform.position = Vector2.zero;
        this.rigidbody.velocity = Vector2.zero;

        Invoke(nameof(SetRandomTrajectory), 1);
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        rigidbody.AddForce(force.normalized * moveSpeed);
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = rigidbody.velocity.normalized * moveSpeed;
    }
}
