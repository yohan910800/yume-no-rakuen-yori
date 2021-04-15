using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{

    //　スタートボタンを押したら実行する
    public void StartGame()
    {
        SceneManager.LoadScene("ministage 1");
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