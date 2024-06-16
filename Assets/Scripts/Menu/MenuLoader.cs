using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;
using Simplon; //nameSpace del game manager

public class MenuLoader : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    bool isPaused;

    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button toMainMenuButton;
    [SerializeField] private GameObject controlPanel;





    // Start is called before the first frame update
    private void Awake() {
        playButton.onClick.AddListener(LoadFirstLevel);
        optionsButton.onClick.AddListener(OpenOptions);
        controlsButton.onClick.AddListener(OpenControls);
        quitButton.onClick.AddListener(OnQuit);
        toMainMenuButton.onClick.AddListener(ToMainMenu);
    }

    private void OnDestroy() {
        playButton.onClick.RemoveAllListeners();
        optionsButton.onClick.RemoveAllListeners();
        controlsButton.onClick.RemoveAllListeners();
        quitButton.onClick.RemoveAllListeners();
        toMainMenuButton.onClick.RemoveAllListeners();
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
    public void ToMainMenu() {
        //carga el menu
        GameControler.instance.pasarNivel("MenuScene");
    }
    public void OpenControls() {
       controlPanel.SetActive(true);
    }
    public void OpenOptions() {
        Debug.Log("opciones");
    }
    public void LoadFirstLevel() {
        //craga la primer pista de carreras
        GameControler.instance.pasarNivel("Race1");
        

    }
    //anule esta funcion ya que ahora se usa desde el 
    //game manager
    /*public void LoadLevel(int level) {
        SceneManager.LoadScene(level);
    }*/
   
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
        //mostrar el hud del auto
        GameControler.instance.agregarnEscena("Hud_v2.0");
    }
    public void OnQuit() {
       Application.Quit();
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #endif
    }
}
