using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateParticles : MonoBehaviour {
    public GameObject firework;
    public GameObject romenCandle;
    private MeshRenderer candleRenderer;
    public Transform firePoint;
    public GameObject[] fireworks;
    public Material[] romenCandleColor;
    private int index = 0;
    public ParticleSystem[] flares;
    public ParticleSystem currFlare;
    private Vector3 flarePos;

    void Start() {
        candleRenderer = romenCandle.GetComponent<MeshRenderer>();
    }

    void Update () {

        //Maintain Flare Position when Controller moves
        flarePos = currFlare.transform.position;
        flares[index].transform.position = flarePos;

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            flares[index].Play();
            Instantiate(firework, firePoint.position, this.transform.rotation);
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {
            index++;
            while (index >= fireworks.Length && index >= romenCandleColor.Length)
            {
                index = 0;
            }
            candleRenderer.material = romenCandleColor[index];
            firework = fireworks[index];
        }

        //Test locally with mouse since there isn't a good way with OculusGo within Unity
        //Acts as controller trigger
        if (Input.GetMouseButtonDown(1))
        {
            flares[index].Play();
            Instantiate(firework, firePoint.position, this.transform.rotation);
        }
        //Test locally with mouse since there isn't a good way with OculusGo within Unity
        //Acts as controller touchpad
        if (Input.GetMouseButtonDown(2))
        {
            index++;
            while (index >= fireworks.Length && index >= romenCandleColor.Length)
            {
                index = 0;
            }
            candleRenderer.material = romenCandleColor[index];
            firework = fireworks[index];
        }
    }
}
