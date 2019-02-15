using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [Range(1,10)][SerializeField] float musicDelay = 3f;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time > musicDelay)
        {
            LoadNextScene();
            this.GetComponent<MusicManager>().enabled = false;
        }
    }

    private static void LoadNextScene()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }
}
