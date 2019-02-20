using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    [Range(1,10)][SerializeField] float musicDelay = 3f;
    bool bLoaded;

    private void Awake()
    {
        if (FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time > musicDelay && !bLoaded)
        {
            bLoaded = true;
            SceneLoader.LoadNextScene();
        }
    }
}
