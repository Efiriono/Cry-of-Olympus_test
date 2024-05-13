using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBackgroundMusicController : MonoBehaviour
{
    public static MainMenuBackgroundMusicController instance;
    public float musicVolume = 1f;
    private AudioSource audioSource;


    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        audioSource.Stop();
    }
    
    void Update()
    {
        audioSource.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
