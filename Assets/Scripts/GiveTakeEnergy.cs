using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveTakeEnergy : MonoBehaviour {

	public float transferTime = 1f;

	float timeHolding = 0f;
	bool inHold = false;
	bool transfered = false;

	void Update(){
		if(inHold){
			if (Input.GetKeyUp (KeyCode.E)) {
				inHold = false;
				timeHolding = 0f;
			} else {
				timeHolding += Time.deltaTime;
			}
		}

		if (inHold && timeHolding > transferTime) {
			transfered = true;
			timeHolding = 0f;
			inHold = false;
		}
	}

	void OnTriggerStay(Collider collider){
		if (collider.gameObject.GetComponent<EnergyStored> ()) {
			if (transfered) {
				//Taking Energy
				if (collider.gameObject.GetComponent<EnergyStored> ().numEnergy == 1) {
					GetComponent<EnergyStored> ().numEnergy++;
					collider.gameObject.GetComponent<EnergyStored> ().numEnergy = 0;
					//Giving Energy
				} else if (GetComponent<EnergyStored> ().numEnergy > 0) {
						GetComponent<EnergyStored> ().numEnergy--;
						collider.gameObject.GetComponent<EnergyStored> ().numEnergy = 1;
				}

				transfered = false;
			} else {
				//Taking Energy
				if (collider.gameObject.GetComponent<EnergyStored> ().numEnergy == 1) {
					if (Input.GetKeyDown (KeyCode.E)) {
						inHold = true;
					}
				}
				//Giving Energy
				else {
					if (GetComponent<EnergyStored> ().numEnergy > 0) {
						if (Input.GetKeyDown (KeyCode.E)) {
							inHold = true;
						}
					}
				}
			}

		}
	}
		
}
