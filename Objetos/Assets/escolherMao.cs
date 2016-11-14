using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;

public class escolherMao : MonoBehaviour {

	public bool canhoto;
	public bool maoMasc;
	public bool peleMedia;
	public bool peleEscura;
	public bool dedosTravados;
	public bool alcançarSeringa;
	private LeapHandController controle;
	private Transform maos;
	private CongelarMao maoGrafica;
	private Transform maoAnterior;


	void Start() {
		controle = FindObjectOfType<LeapHandController> ();
		//Ativa e desativa todas as mãos, por algum motivo, somente assim era possível fazer a troca de mãos sem tirar a mão da frente do LeapMotion e colocar de volta
		for (int i = 0; i < 2; i++) { 
			for (int j = 0; j < 3; j++) {
				controle.transform.GetChild (i).GetChild (j).gameObject.SetActive (true);
				controle.transform.GetChild (i).GetChild (j).gameObject.SetActive (false);
			}
		}
	}

	void Update () {
		//Define qual mão irá pegar a seringa, se canhoto == true, a mão esquerda será ativada e a direita desativada, e vice-versa
		transform.GetChild (0).GetComponent<Pegar> ().escolhida (canhoto);
		transform.GetChild (1).GetComponent<Pegar> ().escolhida (!canhoto);

		//Copia o modelo de mão utilizado no último frame
		if (maos != null)
			maoAnterior = maos;

		//Escolhe qual modelo de mão será utilizado neste frame, dependendo da escolha do usuário
		if (maoMasc) {
			if (peleEscura)
				maos = controle.transform.GetChild (0).GetChild (2);
			else if (peleMedia)
				maos = controle.transform.GetChild (0).GetChild (1);
			else
				maos = controle.transform.GetChild (0).GetChild (0);
		} else {
			if (peleEscura)
				maos = controle.transform.GetChild (1).GetChild (2);
			else if (peleMedia)
				maos = controle.transform.GetChild (1).GetChild (1);
			else
				maos = controle.transform.GetChild (1).GetChild (0);
		}
			
		//Desativa o modelo do último frame, evitando que haja mais de um modelo ao mesmo tempo na cena
		if (maoAnterior != null) 
			maoAnterior.gameObject.SetActive (false);

		//Ativa o modelo escolhido
		maos.gameObject.SetActive (true);

		//Escolhe se a mão direita ou esquerda poderá ser congelada
		if (canhoto)
			maoGrafica = maos.GetChild (0).GetComponent<CongelarMao> ();
		else maoGrafica = maos.GetChild (1).GetComponent<CongelarMao> ();
	}

	//Chama a função de congelamento dos dedos
	public void Congelar() {
		maoGrafica.Congelar (dedosTravados);
	}

}
