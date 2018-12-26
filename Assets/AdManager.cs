using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {

    IEnumerator checkInternetConnection(Action<bool> action)
    {
        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.error != null)
        {
            action(false);
        }
        else
        {
            action(true);
        }
    }

    public void ShowAdNonSkipable()
    {
        StartCoroutine(checkInternetConnection((isConnected) => {
            if (isConnected)
            {
                if (Advertisement.IsReady("rewardedVideo"))
                {
                    var options = new ShowOptions { resultCallback = HandleShowResult };
                    Advertisement.Show("rewardedVideo", options);

                }
            }
            else
            {
                SSTools.ShowMessage("No internet connection", SSTools.Position.bottom, SSTools.Time.twoSecond);
            }
        }));
        

    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                GameManager.Instance.continueGame();
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                SSTools.ShowMessage("The ad failed to be shown.", SSTools.Position.bottom, SSTools.Time.twoSecond);
                break;
        }
    }
}
