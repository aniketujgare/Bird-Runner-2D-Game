using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public static Sound instance;
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private  Button Btn;

// Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Btn = GetComponent<Button>();
    }

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetInt("Music", 1);
            BGMusic(true);
        }
        else
        {
            if (PlayerPrefs.GetInt("Music") == 1)
            {
                BGMusic(true);
            }
            else
                BGMusic(false); 
        }
    }

    public void BGMusic(bool play)
    {
        if (play)
        {
                audiosource.Play();
            Btn.GetComponent<Image>().sprite = sprite[1];
        }
        else
        {
                audiosource.Stop();
            Btn.GetComponent<Image>().sprite = sprite[0];
        }
    }

    public void OnMuiscClick()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            PlayerPrefs.SetInt("Music", 0);
            BGMusic(false);
        }
        else
        {
            PlayerPrefs.SetInt("Music", 1);
            BGMusic(true);
        }
    }

}
