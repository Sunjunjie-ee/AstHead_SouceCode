# AstHead_Souce

This is the source code of a game demo named <AstHead> and all the materials.
 ***
 ## Introduction
 This is a 2D survival shooting game demo for leaning Unity basic operation and scripting.
 
 All art resources come from the Unity Store's free materials named "Dungeon Crawler 2D Art Pack"
 The [Store Link](https://assetstore.unity.com/packages/templates/packs/dungeon-crawler-2d-art-pack-130827?locale=zh-EN) to the material store.
 
 The game scripts are written by myself.The scripts come with a lot of Chinese comments to make it easy to understand and you can add functions on that.
 
 This demo is for personal study and research purposes only, please do not use for commercial purposes.
 ***
 ## Scene
 There are three scenes, namely "Menu Scene", "Game Scene", and "Gameover Scene".
 
 | **Scene**|**Picture** |**Main Functions**|
 | --------------|:--------------: | :--------------:|
 | Menu Scene|<img width="200" height="150" src="https://raw.githubusercontent.com/YukinoKyoU/AstHead_SouceCode/main/Sample/Scene/Menu.png"/>|Click the "Play" button to start|
 | Main Scene|<img width="200" height="150" src="https://raw.githubusercontent.com/YukinoKyoU/AstHead_SouceCode/main/Sample/Scene/Main.jpg"/>|Press "ESC" to pause|
 | Over Scene|<img width="200" height="150" src="https://raw.githubusercontent.com/YukinoKyoU/AstHead_SouceCode/main/Sample/Scene/Over.jpg"/>|Click "Replay" to replay, or "Menu" to return to the main menu|
 
 ***
 ## How to play
 
 **"W","A","S","D"** control the direction of character movement, **"Q","E"** switch weapons. 
 
 Mouse control the direction of aiming, click the left mouse button to shoot.Bullets hitting the monster will have a knockback effect
 
 Kill monsters to score points. When the player runs out of life, the game ends.
 
 The monster drops the equipment box randomly after death, and one weapon is generated randomly in one equipment box.
 
 If the player already has this weapon, the weapon will be **reloaded**; otherwise, the weapon will be added to the player's arsenal.
 
 ### Monster
 
 | **Monster**|**Picture**|**Attack Way**|
 | --------------|:--------------: | :--------------:|
 | **Green Monster**|<img width="80" height="80" src="https://raw.githubusercontent.com/YukinoKyoU/AstHead_SouceCode/main/Sample/Monster/Monster1.png"/>|Melee attack monster|
 | **Vurple  Monster**|<img width="80" height="80" src="https://raw.githubusercontent.com/YukinoKyoU/AstHead_SouceCode/main/Sample/Monster/Monster2.png"/>|Fire a tracking bullet|
 
 ### Weapon
 
 | **Weapon**|**Picture**|**Attack Way**|
 | --------------|:--------------: | :--------------:|
 | Pistol|<img width="100" height="80" src="https://raw.githubusercontent.com/YukinoKyoU/AstHead_SouceCode/main/Sample/Weapon/Pistol.png"/>|Primary Weapon|
 | Assualt|<img width="100" height="80" src="https://raw.githubusercontent.com/YukinoKyoU/AstHead_SouceCode/main/Sample/Weapon/Assualt.png"/>|Fast Firing Speed|
 | Shotgun|<img width="100" height="80" src="https://raw.githubusercontent.com/YukinoKyoU/AstHead_SouceCode/main/Sample/Weapon/Shotgun.png"/>|Powerful, Scatter|
 
 
 Game demo video URL：https://www.bilibili.com/video/BV1QB4y1K71b/
 
 ***
 ## Script
 - GameController.cs : A single instance of Game is used to control the global game. Including player life values, scene switching control, etc.
 ```
 public class GameController : MonoBehaviour
 {
     public static GameController instance;             //GameController single instance
     public void UpdateAndDisplayScore(int enemyScore); //Update score
     public void LoadMenuScene();                       //Return to the menu function when paused
     public void LoadGameOverScene();                   //Load to GameOver scene function
     public void ClearState();                          //Restore static variables in a scene
 }
 ```
 - ObjectPool.cs : Generate monsters, bullets, shells and explosion effects using object pools. 
 ```
 public class ObjectPool
 {
     private static ObjectPool instance;                                                                       //Object pool singleton
     private Dictionary<string, Queue<GameObject>> objectPool = new Dictionary<string, Queue<GameObject>>();   //Dictionary of objects contained in the object pool
     public GameObject GetObject(GameObject prefab);                                                           //Generate or object objects
     public void PushObject(GameObject prefab);                                                                //Putting objects back into the object pool
 }
 ```
 
 **Empty the object pool when switching scenes!!!**
 ```
 public void clear()
 {
     objectPool.Clear();      //Clear the object pool
 }
 ```
 Object pooling code reference: [video address](https://www.bilibili.com/video/BV1xb4y1D7PZ)
 
 ## TO DO：
 1. Add more monster
 2. Add more Weapon and Effect
 3. Try to add some "skills" to Character
 4. Try to make multiplayer games
 
 
 

 
 
 
 
