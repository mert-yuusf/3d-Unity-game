using UnityEngine;

public class BoxController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bool")
        {
            FindObjectOfType<GameManager>().IncreaseScore(10);
        }
    }
}
