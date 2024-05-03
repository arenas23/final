using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public Canvas winCanvas, loseCanvas;


    public int defeatedEnemies = 0;
    public int activeGenerators = 0;
    public int keyCard = 0;

    [SerializeField] private bool isPaused = false;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject uiPlayer;
    public Slider sliderMusic, sliderSFX, sliderMaster;
    
    public Slider sensitivitySlider;
    public CameraController cameraController;

    public bool IsPaused
    {
        get { return isPaused; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        sensitivitySlider.value = cameraController.mouseSensitivity;
        sensitivitySlider.onValueChanged.AddListener(cameraController.SetMouseSensitivity);

        pauseCanvas = GameObject.Find("Pause Variant");
        uiPlayer = GameObject.Find("UIPlayer");

        if (pauseCanvas != null)
        {
            pauseCanvas.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("No se encontr� 'Pause Variant'.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        PausePanel();
    }

    public void PauseGame()
    {
        uiPlayer.gameObject.SetActive(false);
        pauseCanvas.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        isPaused = true;
        
    }
   
    public void ResumeGame()
    {
        uiPlayer.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        isPaused = false;
        
    }

    public void ResetGame()
    {
        ResumeGame();
        defeatedEnemies = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
        defeatedEnemies = 0;
        SceneManager.LoadScene("Main Menu");
    }

    public void LosePlayer()
    {
        loseCanvas.gameObject.SetActive(true);
        PauseGame();
    }

    void PausePanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {      
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {       
            ResumeGame();
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }


}
