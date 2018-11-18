using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour 
{
	public float m_speed; //speed of translation

	private float m_mouseInput; //mouse movement input
	private float m_moveHorizontal; //keyboard input 1
	private float m_moveVertical; //keyboard input 2

	private bool b_newStart; //to know if Gladiator is being switched on

	//these variables are to know where their respective audio is playing or not
	//	private bool b_engineStarting; 
	//	private bool b_engineWorking;
	//	private bool b_engineIdle;
	//	private bool b_engineStopping;

	public AudioSource au_movementAudio;
	public AudioClip au_engineStarting;
	public AudioClip au_engineWorking;
	public AudioClip au_engineStopping;
	//	public AudioClip au_engineIdle;

	private float m_originalPitch;
	private float m_pitchRange;

	// Use this for initialization
	void Start () 
	{
		//b_newStart if True then the tank is moving
		b_newStart = true;

		//		b_engineStarting = false;
		//		b_engineIdle = false;
		//		b_engineWorking = false;

		m_pitchRange = 0.5f;

		//Assigning the au_engineIdle
		//au_movementAudio.clip = au_engineWorking;

		//taking the original pitch
		//		m_originalPitch = au_movementAudio.pitch;
		//
		//		//Slowing down the audio
		//		au_movementAudio.pitch = m_originalPitch - m_pitchRange;
		//
		//		//Copying the audio clip into the required one
		//		au_engineIdle = au_movementAudio.clip;

		//Assigning another audio to the AudioSource
		//au_movementAudio.clip = au_engineStarting;
	}

	// Update is called once per frame
	void Update () 
	{
		m_moveHorizontal = m_speed * Input.GetAxis ("Horizontal") * Time.deltaTime;
		m_moveVertical = m_speed * Input.GetAxis ("Vertical") * Time.deltaTime;

		m_mouseInput = m_mouseInput + m_speed * Input.GetAxis ("Mouse X");

		EngineAudio ();

		transform.eulerAngles = new Vector3 (0f,m_mouseInput,0f);
		transform.Translate (m_moveHorizontal, 0f, m_moveVertical);
	}

	void EngineAudio ()
	{
		//If there is no movement at all
		if ((m_moveHorizontal == 0) && (m_moveVertical == 0)) 
		{
			//			//If Gladiator has already been started then play engineIdle audio
			if (!b_newStart)
			{
				//				print ("Engine Idle");
				//If engineWorking audio playing then change it to engineIdle audio
				if (!au_movementAudio.isPlaying)
				{
					au_movementAudio.clip = au_engineWorking;
					//					au_movementAudio.pitch = au_movementAudio.pitch - m_pitchRange;
					au_movementAudio.Play ();
					//					print (au_movementAudio.isPlaying);
				}
			}
		}

		//If there is even a slightest movement in the Gladiator the music needs to be played
		else
		{
			//If the Gladiator is starting newly then play the engineStarting audio
			if (b_newStart)
			{
				//				au_movementAudio.Play ();
				//				print ("Engine Starting");

				if (!au_movementAudio.isPlaying) 
				{
					au_movementAudio.clip = au_engineStarting;
					au_movementAudio.Play ();
				}

				//not allowing the player to move while the engine starts
				m_moveHorizontal = 0;
				m_moveVertical = 0;

				//Set the boolean m_newStart to false as the Gladiator has started
				b_newStart = false;
			}

			//If Gladiator has already started then play the engineWorking audio
			else
			{
				//If the movementAudio is playing engineStarting audio then should be changed to engineWorking audio
				//				if (au_movementAudio.clip == au_engineStarting) 
				if (!au_movementAudio.isPlaying)
				{
					au_movementAudio.clip = au_engineWorking;
					//					au_movementAudio.Play ();

					au_movementAudio.Play ();
					//					print ("Engine Working");
				}
			}
		}
	}
}