using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CarStereo : MonoBehaviour
{
    [SerializeField] private string folder;
    [SerializeField] private AudioPlayer MusicPlayer;
    [SerializeField] private Text UiText;
    [SerializeField] private float speedText;
    private DigitalText DisplayText;
    private float actionMusic = 0f;
    private float turnMusic = 0f;
    private Coroutine displayUiText;
    void Start()
    {
        MusicPlayer.AudioFolderPath = folder;
        DisplayText = new DigitalText("", 26);
    }

    void Update()
    {
        PressButtons();
    }

    private void PressButtons()
    {
        if (Input.GetAxisRaw("Music") != 0f)
        {
            actionMusic = Input.GetAxisRaw("Music");
        }
        else if (actionMusic != 0f)
        {
            if (displayUiText != null) StopCoroutine(displayUiText);
            if (actionMusic > 0f) MusicPlayer.PlayNext();
            else MusicPlayer.PlayBack();
            DisplayText.Text = MusicPlayer.PlayedAudio;
            displayUiText = StartCoroutine(showUiText());
            actionMusic = 0f;
        }

        if (Input.GetAxisRaw("TurnMusic") != 0f)
        {
            turnMusic = Input.GetAxisRaw("TurnMusic");
        }
        else if (turnMusic != 0f)
        {
            if (displayUiText != null) StopCoroutine(displayUiText);

            if (MusicPlayer.isPlaying())
            {
                //DisplayText.Text = "PAUSE";
                UiText.text = "PAUSE";
                MusicPlayer.Pause();
            }
            else
            {
                MusicPlayer.Pause();
                DisplayText.Text = MusicPlayer.PlayedAudio;
                displayUiText = StartCoroutine(showUiText());
            }
            turnMusic = 0f;
        }


    }

    IEnumerator showUiText()
    {
        while (true)
        {
            UiText.text = DisplayText.GetTextLine();
            yield return new WaitForSeconds(speedText);
        }
    }
}
