using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinText, _livesText;

    public void UpdateCoinDisplay(int coins)
    {
        // update text display
        _coinText.text = "Coins: " + coins.ToString();
    }

    public void UpdateLivesDisplay(int lives)
    {
        _livesText.text = "Lives: " + lives.ToString();
    }
}
