using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlace : MonoBehaviour
{
    public Text Coordinates;
    public float MarginOfError;
    private float CurrentLat;
    private float CurrentLong;

    private void Update()
    {
        CurrentLat = LocationTracker.Instance.latitude;
        CurrentLong = LocationTracker.Instance.longitude;
        Coordinates.text = CurrentZone(CurrentLat, CurrentLong) + "    Lat:" + CurrentLat.ToString() + "     Lon:" + CurrentLong.ToString();
    }

    private string CurrentZone(float Lat, float Long)
    {
        // Checks if latitude and longitude is in range
        // Note: Put smallest lat/long first, then greater lat/long
        if (Lat >= 37.5507 - MarginOfError && Lat <= 37.5517 - MarginOfError && Long >= 126.9436 - MarginOfError && Long <= 126.9440 + MarginOfError)
        {
            return "Gonzaga Hall";
        }
        // Buildings by X Hall, strip of buildings by J Hall, K hall, and Arrupe
        else if (Lat >= 37.5512 - MarginOfError && Lat <= 37.5519 && Long >= 126.9426 - MarginOfError && Long <= 126.9437 + MarginOfError ||
            Lat >= 37.5499 - MarginOfError && Lat <= 37.5507 + MarginOfError && Long >= 126.9428 - MarginOfError && Long <= 126.9437 + MarginOfError ||
            Lat >= 37.5498 - MarginOfError && Lat <= 37.5504 + MarginOfError && Long >= 126.9396 - MarginOfError && Long <= 126.9406 + MarginOfError ||
            Lat >= 37.5496 - MarginOfError && Lat <= 37.5503 + MarginOfError && Long >= 126.9388 - MarginOfError && Long <= 126.9390 + MarginOfError)
        {
            return "Classroom";
        }
        // GS25, Gonzaga Plaza, Cafeteria
        else if (Lat >= 37.5509 - MarginOfError && Lat <= 37.5510 + MarginOfError && Long >= 126.9436 - MarginOfError && Long <= 126.94440 + MarginOfError
                || Lat >= 37.5505 - MarginOfError && Lat <= 37.5512 + MarginOfError && Long >= 126.9431 - MarginOfError && Long <= 126.9435 + MarginOfError
                || Lat >= 37.5502 - MarginOfError && Lat <= 37.5509 + MarginOfError && Long >= 126.9387 - MarginOfError && Long <= 126.9391)
        {
            return "Eating Area";
        }
        else if (Lat >= 37.5503 - MarginOfError && Lat <= 37.5508 + MarginOfError && Long <= 126.9406 - MarginOfError && Long >= 126.9421 + MarginOfError)
        {
            return "Field";
        }


        return "Hasn't been mapped";
    }
}
