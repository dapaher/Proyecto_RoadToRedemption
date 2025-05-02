using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    const int MAX_LIFES = 4, START_LIVES = 3;
    int currentScene;
    string msg;
    [SerializeField] TMP_Text shellsText;
    [SerializeField] TMP_Text msgText;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] Image[] imgLives;
    [SerializeField] GameObject canvas;
    [SerializeField] AudioClip sfxGameOver;
    int lives = START_LIVES;
    int shells;

    public static GameController GetInstance(){
        return instance;
    }
    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(canvas);
            for (int i = 0; i < imgLives.Length; i++){
            imgLives[i].enabled = i < lives;
        }
        }
        else if(instance != this){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        shells = GameObject.FindGameObjectsWithTag("Shell").Length;
        shellsText.text = shells.ToString();

        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    public void RestartGame(){
        SceneManager.LoadScene(1);
    }

    public void GameOver(){
        //GAMEOVER
        AudioSource.PlayClipAtPoint(sfxGameOver, transform.position);
        StartCoroutine("EnableAndDisableGameOverTxt");

        for (int i = 0; i < imgLives.Length; i++){
            imgLives[i].enabled = i < lives;
        }

        Invoke("RestartGame", 3f);
    }

    public void NextLevel(){
        if(currentScene == SceneManager.sceneCountInBuildSettings - 2){
            StartCoroutine("SendMsg", "Has completado la demo! Gracias por jugar!");
            StartCoroutine("LoadNextScene");
            //Invoke("ExitGame", 3.5f);
        } 
        else StartCoroutine("LoadNextScene");
    }

    public int GetLives(){
        return lives;
    }

    private void OnGUI() {
        for (int i = 0; i < imgLives.Length; i++){
            imgLives[i].enabled = i < lives;
        }
    }
    public void AddLife(){
        if(lives == MAX_LIFES) return;
        lives++;
    }

    public void LoseLife(){
        lives--;
    }

    public int CheckShells(){
        return shells;
    }

    public void SendMsg(string msg){
        StartCoroutine("EnableAndDisableMsg", msg);
    }

    public void ExitGame(){
        Application.Quit();
    }
    
    IEnumerator EnableAndDisableMsg(string msg){
        msgText.text = msg;

        yield return new WaitForSeconds(3.5f);
        msgText.text = "";
    }

    IEnumerator EnableAndDisableGameOverTxt(){
        gameOverText.text = "GAME OVER";

        yield return new WaitForSeconds(2.5f);
        gameOverText.text = "";
        lives = 3;
    }

    IEnumerator LoadNextScene(){
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(currentScene + 1);
    }
    
}
