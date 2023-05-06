using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCont : MonoBehaviour
{
    [SerializeField] private GameObject HP;
    [SerializeField] private TMP_Text Score;
    [SerializeField] private TMP_Text Coin;

    void Start()
    {
        Score.text = "0";
        Coin.text = "0";
    }

    void Update()
    {
        
    }
}
