using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneBtn : MonoBehaviour
{

    //public GameObject fadeImage;

    void Awake()
    {
       // fadeImage = GetComponent<GameObject>();
        
    }

    public void BtnClicked()
    {
        StartCoroutine("DelayStart");
    }


    public void SceneMoveDelay()
    {

        switch (this.gameObject.name)
        {

            case "StartBtn":
                SceneManager.LoadScene(1/*IntroScene*/);
                break;
            case "IntroSkipBtn":
                SceneManager.LoadScene(2/*GamePlayScene*/);
                break;
            case "BackToMainBtn":
                SceneManager.LoadScene(0/*MainscreenScene*/);
                break;
            case "MainCamera":
                SceneManager.LoadScene(3/*Ending*/);
                break;
            case "QuitGameBtn":
                Application.Quit();
                break;
            default:
                Debug.Log("µðÆúÆ®");
                SceneManager.LoadScene(3/*Ending*/);
                break;


        }
    }
    
    IEnumerator DelayStart()
    {

        int i = 0;
        while (i == 0)
        {
            i++;
            yield return new WaitForSecondsRealtime(0.5f);
        }
        Time.timeScale = 1;

        //fadeImage.enabled = true;

        //while (fadecount < 1.0f)
        //{
         //   fadecount += 0.1f;
       //     yield return new WaitForSecondsRealtime(0.01f);
        //    fadeImage.color = new Color(0, 0, 0, fadecount);
       // }

        SceneMoveDelay();
    }

    
}
