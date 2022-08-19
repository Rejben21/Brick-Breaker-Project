using UnityEngine;

public class LoseZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            GameManager.instance.Miss();
            //FindObjectOfType<GameManager>().Restart();
        }
    }
}
