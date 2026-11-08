using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //public Scene startScene;

    private bool isReloading = false;

    [SerializeField] private AudioClip levelChangeSound;
    private AudioSource audioSource;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //SceneManager.SetActiveScene(startScene);
    }

    // Update is called once per frame
    void Update()
    {



        
        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            Debug.Log("reload button pressed");
            StartCoroutine(ReloadLevelCoroutine());
        }
        

        /*
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            



            int count = SceneManager.sceneCount;

            Scene[] activeScenes = new Scene[count];

            for (int i = 0; i < count; i++)
            {
                activeScenes[i] = SceneManager.GetSceneAt(i);
            }

            foreach (Scene s in activeScenes)
            {
                if (s.isLoaded && s.name != "background")
                {
                    SceneManager.UnloadSceneAsync(s);
                }
            }


            //Scene currentScene = SceneManager.GetActiveScene();
            //SceneManager.UnloadSceneAsync(currentScene);
            SceneManager.LoadScene("test1", LoadSceneMode.Additive);



            /*
             make an array of all loaded scenes. look through them. unload every one that isn't background
             
             
            Scene[] activeScenes = SceneManager.GetAllScenes();
            
            foreach (Scene s in activeScenes)
            {
                
            }
            





        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {



            int count = SceneManager.sceneCount;

            Scene[] activeScenes = new Scene[count];

            for (int i = 0; i < count; i++)
            {
                activeScenes[i] = SceneManager.GetSceneAt(i);
            }

            foreach (Scene s in activeScenes)
            {
                if (s.isLoaded && s.name != "background")
                {
                    SceneManager.UnloadSceneAsync(s);
                }
            }


            //Scene currentScene = SceneManager.GetActiveScene();
            //SceneManager.UnloadSceneAsync(currentScene);
            SceneManager.LoadScene("test2", LoadSceneMode.Additive);



            /*
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.UnloadSceneAsync(currentScene);
            SceneManager.LoadScene("test2", LoadSceneMode.Additive);
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {



            int count = SceneManager.sceneCount;

            Scene[] activeScenes = new Scene[count];

            for (int i = 0; i < count; i++)
            {
                activeScenes[i] = SceneManager.GetSceneAt(i);
            }

            foreach (Scene s in activeScenes)
            {
                if (s.isLoaded && s.name != "background")
                {
                    SceneManager.UnloadSceneAsync(s);
                }
            }


            //Scene currentScene = SceneManager.GetActiveScene();
            //SceneManager.UnloadSceneAsync(currentScene);
            SceneManager.LoadScene("test3", LoadSceneMode.Additive);



            /*
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.UnloadSceneAsync(currentScene);
            SceneManager.LoadScene("test2", LoadSceneMode.Additive);
            
        }
        */

        /*
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            SceneManager.LoadSceneAsync("test3");
        }
        */
    }


    public void StartGame()
    {
        //Load the level 1 scene
        Debug.Log("loadedtest1 button pressed");
        //SceneManager.LoadScene("test1", LoadSceneMode.Additive);

      //  SceneManager.LoadSceneAsync("test1", LoadSceneMode.Additive);

       // SceneManager.UnloadSceneAsync("startscreen");

        StartCoroutine(TransitionToLevel1());

    }



    /*




    private IEnumerator TransitionToLevel1()
    {
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("test1", LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Scene test1Scene = SceneManager.GetSceneByName("test1");
        SceneManager.SetActiveScene(test1Scene);
      
        SceneManager.UnloadSceneAsync("startscreen");
    }


    private IEnumerator ReloadLevelCoroutine()
    {
        Scene oldScene = SceneManager.GetActiveScene();
        string sceneName = oldScene.name;

        if (sceneName == "background" || sceneName == "startscreen")
        {
            yield break;
        }

        AsyncOperation load = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!load.isDone)
        {
            yield return null;
        }

        AsyncOperation unload = SceneManager.UnloadSceneAsync(oldScene);

        if (unload != null)
        {
            while (!unload.isDone)
            {
                yield return null;
            }
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }




    */



    private IEnumerator TransitionToLevel1()
    {
        isReloading = true; 

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("test1", LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Scene test1Scene = SceneManager.GetSceneByName("test1");
        SceneManager.SetActiveScene(test1Scene);

        SceneManager.UnloadSceneAsync("startscreen");

        isReloading = false; 
    }

    private IEnumerator ReloadLevelCoroutine()
    {
        isReloading = true;

        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "background" ||
            currentScene.name == "startscreen")
        {
            isReloading = false;
            yield break;
        }

        yield return SceneManager.LoadSceneAsync(
            currentScene.name,
            LoadSceneMode.Single
        );

        isReloading = false;
    }




    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += PlayLevelChangeSound;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= PlayLevelChangeSound;
    }

    private void PlayLevelChangeSound(Scene scene, LoadSceneMode mode)
    {

            if (levelChangeSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(levelChangeSound);
            }
        
    }



}





//HERE IS MY VERSION ABOVE. BELOW IS TEACHER VERSION








