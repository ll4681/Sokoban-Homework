

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

/*

public class Exit : Block
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*void Start()
    {
        // HERE IS A COMMENT IN THE START FUNCTION
    }
    

    // Update is called once per frame
    void Update()
    {
        //check the currennt position of the player and see if it's the same as the position of this block on the grid

        //check what is standing in the exit's cell
        /*
        GameObject standingHere = gridManager.gridList[gridPos.x][gridPos.y].GetComponent<Cell>().ContainObj;
        if (standingHere != null && standingHere.tag.Equals("Player"))
        {
            //load a new scene
        }
        


        if (gridManager == null || gridManager.gridList.Count == 0) return;

        GameObject standingHere = gridManager.gridList[gridPos.x][gridPos.y].GetComponent<Cell>().ContainObj;

        if (standingHere != null && standingHere.CompareTag("Player"))
        {
            LoadNextLevel();
        }


    }

    public override bool CheckMove(int _deltaX, int _deltaY)
    {
        return true;
    }


    private void LoadNextLevel()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        switch (currentScene)
        {
            case "test1":
                SceneManager.LoadScene("test2");
                break;
            case "test2":
                SceneManager.LoadScene("test3");
                break;
            case "test3":
                SceneManager.LoadScene("gameEnd");
                break;
            default:
                break;
        }
    }
}
*/
[RequireComponent(typeof(AudioSource))]

public class Exit : Block
{


    [SerializeField] private AudioClip moveSound;
    [SerializeField] private float volume = 1f;
    private AudioSource audioSource;



    void Update()
    {
        
        if (gridManager == null)
        {
            Debug.LogWarning("GridManager is null");
            return;
        }

        if (gridManager.gridList.Count == 0) return;

        GameObject standingHere = gridManager.gridList[gridPos.x][gridPos.y].GetComponent<Cell>().ContainObj;

        if (standingHere != null && standingHere != gameObject)
        {
            if (standingHere.CompareTag("Player"))
            {
                Debug.Log("Player detected");
                audioSource = GetComponent<AudioSource>();
                audioSource.PlayOneShot(moveSound, volume);
                LoadNextLevel();
            }
            else
            {
                Debug.Log("object is on the exit, but its tag is not player");
            }
        }
    }

    public override bool CheckMove(int _deltaX, int _deltaY)
    {
        Debug.Log("CheckMove called");
        return true;
    }

    private void LoadNextLevel()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        Debug.Log("Current scene is " + currentScene);

        switch (currentScene)
        {
            case "test1":
                SceneManager.LoadScene("test2");
                break;
            case "test2":
                SceneManager.LoadScene("test3");
                break;
            case "test3":
                SceneManager.LoadScene("gameEnd");
                break;
            default:
                break;
        }
    }
}
