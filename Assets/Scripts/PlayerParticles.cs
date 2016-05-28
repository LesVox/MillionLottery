using UnityEngine;
using System.Collections;

public class PlayerParticles : MonoBehaviour {
	public GameObject DigNorth;
	public GameObject DigEast;
	public GameObject DigSouth;
	public GameObject DigWest;

	private ParticleSystem[] DigNorthParticles;
	private ParticleSystem[] DigEastParticles;
	private ParticleSystem[] DigSouthParticles;
	private ParticleSystem[] DigWestParticles;

	void Start () {
		DigNorthParticles = DigNorth.GetComponentsInChildren<ParticleSystem> ();	
		DigEastParticles = DigEast.GetComponentsInChildren<ParticleSystem> ();	
		DigSouthParticles = DigSouth.GetComponentsInChildren<ParticleSystem> ();	
		DigWestParticles = DigWest.GetComponentsInChildren<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		CheckParticles ();
	}

	void SetParticleEmission(ParticleSystem[] particles, bool enabled){
		
		for (int i = 0; i < particles.Length; i++) {
			var emitter = particles[i].emission;
			emitter.enabled = enabled;
		}
	}

	void CheckParticles(){
		if (Player.instance.IsMoving) {
			switch (Player.instance.Facing) {
			// Digging North
			case 3:
				SetParticleEmission (DigNorthParticles, true);
				SetParticleEmission (DigEastParticles, false);
				SetParticleEmission (DigSouthParticles, false);
				SetParticleEmission (DigWestParticles, false);
				break;
			// Digging East
			case 4:
				SetParticleEmission (DigNorthParticles, false);
				SetParticleEmission (DigEastParticles, true);
				SetParticleEmission (DigSouthParticles, false);
				SetParticleEmission (DigWestParticles, false);
				break;
			// Digging South
			case 1:
				SetParticleEmission (DigNorthParticles, false);
				SetParticleEmission (DigEastParticles, false);
				SetParticleEmission (DigSouthParticles, true);
				SetParticleEmission (DigWestParticles, false);
				break;
			// Digging West
			case 2:
				SetParticleEmission (DigNorthParticles, false);
				SetParticleEmission (DigEastParticles, false);
				SetParticleEmission (DigSouthParticles, false);
				SetParticleEmission (DigWestParticles, true);
				break;
			default:
				break;
			}
		} else {
			SetParticleEmission (DigNorthParticles, false);
			SetParticleEmission (DigEastParticles, false);
			SetParticleEmission (DigSouthParticles, false);
			SetParticleEmission (DigWestParticles, false);
		}
	}
}
