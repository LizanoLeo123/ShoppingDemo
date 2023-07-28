# ShoppingDemo
Game Made by Leonardo Lizano using free game assets. 
Game made with no profit intended
Interview test for Blue Gravity Studios evaluation

## Available build
In the Builds folder, unzip the file and play the executable application.

## Summary

For this project I set up the basic folders structure I usually like to use for Unity projects

**GAME FOLDER**
 - Scripts
 - Prefabs
 - Sprites
 - Etc

Plugins
ETC

There are two main scenes that work together with the multiple game systems. For this demonstration I set up a **Main Menu** and a **Demo City** level, **you can pause with ESC** and return to the Main Menu at any moment. In the Demo City level there is the main player (player can move around in any direction), the game starts with a direct prompt on what to do, showing the first feature the **Dialogue System**. **On the top left corner there is a Bag icon that lets the open its own inventory** showing what you have on your bag. Player can move around, **interact (E Key)** with objects and NPCs. There is a rock in the middle of the ground and **you can talk to the clothing store shopkeeper**. Once you meet her, the store panel will appear, and you will be able to sell your items and purchase store items. Store has its own inventory and it fetches the data from your inventory. Two different systems to mention here, the **PlayerInventory, Inventory and Item** classes work by themselves. Then I set up the **Shop System** and inventory on top of that. Once you talk to the store dependent you will notice that by even selling your stuff you won't have enough money to buy the armors. You should take a look around the town to figure out what to do ;) Once you figure out how to get the armor, **you can open your inventory and equip your new clothes**. Move around and interact with objects and you'll see your new clothing. Get Back to the Main Menu and you might notice something different. I used **Playerprefs** to save the current skin number and use that for the dialogue system and for the Main Menu. Not all code uses the most professional and optimal solutions for this problem due to time limitation but everything works. If it's dumb but it works, then it's not dumb. All systems functionality is stored in their own folders and there are many comments within the code to clarify some stuff.

Not all code was made by me. I use youtube tutorials for the Tilemaps (Brackeys), Customizable Characters (Ken "GoldenEvolution" on YT) , Inventory (Code Monkey), etc.

**IMPORTANT THINGS TO NOTICE**
All level Dialogues are saved on a Scriptable object called DialoguesData. -> Scripts/DialogueSystem
All Game Items are saved on a Scriptable Object called ItemsData. -> Scripts/Inventory

I use SourceTree to manage my repositories and the final version of the project look like this
![image](https://github.com/LizanoLeo123/ShoppingDemo/assets/26804692/6a9c82d8-8f44-4d94-999b-57bc69720879)
