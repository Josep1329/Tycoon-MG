using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    public GameObject pausePanel, playerUI;

    private bool isPaused;


    void Start()
    {
        isPaused = false;
        CursorState(false);
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        PauseInput();
    }

    void PauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumenGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        playerUI.SetActive(false);
        CursorState(true);
        Time.timeScale = 0f;
    }

    public void ResumenGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        playerUI.SetActive(true);
        CursorState(false);
        Time.timeScale = 1f;
    }

    public void CursorState(bool _state)
    {
        Cursor.visible = _state;
        if (_state)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
