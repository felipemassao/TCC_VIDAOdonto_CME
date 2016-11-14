using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour {

	[SerializeField]
	Behaviour[] componentesDesativados;

	void start() {
		if (!isLocalPlayer) {
			for (int i = 0; i < componentesDesativados.Length; i++) {
				componentesDesativados [i].enabled = false;
			}
		}
	}
}
