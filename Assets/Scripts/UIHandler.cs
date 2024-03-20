using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public Slider musicSlider;

    public Slider sensSlider;

    public GameObject PauseMenu;
    public bool paused = false;

    public CharacterController characterController;

    public void Start()
    {
        PauseMenu.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Update()
    {
        musicAudioSource.volume = musicSlider.value;
        characterController.sensitivity = sensSlider.value;

        Pause();
    }
    
    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            paused = true;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
