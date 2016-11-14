using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class Pegar : MonoBehaviour {

	private HandModel hand;
	private Seringa seringa;
	private Vector3[] dedos = new Vector3[4];
	private float[] distancias = new float[4];
	private bool pegou;
	private Vector3 dedo;
	private float distancia;
	public float distMinPegar;
	public float distMinSoltar;
	public float distBaseSeringa;
	public Vector3 distSeringa;
	public Quaternion rotSeringa;
	private Vector3 baseSeringaPosition;
	private Quaternion baseSeringaRotation;
	private bool maoCerta;


	// Use this for initialization
	void Start () {
		baseSeringaPosition = new Vector3 (0.57f, 0.69f, -0.36f);	//Posição no mundo da Base da Seringa
		baseSeringaRotation = new Quaternion (1, 0, 0, 1);	//Rotação da Seringa quando na Base
		seringa = FindObjectOfType<Seringa> ();
	}

	// Update is called once per frame
	void Update () {
		hand = transform.GetComponent<HandModel> ();

		//Somente deve funcionar na mão escolhida, direita ou esquerda
		if (maoCerta) {		
			for (int i = 0; i < 2; i++) {
				dedos [i] = hand.fingers [i + 1].GetBoneCenter (3);
				distancias [i] = (dedos [i] - hand.GetPalmPosition ()).magnitude;	//distâncias dos dedos à palma da mão
			}

			//Verifica se a mão está fechada e próxima da base ou se o usuário quer ter que alcançar a seringa para pega-la
			if (pegando ()) {	
				if ((hand.GetPalmPosition () - baseSeringaPosition).magnitude < distBaseSeringa || !GetComponentInParent<escolherMao> ().alcançarSeringa) {
					pegou = true;
				}
			}

			//"Prende" a seringa à palma da mão, utilizando sua posição e rotação + ajustes
			if (pegou) {	
				seringa.transform.position = hand.GetPalmPosition () + hand.GetPalmNormal () * distSeringa.x + Vector3.Cross (hand.GetPalmDirection (), hand.GetPalmNormal ()).normalized * distSeringa.y + hand.GetPalmDirection () * distSeringa.z;
				seringa.transform.rotation = hand.GetPalmRotation () * rotSeringa;
				GetComponentInParent<escolherMao> ().Congelar ();
			} 

			//Solta a seringa de volta a base
			else {	
				seringa.transform.position = baseSeringaPosition;
				seringa.transform.rotation = baseSeringaRotation;
			}

			//Verifica se a mão está aberta e próxima da base da seringa ou se o usuário quer soltar a seringa a qualquer momento
			if (soltando ()) {
				if ((hand.GetPalmPosition () - baseSeringaPosition).magnitude < distBaseSeringa || !GetComponentInParent<escolherMao> ().alcançarSeringa) {
					pegou = false;
				}
			}
		}
	}

	public void escolhida(bool escolheu) { //Verifica se a mão é a escolhida para pegar a seringa
		maoCerta = escolheu;
	}


	bool pegando() {	//Verifica se a mão está "fechada", com os dedos próximos o suficiente da palma da mão
		for (int i = 0; i < 2; i++) {
			if (distancias [i] > distMinPegar)
				return false;
		}
		return true;
	}

	bool soltando(){	//Verifica se a mão está "aberta", com os dedos longe o suficiente da palma da mão
		for (int i = 0; i < 2; i++) {
			if (distancias [i] < distMinSoltar)
				return false;
		}
		return true;
	}
}
