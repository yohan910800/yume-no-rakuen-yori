using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    static int HP = 0;
    //PlayerData playerData;
    //PlayerHPBar playerHP;

    private void Start()
    {
        //playerData = PlayerData.GetInstance();
        //playerHP = PlayerHPBar.GetInstance();
        //HP = playerData.hp;
        //playerHP.SliderUpdate();
    }

    //　スタートボタンを押したら実行する
    public void StartGame()
    {
        HP = 100;
        SceneManager.LoadScene("Title");
    }

    //　ゲーム終了ボタンを押したら実行する
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
		Application.OpenURL("http://www.yahoo.co.jp/");
#else
		Application.Quit();
#endif
    }
}