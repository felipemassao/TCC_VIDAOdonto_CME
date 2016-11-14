using UnityEngine;
using System.Collections;
using System;

public class Avaliação : MonoBehaviour {
	
	public GameObject seringa; // Arraste a seringa do háptico aqui se possível. Caso contrário, atribua a varíavel na função Start.
	public GameObject planoDeReferencia; // Arraste o plano de referencia aqui.
	public float periodoDaColeta = 0.1f; // default

	private bool modoReplay;
	private bool inicio;
	private bool termino;
	private bool atingiu;
	private bool imprimiu;

	private bool seringaDetectada;
	private float deltaTempo;

	/* Dados obtidos no experimento */
	private float tempo;
	private float anguloInjecao;
	private Vector3 velocidade;
	private Vector3 ultimaPosicao;
	private ArrayList listaTempo;
	private ArrayList listaVelocidade;
	private ArrayList listaPosicao;
	private ArrayList listaRotacao;

	private string endereco;
	private string texto;

	void Start () {
		tempo = 0;
		velocidade = new Vector3 (0, 0, 0);
		ultimaPosicao = seringa.transform.position;
		inicio = false;
		termino = false;

		// O relatório do experimento é salvo numa pasta gerada no Desktop, com o nome VIDAOdonto
		endereco = string.Concat(System.Environment.GetFolderPath (System.Environment.SpecialFolder.DesktopDirectory), "\\VIDAOdonto\\");
		// Seu nome é o nome de usuário + horário do experimento
		endereco = string.Concat (@endereco, CarregarCena.getNome());
		endereco = string.Concat (@endereco, System.DateTime.Now.ToString ("_HH_mm_ss"));
		endereco = string.Concat (@endereco, ".txt");

		// Se está no modo de REPLAY, cria arrays para armazenar os dados
		modoReplay = CarregarCena.getReplay();

		if (modoReplay) {
			listaTempo = new ArrayList();
			listaPosicao = new ArrayList ();
			listaRotacao = new ArrayList ();
			listaVelocidade = new ArrayList ();
		}
	}

	void Update() {
		// TODO Atribuir ao bool seringaDetectada alguma função do Háptico que diga se há uma seringa na cena 
		// Teoricamente, sempre há a seringa do háptico na cena, a não ser que ele perca conexão ou, futuramente, haja um método para pegar a seringa
		seringaDetectada = seringa;

		// Cálculo da velocidade
		if (seringaDetectada) {
			deltaTempo = Time.deltaTime;
		} else {
			deltaTempo += Time.deltaTime;
		}
		velocidade = seringa.transform.position - ultimaPosicao;
		if (seringaDetectada)
			ultimaPosicao = seringa.transform.position;

		if (!inicio && Input.GetKeyDown (KeyCode.S)) { // Por enquanto, a condição para início da contagem é uma hotkey. Pode ser alterado.
			inicio = true;
			InvokeRepeating ("gravacao", 0, periodoDaColeta); 
			InvokeRepeating ("iniciaCronometro", 0, periodoDaColeta); 

			texto += CarregarCena.getNome() + ", dados obtidos: " + Environment.NewLine + "tempo, posição, rotação, velocidade" + Environment.NewLine;
		}

		if (inicio && !termino && (Input.GetKeyDown(KeyCode.F))) {
			termino = true;
			atingiu = false;
		}	

		if (inicio && termino && !imprimiu) {
			if (atingiu) { 
				texto += "Acertou na regiao certa: " + anguloInjecao.ToString("F2") + " graus" + Environment.NewLine;
			} else { 
				texto += "Não acertou" + Environment.NewLine;
			}
			using (System.IO.StreamWriter file = 
				new System.IO.StreamWriter(@endereco, true)) {
					file.WriteLine (texto);
				}
			imprimiu = true;
		} 
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject == seringa) {
			termino = true;
			atingiu = true;
			anguloInjecao = Vector3.Angle (planoDeReferencia.transform.up, seringa.transform.up);
			texto += "Acerto: " + tempo.ToString("F2") + " " + seringa.transform.position.ToString ("F4") 
				+ " " + seringa.transform.eulerAngles.ToString ("F4") + " " + velocidade.ToString ("F4") + Environment.NewLine;
		}
	}

	void gravacao () {
		// https://msdn.microsoft.com/pt-br/library/8bh11f1k.aspx
		if (!termino) {
			if (seringaDetectada) {
				texto += tempo.ToString("F2") + " " + seringa.transform.position.ToString ("F4") 
					+ " " + seringa.transform.eulerAngles.ToString ("F4") + " " + velocidade.ToString ("F4") + Environment.NewLine;
				if (modoReplay) {
					listaTempo.Add (tempo);
					listaPosicao.Add (seringa.transform.position);
					listaRotacao.Add(seringa.transform.rotation); // É dado em quaternion!
					listaVelocidade.Add (velocidade);
				}
			}
		}
	}

	void iniciaCronometro () {
		if (!termino) tempo += periodoDaColeta;
	}
}