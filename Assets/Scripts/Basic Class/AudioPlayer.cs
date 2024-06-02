using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

[System.Serializable]

public class AudioPlayer
{
    private List<AudioClip> audioFiles;
    private int playedAudio=-1;
    private string audioFolderPath;

    [SerializeField] protected AudioSource BoomBox;

    public string PlayedAudio
    {
        get
        {
            if (playedAudio == -1) return "OFF"; else return audioFiles[playedAudio].name;
        }
    }

    public string[] AudioFiles
    {
        get
        {
            var list = new List<string>();
            foreach(AudioClip audio in audioFiles)
            {
                list.Add(audio.name);
            }
            return list.ToArray();
        }
    }

    public string AudioFolderPath
    {
        get
        {
            return this.audioFolderPath;
        }

        set
        {
            this.audioFolderPath = value;
            this.audioFiles=this.InitAudioFolder();
        }
    }


    // я не знаю как написать собственное событие если кончился звук без класса MonoBehaivour
    // поэтому все танцы с бубном пусть реализует другой объект
    public bool isPlaying()
    {
        return BoomBox.isPlaying;
    }

    public void PlayRandom()
    {
       int randomIndexAudio = Random.Range(0, this.audioFiles.Count);
       PlayByID(randomIndexAudio);
    }

    public void PlayNext()
    {
        if (playedAudio + 1 == audioFiles.Count) playedAudio = 0;
        else playedAudio++;
        this.PlayByID(playedAudio);
    }

    public void PlayBack()
    {
        if (playedAudio - 1 < 0) playedAudio = audioFiles.Count-1;
        else playedAudio--;
        this.PlayByID(playedAudio);
    }

    public void Pause()
    {
        if (isPlaying())
        {
            BoomBox.Pause();
        } else if(playedAudio != -1)
        {
            BoomBox.Play();
        } else
        {
            PlayByID(0);
        }
    }

    public void PlayByID(int id)
    {
        if (audioFiles.Count > id)
        {
            BoomBox.Stop();
            BoomBox.clip = audioFiles[id];
            playedAudio = id;
            BoomBox.Play();
        }
    }

    public void PlayByName(string name)
    {
        int idAudio = audioFiles.FindIndex(x => x.name.ToLower() == name.ToLower());
        if (idAudio != -1) this.PlayByID(idAudio);
    }

    private List<AudioClip> InitAudioFolder()
    {
        var audioFiles=new List<AudioClip>();
        string[] AudoFilesPath = Directory.GetFiles("Assets/"+audioFolderPath, "*.mp3");
        foreach(string pathToAudio in AudoFilesPath)
        {
            AudioClip audio = AssetDatabase.LoadAssetAtPath<AudioClip>(pathToAudio);
            audioFiles.Add(audio);
        }
        return audioFiles;
    }
}
