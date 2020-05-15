using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour
{
    public PlayableDirector playabledirector;
    // Start is called before the first frame update
    void Start()
    {
        //同じゲームオブジェクトにあるPlayableDirectorを取得する
        playabledirector = GetComponent<PlayableDirector>();
        PlayTimeline();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //再生する
    void PlayTimeline()
    {
        playabledirector.Play();
    }

    //一時停止する
    void PauseTimeline()
    {
        playabledirector.Pause();
    }

    //一時停止を再開する
    void ResumeTimeline()
    {
        playabledirector.Resume();
    }

    //停止する
    void StopTimeline()
    {
        playabledirector.Stop();
    }

}
