using UnityEngine;

public class Brick : MonoBehaviour
{
    public int health { get; private set; }

    public SpriteRenderer sR { get; private set; }

    public Color[] colors;

    public bool unbreakable;

    private void Awake()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if(!unbreakable)
        {
            health = colors.Length;
            sR.color = colors[health - 1];
        }
    }

    private void Hit()
    {
        if(unbreakable)
        {
            return;
        }

        health--;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            sR.color = colors[health - 1];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            Hit();
        }
    }
}
