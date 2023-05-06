using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class UiManager : Singletone<UiManager>
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject LifePrefab;
    [SerializeField] private Transform LifeParent;
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private TMP_Text coinTxt;
    [SerializeField] private Image uiImage;
    [SerializeField] private GameObject gameOver;

    void Awake()
    {
        Player playerLogic = player.GetComponent<Player>();
        scoreTxt.text = string.Format("{0:n0}", playerLogic.score);
        coinTxt.text = string.Format("{0:n0}", playerLogic.coin);
    }
    void Start()
    {
        gameOver.SetActive(false);
        uiImage.color = new Color(1f, 1f, 1f, 0f);
    }

    public void UpdateLifeIcon(int lifeValue)
    {
        //Life 아이콘 추가
        for (int i = 0; i < lifeValue; i++)
        {
            Instantiate(LifePrefab, LifeParent);
        }
    }
    public void DeleteLifeIcon()
    {
        Destroy(LifeParent.GetChild(0).gameObject);
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        uiImage.color = new Color(0.4f, 0.4f, 0.4f, 0.8f);
    }
    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }

    public void AddScore(int enemyScore)
    {
        Player playerLogic = player.GetComponent<Player>();
        playerLogic.score += enemyScore;
    }
}
