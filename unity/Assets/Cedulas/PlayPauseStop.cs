using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayPauseStop : MonoBehaviour
{

	public static List<PlayPauseStop> lista = new List<PlayPauseStop>();

	public Piscar turno;

	public Text tempoTurnoText;
	public Text tempoGeralText;

	public Button play;
	public Button pause;
	public Button stop;

	bool sinalTurno = false;
	bool sinalTolerancia = false;

	float tempoTurno = 0f;
	float tempoGeral = 0f;

	enum Estado { Play, Pause, Stop }
	Estado meuEstado = Estado.Stop;


	void Start()
	{
		lista.Add(this);
		Stop();
	}

	// Update is called once per frame
	void Update()
	{
		if (meuEstado == Estado.Play)
		{
			tempoGeral += Time.deltaTime;
			tempoTurno += Time.deltaTime;
			
			tempoTurnoText.text = 
				((int)(tempoTurno / 3600)).ToString("0") + ":" +
				((int)((tempoTurno / 60) % 60)).ToString("00") + ":" +
				((int)(tempoTurno % 60)).ToString("00");

			tempoGeralText.text =
				((int)(tempoGeral / 3600)).ToString("0") + ":" +
				((int)((tempoGeral / 60) % 60)).ToString("00") + ":" +
				((int)(tempoGeral % 60)).ToString("00");

			if (!sinalTurno && tempoTurno >= float.Parse(Controlador.singleton.turno.text) * 60)
			{
				sinalTurno = true;
				Controlador.singleton.SomTurno();
				turno.PiscarTurno();
			}
			else if (sinalTurno && !sinalTolerancia && tempoTurno >= (float.Parse(Controlador.singleton.turno.text) + float.Parse(Controlador.singleton.tolerancia.text)) * 60)
			{
				sinalTolerancia = true;
				Controlador.singleton.SomTolerancia();
				turno.PiscarTolerancia();
			}
		}
	}



	/// <summary>
	/// Se estiver pausado da play
	/// </summary>
	public void PlayPause()
	{
		if (meuEstado == Estado.Pause)
		{
			Play();
		}
	}
	/// <summary>
	/// Se Play Pause
	/// Se Pause Play
	/// </summary>
	public void PlayPausePlay()
	{
		if (meuEstado != Estado.Play)
		{
			Play();
		}
		else if (meuEstado == Estado.Play)
		{
			Pause();
		}
	}
	/// <summary>
	/// Se estiver pausado ou em stop da play
	/// </summary>
	public void PlayAllPause()
	{
		if (meuEstado != Estado.Play)
		{
			Play();
		}
		else
		{
			Pause();
		}
	}

	/// <summary>
	/// Da play
	/// </summary>
	public void Play()
	{
		Debug.Log("Play");
		meuEstado = Estado.Play;
		stop.interactable = true;
		pause.interactable = true;
		pause.gameObject.SetActive(true);
		play.interactable = false;
	}

	/// <summary>
	/// Da Pause
	/// </summary>
	public void Pause()
	{
		Debug.Log("Pause");
		if (meuEstado != Estado.Stop)
		{
			meuEstado = Estado.Pause;
			stop.interactable = true;
			pause.interactable = false;
			play.interactable = true;
		}
	}

	/// <summary>
	/// Da Stop
	/// </summary>
	public void Stop()
	{
		Debug.Log("Stop");
		meuEstado = Estado.Stop;
		stop.interactable = false;
		pause.interactable = false;
		pause.gameObject.SetActive(false);
		play.interactable = true;
		tempoTurno = 0f;
		sinalTolerancia = false;
		sinalTurno = false;
	}
	
	
}
