using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class CarregarCena : MonoBehaviour {

	public string cenaConsultorio = "Consultorio_OVR+Leap";
	public Text texto; // Arraste o texto do nome do usuário aqui

	private static string nomeUsuario;
	private static bool replay;

	void Start () {
		DontDestroyOnLoad (this);
		replay = false;
	}
		
	public void refreshNome() {
		if (texto) nomeUsuario = texto.GetComponent<Text> ().text;
	}

	public void carregarCena() {
		SceneManager.LoadScene (cenaConsultorio);
	}

	public void toogleReplay() {
		replay = !replay;
	}


	public static string getNome() {
		if (nomeUsuario != null)
			return nomeUsuario;
		else
			return "Não_preencheu";
	}

	public static bool getReplay() {
		return replay;
	}

}
