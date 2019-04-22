using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveSnake : MonoBehaviour{

    GameObject selectionMenu;

    public Text fireCount;
    public Text lightningCount;
    public Text iceCount;
    public Text rockCount;
    public Text goldCount;
    public Text nameOne;
    public Text nameTwo;
    public Text nameThree;
    public Text nameFour;
    public Text nameFive;
    public Text nameSix;
    public Text nameSeven;
    public Text nameEight;

    public Rigidbody2D rb;

    private void Start(){
        selectionMenu = GameObject.Find("SaveScreen");
        selectionMenu.gameObject.SetActive(false);
    }

    void Update(){
        
    }

    private void OnTriggerStay2D(Collider2D collision){
        if (collision.CompareTag("player")){
            if (Input.GetKeyDown(KeyCode.E)){
                selectionMenu.gameObject.SetActive(true);
            }
        }
    }
    
    public void SaveGame(int spawn){
        string currentLevel = this.gameObject.tag;

        PlayerPrefs.SetString("Level", currentLevel);
        PlayerPrefs.SetInt("Spawn", spawn);
        PlayerPrefs.SetString("Gold",goldCount.text);
        PlayerPrefs.SetString("Fire", fireCount.text);
        PlayerPrefs.SetString("Lightning", lightningCount.text);
        PlayerPrefs.SetString("Ice", iceCount.text);
        PlayerPrefs.SetString("Rock", rockCount.text);
        PlayerPrefs.SetString("Slot1", nameOne.text);
        PlayerPrefs.SetString("Slot2", nameTwo.text);
        PlayerPrefs.SetString("Slot3", nameThree.text);
        PlayerPrefs.SetString("Slot4", nameFour.text);
        PlayerPrefs.SetString("Slot5", nameFive.text);
        PlayerPrefs.SetString("Slot6", nameSix.text);
        PlayerPrefs.SetString("Slot7", nameSeven.text);
        PlayerPrefs.SetString("Slot8", nameEight.text);
    }

    public void LoadGame(){
        string level = PlayerPrefs.GetString("Level", "None");
        string fire = PlayerPrefs.GetString("Fire");
        string lightning = PlayerPrefs.GetString("Lightning");
        string ice = PlayerPrefs.GetString("Ice");
        string rock = PlayerPrefs.GetString("Rock");
        string slot1 = PlayerPrefs.GetString("Slot1");
        string slot2 = PlayerPrefs.GetString("Slot2");
        string slot3 = PlayerPrefs.GetString("Slot3");
        string slot4 = PlayerPrefs.GetString("Slot4");
        string slot5 = PlayerPrefs.GetString("Slot5");
        string slot6 = PlayerPrefs.GetString("Slot6");
        string slot7 = PlayerPrefs.GetString("Slot7");
        string slot8 = PlayerPrefs.GetString("Slot8");
        string gold = PlayerPrefs.GetString("Gold");
        string spawn = PlayerPrefs.GetString("Spawn");

        gold = gold.Substring(0, (gold.Length - 1));

        Debug.Log("Starting LOAD process");
        //Loading Gold
        int gold2 = 0;
        try{
            gold2 = System.Convert.ToInt32(gold);
        }
        catch (IOException) {
            Debug.Log("Something wrong with LOAD - GOLD");
        }
         GoldManager.AddGold(gold2);
        Debug.Log("Loading completed: GOLD");

        //Loading Skills
        int fire2 = 0;
        int lightning2 = 0;
        int ice2 = 0;
        int rock2 = 0;
        try{
            fire2 = System.Convert.ToInt32(fire);
        }
        catch (IOException){
            Debug.Log("Something wrong with LOAD - FIRE");
        }
        try{
            lightning2 = System.Convert.ToInt32(lightning);
        }catch (IOException){
            Debug.Log("Something wrong with LOAD - LIGHTNING");
        }
        try{
            ice2 = System.Convert.ToInt32(ice);
        }catch (IOException){
            Debug.Log("Something wrong with LOAD - ICE");
        }
        try{
            rock2 = System.Convert.ToInt32(rock);
        }catch (IOException){
            Debug.Log("Something wrong with LOAD - ROCK");
        }
        MovementScript.fireCount = fire2;
        MovementScript.lightningCount = lightning2;
        MovementScript.iceCount = ice2;
        MovementScript.rockCount = rock2;

        Debug.Log("Loading completed: SKILLS");

        //Loading inventory
        if(slot1 != "Empty"){
            InventoryScript.addItem(slot1);
        }
        if(slot2 != "Empty"){
            InventoryScript.addItem(slot2);
        }
        if (slot3 != "Empty"){
            InventoryScript.addItem(slot3);
        }
        if (slot4 != "Empty"){
            InventoryScript.addItem(slot4);
        }
        if (slot5 != "Empty"){
            InventoryScript.addItem(slot5);
        }
        if (slot6 != "Empty"){
            InventoryScript.addItem(slot6);
        }
        if (slot7 != "Empty"){
            InventoryScript.addItem(slot7);
        }
        if (slot8 != "Empty"){
            InventoryScript.addItem(slot8);
        }
        Debug.Log("Loading completed: INVENTORY");
        //Loading location
        switch (spawn){
            case "1":
                Vector2 vec = new Vector2(25, -1.7f);
                rb.MovePosition(vec);
                Debug.Log("Moved player");
                break;
            default:
                break;
        }
        Debug.Log("Loading completed: SPAWN POINT");
    }
}