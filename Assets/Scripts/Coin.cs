using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Coin");
            this.gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().PlayCoinClip();
            FindObjectOfType<GameManager>().IncreaseScore(1);
        }
    }
}
