using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kronos : MonoBehaviour {
	private int lastMinute = 0;
	private Light sunLight;
	private int minutesSinceSunrise;
	private int minutesSinceMidnight;

	public float dayInMinutes = 24;
	public float startTime = 0;
	public int sunriseHour = 5;
	public int morningHour = 7;
	public int noonHour = 12;
	public int eveningHour = 17;
	public int nightHour = 20;

	public Color morningColor;
	public Color noonColor;
	public Color eveningColor;
	public Color nightColor;

	[Space(10)]
	public float timesFaster;
	public int day = 0;
	public int hour = 0;
	public int minute = 0;
	public GameObject theSun;

	// Use this for initialization
	void Start () {
		timesFaster = 1440 / dayInMinutes;
		sunLight = theSun.GetComponent<Light>();
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (hour +" "+ minute);

		minutesSinceMidnight = (Mathf.FloorToInt(Time.time / 60 * timesFaster))-(day*1440);
		minutesSinceSunrise = (Mathf.FloorToInt(Time.time / 60 * timesFaster))-(60*sunriseHour)-(day*1440);


		if (minute == lastMinute + 1) {
			doEveryMinute ();
			lastMinute = minute;
		}

		if (Time.frameCount % 2 == 0)	{
			if (hour < sunriseHour-1) {
				theSun.transform.eulerAngles = new Vector3(-26,0,0);
			}
			else {
				theSun.transform.eulerAngles = new Vector3(-26+(minutesSinceSunrise/4.4f),0,0);
			}

			doDaylighColors();
		}

		minute = (Mathf.FloorToInt(Time.time / 60 * timesFaster))-((Mathf.FloorToInt (Time.time / 3600 * timesFaster))*60);
		hour = (Mathf.FloorToInt (Time.time / 3600 * timesFaster))-(Mathf.FloorToInt (Time.time / 86400 * timesFaster)*24);
		day = Mathf.FloorToInt (Time.time / 86400 * timesFaster);

	}

	void doEveryMinute (){    //doesn't really work on short days

	}

	void doDaylighColors(){
		if (minutesSinceMidnight > sunriseHour*60 && minutesSinceMidnight < morningHour*60) {
			sunLight.color = Color.Lerp(nightColor,morningColor,(1f/((morningHour-sunriseHour)*60))*(minutesSinceMidnight-sunriseHour*60));
			Debug.Log((1f/((morningHour-sunriseHour)*60))*(minutesSinceMidnight-sunriseHour*60));
		}
		if (minutesSinceMidnight > morningHour*60 && minutesSinceMidnight < noonHour*60) {
			sunLight.color = Color.Lerp(morningColor,noonColor,(1f/((noonHour-morningHour)*60))*(minutesSinceMidnight-morningHour*60));
		}
		if (minutesSinceMidnight > noonHour*60 && minutesSinceMidnight < eveningHour*60) {
			sunLight.color = Color.Lerp(noonColor,eveningColor,(1f/((eveningHour-noonHour)*60))*(minutesSinceMidnight-noonHour*60));
		}
		if (minutesSinceMidnight > eveningHour*60 && minutesSinceMidnight < nightHour*60) {
			sunLight.color = Color.Lerp(eveningColor,nightColor,(1f/((nightHour-eveningHour)*60))*(minutesSinceMidnight-eveningHour*60));
		}
	}
}
