using UnityEngine;

public class SpikeCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpikeController.IsActive = false;

        if (collision.tag == NameHelper.TagBall)
        {
            collision.GetComponent<BallController>().Split();
        }
    }
}
