using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Up : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (other != null)
            {
                player.PowerUp(gameObject.tag);
                Destroy(this.gameObject);
            }
        }
    }
}
