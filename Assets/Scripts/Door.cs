using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Door Animation")]
    [SerializeField] private Animator door;
    [SerializeField] private bool isOpen=false;
    [SerializeField] private bool isClose=false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isOpen)
            {
                door.Play("openDoor",0,0.0f);
                gameObject.SetActive(false);
            }
            if (isClose)
            {
                door.Play("closeDoor",0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
