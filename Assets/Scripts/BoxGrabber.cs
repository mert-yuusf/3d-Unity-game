using UnityEngine;

public class BoxGrabber : MonoBehaviour
{
    private BoxController boxController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(boxController != null)
        {
            boxController.transform.position = this.transform.position + this.transform.forward * 2 + Vector3.up * 0.5f;
            boxController.transform.localEulerAngles = this.transform.localEulerAngles;
            this.GetComponent<PlayerMovement>().JumpForce = 25;
            this.GetComponent<PlayerMovement>().Speed = 800;
            if (Input.GetKeyDown(KeyCode.F))
            {
                boxController.GetComponent<Rigidbody>().AddForce((this.transform.forward + this.transform.up) * 100);
                boxController = null;
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                RaycastHit[] hits = Physics.SphereCastAll(this.transform.position, 0.8f, this.transform.forward, 1f);

                foreach (RaycastHit hit in hits)
                {
                    if (hit.transform.gameObject.GetComponent<BoxController>() != null)
                    {
                        boxController = hit.transform.gameObject.GetComponent<BoxController>();
                        break;
                    }
                }
                Debug.Log("Grab");
            }
        }
        
    }

}
