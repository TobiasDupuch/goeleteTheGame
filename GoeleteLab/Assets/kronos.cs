using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kronos : MonoBehaviour {
	private int lastMinute = 0;

	public float dayInMinutes = 24;
	public float startTime = 0;

	[Space(10)]
	public float timesFaster;
	public int day = 0;
	public int hour = 0;
	public int minute = 0;
	public GameObject theSun;

	// Use this for initialization
	void Start () {
		timesFaster = 1440 / dayInMinutes;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (hour +" "+ minute);

		if (minute == lastMinute + 1) {
			doEveryMinute ();
			lastMinute = minute;
		}

		if (Time.frameCount % 2 == 0)
		{
			
			theSun.transform.eulerAngles = new Vector3(((Mathf.FloorToInt(Time.time / 60 * timesFaster))*0.25f-90),0,0);
		}

		minute = (Mathf.FloorToInt(Time.time / 60 * timesFaster))-((Mathf.FloorToInt (Time.time / 3600 * timesFaster))*60);
		hour = (Mathf.FloorToInt (Time.time / 3600 * timesFaster))-(Mathf.FloorToInt (Time.time / 86400 * timesFaster)*24);
		day = Mathf.FloorToInt (Time.time / 86400 * timesFaster);

	}

	void doEveryMinute (){    //doesn't really work on short days

	}
}
