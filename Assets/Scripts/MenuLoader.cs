using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!isPaused) {
                OnPause();
            } else {
                OnResume();
            }
        }

    }

    

    public void LoadLevel(int level) {
        SceneManager.LoadScene(level);
    }

    void OnPause() {
    
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        isPaused = true;

    }
    public void OnResume() {
        print("sin pausa");
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        isPaused = false;
    }

}
