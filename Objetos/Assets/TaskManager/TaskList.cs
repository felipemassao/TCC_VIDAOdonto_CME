using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskList : MonoBehaviour {

	public static TaskList instance = null;
	int taskNumber;
	bool isDone;
	Dictionary<string, bool> notificationList = new Dictionary<string, bool>();

	void Awake(){

		if (instance == null) //Check if instance already exists
			instance = this; //If not, set instance to this
		else if (instance != this) //If already exist and it is not this
			Destroy (gameObject); //Then destroy this, enforcing the Singleton Pattern

		DontDestroyOnLoad (gameObject);

	}

	void Start () {
		
		taskNumber = 1;
		getNotificationList (taskNumber);

	}

	void Update () {

		isDone = true; foreach (KeyValuePair<string, bool> kvp in notificationList) {

			if (notificationList [kvp.Key] == false) {
				isDone = false;
				//Debug.Log ("false");
			}
		}
			
		if (isDone)
			nextTask();
	}

	void getNotificationList(int number){

		switch (number) {
			
		case 1:
			notificationList.Add ("PutCap", false); //Colocar touca
			notificationList.Add ("PutGloves", false); //Colocar luvas
			break;

		case 2:
			notificationList.Add ("Task2", false);
			break;
		}
	}

	void nextTask(){
		
		notificationList.Clear ();
		taskNumber++;
		getNotificationList (taskNumber);

	}

	public void notify( string notification){
		
		if (notificationList.ContainsKey (notification))
			notificationList [notification] = true;

		Debug.Log (notificationList [notification]);
		
	}
}