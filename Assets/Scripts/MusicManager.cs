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
            SceneLoader.LoadNextScene();
            this.GetComponent<MusicManager>().enabled = false;
        }
    }
}
