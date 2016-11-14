using UnityEngine;
using UnityEngine.Networking;

public class DeleteIfIsHost : NetworkBehaviour {
	[SerializeField]
	public Behaviour[] behaviours;

	public Behaviour delete;

	void Start () {
		if (isServer)
			for (int i = 0; i < behaviours.Length; i++) {
				behaviours [i].enabled = false;
			}
	}
}
