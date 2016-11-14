using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;

public class CongelarMao : MonoBehaviour {

	private RiggedHand maoGrafica;
	public Quaternion[] posicaoDedosDedao = new Quaternion[3];
	public Quaternion[] posicaoDedosIndicador = new Quaternion[3];
	public Quaternion[] posicaoDedosMedio = new Quaternion[3];
	public Quaternion[] posicaoDedosAnelar = new Quaternion[3];
	public Quaternion[] posicaoDedosMinimo = new Quaternion[3];
	public Quaternion[][] posicaoDedos = new Quaternion[5][];

	// Use this for initialization
	void Start () {
		maoGrafica = this.GetComponent<RiggedHand> ();
		posicaoDedos [0] = posicaoDedosDedao;
		posicaoDedos [1] = posicaoDedosIndicador;
		posicaoDedos [2] = posicaoDedosMedio;
		posicaoDedos [3] = posicaoDedosAnelar;
		posicaoDedos [4] = posicaoDedosMinimo;
	}
		
	public void Congelar(bool travado) {
		
		//Número de dedos que serão "travados", se o usuário escolher, os últimos dois dedos também serão
		int i = 3;	
		if (travado)
			i = 5;
		
		//Define a rotação de cada osso dos dedos igual às definidas
		for (int j = 0; j < i; j++) {
			for (int k = 0; k < 3; k++) {
				maoGrafica.fingers [j].bones [k+1].localRotation = posicaoDedos [j] [k];	
			}
		}
	}
}
