﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneManager : MonoBehaviour
{
    private static string TAG = "MainMenuSceneManager";

    public GameObject matchingArea;

    public GameObject toastView;

    public GameObject choosePVEArea;

    // Start is called before the first frame update
    void Start()
    {
        KHeartbeat.Instance.SendHeartbeat(KHeartbeat.UserStatus.IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPVE()
    {
        if (matchingArea.GetComponent<MatchingAreaView>().isMatching) {
            toastView.GetComponent<ToastView>().ShowToast("匹配中不可选择");
            return;
        }
        choosePVEArea.SetActive(true);
    }

    public void PlayPVP()
    {
        if (matchingArea.GetComponent<MatchingAreaView>().isMatching) {
            toastView.GetComponent<ToastView>().ShowToast("已在匹配中");
            return;
        }
        matchingArea.GetComponent<MatchingAreaView>().ShowArea();
    }

    public void SwtichToDeckConfigScene()
    {
        if (matchingArea.GetComponent<MatchingAreaView>().isMatching) {
            toastView.GetComponent<ToastView>().ShowToast("匹配中不可选择");
            return;
        }
        KLog.I(TAG, "onClick SwtichToDeckConfigScene");
        SceneManager.LoadScene("DeckConfigScene");
    }

    public void SwtichToGuideScene()
    {
        if (matchingArea.GetComponent<MatchingAreaView>().isMatching) {
            toastView.GetComponent<ToastView>().ShowToast("匹配中不可选择");
            return;
        }
        KLog.I(TAG, "onClick SwtichToGuideScene");
        LoadingScene.Load("GuideScene");
    }
}
