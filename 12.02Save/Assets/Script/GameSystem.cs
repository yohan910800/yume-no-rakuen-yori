using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    GameObject pausePrefabObj;

    

    //　スタートボタンを押したら実行する
    public void StartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
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

    public void ReturnTitleScreen()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void ContinueGame()
    {
        
        Destroy(GameObject.Find("PausUI 1(Clone)"));
        Time.timeScale = 1.0f;
    }
}