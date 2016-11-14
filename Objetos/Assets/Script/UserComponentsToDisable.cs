using UnityEngine;
using UnityEngine.Networking;

public class UserComponentsToDisable : NetworkBehaviour {

	[SerializeField]
	Behaviour[] componentesDesativadosPeloClient;

	[SerializeField]
	Behaviour[] componentesDesativadosPeloHost;

	void Start () {
		if (isClient && !isServer) {
			for (int i = 0; i < componentesDesativadosPeloClient.Length; i++) { 
				componentesDesativadosPeloClient [i].enabled = false;
			}
		}

		if (isServer) {
			for (int i = 0; i < componentesDesativadosPeloHost.Length; i++) { 
				componentesDesativadosPeloHost[i].enabled = false;
			}
		}
	}
}
