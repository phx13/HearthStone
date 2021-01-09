using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
    public MovieTexture movTexture;
    public bool isDrawMov = true;
    public bool isShowMessage = false;
    public TweenAlpha startBgTweenAlpha;
    public TweenAlpha startLogoTweenAlpha;
    public TweenAlpha startMenuTweenAlpha;
    private bool isCanShowStartMenu;
    public UISprite myHero;
    public UIProgressBar loadingProgressBar;
    public UIButton playButton;
    public UIButton loadingBackButton;

    // Use this for initialization
    void Start ()
    {
        movTexture.loop = false;
        movTexture.Play();
        startLogoTweenAlpha.AddOnFinished(this.StartLogoTweenFinished);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isDrawMov)
        {
            if (Input.GetMouseButtonDown(0)&&isShowMessage==false)
            {
                isShowMessage = true;
            }
            else if (Input.GetMouseButtonDown(0) && isShowMessage == true)
            {
                StopMov();
            }
        }

        if (isDrawMov!=movTexture.isPlaying)
        {
            StopMov();
        }

        if (isCanShowStartMenu&&Input.GetMouseButtonDown(0))
        {
            startMenuTweenAlpha.PlayForward();
            isCanShowStartMenu = false;
        }
	}

    void OnGUI()
    {
        if (isDrawMov)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movTexture);
        }
        if (isShowMessage)
        {
            GUI.Label(new Rect(Screen.width / 2 -50, Screen.height / 2, 400, 100), "再次点击退出播放");
        }
    }

    void StopMov()
    {
        movTexture.Stop();
        isDrawMov = false;
        isShowMessage = false;
        startBgTweenAlpha.PlayForward();
    }

    private void StartLogoTweenFinished()
    {
        isCanShowStartMenu = true;
    }

    public void loadingAcceptButtonOnClick()
    {
        VSShow.vs.Show(myHero.spriteName, "hero" + Random.Range(1, 10));
        StartCoroutine(loadPlayScene());
    }

    IEnumerator loadPlayScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }

    public void loadingProgressBarAdding()
    {
        loadingProgressBar.GetComponent<UIProgressBar>().value = Mathf.Lerp(0, 1, Time.time);
    }

    public void playButtonOnClick()
    {
        playButton.isEnabled = false;
    }

    public void loadingBackButtonOnClick()
    {
        playButton.isEnabled = true;
    }
}
