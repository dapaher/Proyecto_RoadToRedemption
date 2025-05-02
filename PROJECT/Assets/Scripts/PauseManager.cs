using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;

    private bool isPaused = false;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            if(isPaused) Resume();
            else Pause();
        }
    }

    public void Pause(){
        Time.timeScale = 0;
        audioSource.Pause();
        isPaused = true;
        if(pauseMenuUI != null) pauseMenuUI.SetActive(true);
    }

    public void Resume(){
        Time.timeScale = 1;
        audioSource.UnPause();
        isPaused = false;
        if(pauseMenuUI != null) pauseMenuUI.SetActive(false);
    }
}
