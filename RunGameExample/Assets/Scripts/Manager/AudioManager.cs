using UnityEngine;
using UnityEngine.SceneManagement;

public enum SoundScene
{
    TITLE,
    GAME,
}

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] SoundScene soundScene;

    [SerializeField] AudioSource sfxSource;

    [SerializeField] AudioSource scenerySource;

    private void Start()
    {
        
    }

    public void SFXSound(AudioClip audioClip)
    {
        sfxSource.PlayOneShot(audioClip);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        soundScene = (SoundScene)scene.buildIndex;
        scenerySource.clip = Resources.Load<AudioClip>(soundScene.ToString() + " Bgm");
        scenerySource.loop = true;
        scenerySource.Play();
    }

}
