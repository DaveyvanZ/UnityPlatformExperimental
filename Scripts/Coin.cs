using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //OnTriggerEnter
    //give the player a coin
    //destroy object
    //update UI

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (other != null)
            {
                player.AddCoins();
                Destroy(this.gameObject);
            }
        }
    }
}
