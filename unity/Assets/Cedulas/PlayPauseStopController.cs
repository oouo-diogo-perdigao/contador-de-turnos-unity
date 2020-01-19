using UnityEngine;
using System.Collections;

public class PlayPauseStopController : MonoBehaviour {

    /// <summary>
    /// Qualquer pausado da Play
    /// </summary>
    public void AllPlayPause()
    {
        foreach (PlayPauseStop item in PlayPauseStop.lista)
        {
            item.PlayPause();
        }
    }

    /// <summary>
    /// Qualquer Play Pausa
    /// </summary>
    public void AllPause()
    {
        foreach (PlayPauseStop item in PlayPauseStop.lista)
        {
            item.Pause();
        }
    }

    /// <summary>
    /// Stop em todos
    /// </summary>
    public void AllStop()
    {
        foreach (PlayPauseStop item in PlayPauseStop.lista)
        {
            item.Stop();
        }
    }
}
