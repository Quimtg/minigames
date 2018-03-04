﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KauboiDueru : IMiniGame
{
    private GameManager gameManager;

    /*
     * Player can shoot only in a concret moment, if he tries to shoot in other moment, he loses.
     */
    [Header("Game State")]
    public bool playerCanShoot=false;
    //Generated by random
    public float minShootTime;
    public float maxShootTime;
    //If player dont shoots, enemy shoots
    public float enemyShootCounter;

    [Header("Game Time")]
    public int gameTime = 10;
    private bool gameSpawnStop = false;
    public Text gameWinText;

    void Start()
    {
        //
    }
    public override void beginGame()
    {
        //KauboiDueru Begins
        Debug.Log(this.ToString() + " game Begin");
        StartCoroutine(gameTimer());
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
    }

    public override string ToString()
    {
        return "Kauboi Dueru by Saltimbanqi";
    }

    private void Update()
    {

    }

    public void setEndGame()
    {
        StopAllCoroutines();
        gameManager.EndGame(MiniGameResult.LOSE);
    }
    
    void setEndGameWin()
    {
        StopAllCoroutines();
        gameManager.EndGame(MiniGameResult.WIN);
    }
    
    public IEnumerator gameTimer()
    {
        for(int i=gameTime;i>-1;--i)
        {
            yield return new WaitForSeconds(1f);
            if(i==0)
                gameSpawnStop = true;
            
        }
    }

    public bool getEndTime()
    {
        return gameSpawnStop;
    }

    public void setEndTime(bool _value)
    {
        gameSpawnStop = _value;
    }
    public IEnumerator endGame()
    {
        gameWinText.enabled = true;
        yield return new WaitForSecondsRealtime(2f);
        setEndGameWin();
    }
}
