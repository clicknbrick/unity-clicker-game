using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCounter : MonoBehaviour {

	//public int Gold = 0;
	public Text TextGold;

	public Camera MainCamera;

	// Use this for initialization
	void Start () {
	
		StartCoroutine(StartGoldCount());
		NotificationCenter.Instance.Add("GoldUpate", this.UpdateGoldText);
	}

	public void UpdateGoldText() {
		TextGold.text = DataController.Instance.gameData.Gold.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			DataController.Instance.gameData.Gold += DataController.Instance.gameData.GoldPerSec;
			TextGold.text = DataController.Instance.gameData.Gold.ToString();

			Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit,100f)) {
				GameObject StarSFX = Resources.Load("Prefabs/Stars") as GameObject;
				Instantiate (StarSFX, hit.point, new Quaternion());
			}
		}
	}

	// 
	IEnumerator StartGoldCount() {
	
		while(true)
		{
			yield return new WaitForSecondsRealtime(1f);

			//Gold++;
			DataController.Instance.gameData.Gold += DataController.Instance.gameData.GoldPerSec;
			TextGold.text = DataController.Instance.gameData.Gold.ToString();
			DataController.Instance.SaveGameData();
		
		}
	}
}
