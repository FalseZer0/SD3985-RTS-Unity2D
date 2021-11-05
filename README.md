# SD3985_Final - "You knew how to rob here is a reminder"
#

#
# **https://www.designandmake.org/pages/viewpage.action?pageId=128151524 **

#
# **Game Overview**

## **Introduction**

At some point in your life, have you ever thought of ways of robbing without getting caught? &#39;_You Knew How To Rob. Here is a reminder&#39;_ is a real time action strategy game that lets you jump into the shoes of the robbers_._ Fight the enemies, take as much loot as possible, and flee from the scene. Does your plan work? Will you be rich or will you rot in jail? Play it so you can find out.

In this game you will assume the role of Ramirez and his gang. At each stage, the three characters will start out from the front door of the buildings. They will be able to explore the locations by moving the camera, however they will not be able to see inside the buildings as the rooms will be covered with black color. There are vaults and atms inside the buildings that contain enormous amounts of money. However, armed guards patrol the areas and even some locations have secret alarms that will call for back ups. Players need to collect as much money as possible without getting killed.

**Game Objective and FInal Score**

The main objective of the game is to defeat the final level or final stage which is level 4. Throughout the levels players need to loot money from the vaults and atm. This money can either be saved or spent to buy useful resources. The amount of money after the final level will be the final score of the player.

**Genre**

&quot;You Knew How To Rob&quot; is classified as a Real-time strategy (RTS), third-person shooter (TPS) game with a core concept of organizing a squad and planning a robbery. In the game, the player has to be aware of the coming guards and make decisions and actions within the backdrop of a constantly changing game state. Since we decided to make the perspective fix at the top, from which the player can see the avatar on-screen in a third-person top view. Instead of seeing the games through the character&#39;s eyes, the player will see the characters moving and shooting this game. We also consider our game a modern crime game that happens in a major downtown bank. The gameplay development process will follow the genres, and further art style research and implementation will focus on the niche genres.

**Target Audience**

The target audience for this game are teenagers, especially those who fall between 18-21 years old. More specifically, since the game will be tested by PolyU students, the specific target audience are PolyU students.

**Platform**

As explained in the preceding section, &quot;You Knew How To Rob&quot; is a RTS and TPS game, and it focuses more on the strategy side. Hence, our game does not have complicated game controls, and we do not want the players to put a lot of effort into practising how to control the characters. Based on the functions that a character will implement in the game, a joystick is needed to control the camera&#39;s movement, and different behaviours, including shooting, hiding, picking up stuff, will be triggered by clicking on visible buttons on the screen. Moreover, the character&#39;s movement is implemented by using a pointer to indicate each movement&#39;s destination. So we expect the best platforms to be PC and mobile phones since the player can use a mouse click or a finger tap to be the pointer in the game. For mobile phones, there will be a visible joystick on the screen. We will currently only focus on the PC platform, and if there is a chance, we will also try to make a mobile phone version. Other platforms, including PS4 &amp; 5, Switch, or Xbox series, are not considered so far because of the game controls&#39; limitations. However, we are still looking forward to developing new gameplay modes in the future to make our game available on other platforms.

**Game Flow Summary**

There will be four stages which need to be played continuously from one to another. The player will start with level 1 and finish with level 4. Each level has increasing difficulty but also a greater amount of loot. In each level, players can spend as much time as they want to take all the money. However it is also possible for the player to skip robbing the place and just move on to the next stage by moving all alive characters to the getaway car. Between the stages of the game, the player can visit the store in which they can buy skills, upgrade their weapon, and also buy medikit. Skipping a level by not taking any money will prevent players from getting final scores and buying items in the store.

**Look and Feel**

Although the game is about robbery, we selected a relatively bright color scheme. The gameplay is expected to be exciting and nervous, but the visual style is more like a low poly and toy-like style. It&#39;s not like a pixel game, but a game that is colorful and well-illustrated, while the gameplay is clear and smooth.

1.
#
# **Game Design**

**Project Scope**

- **Number of locations and levels**

There are four different levels, with each of them having their own location. The size of the location will increase in accordance with the level number. The first location is a house, the second location is a store, while the third and last location is a bank. The house doesn&#39;t have security details. The store has several security guards that will guard the bank. The banks are equipped with better securities and alarms.

- **Number of NPC&#39;s**

The non playable characters are the security forces and the guards at each level. Each level has a variety of forces, and in the banks if the player triggers alarms, more enemies will come to the location. More specifically the number of enemies are as follow

| Level | Number of Enemies |
| --- | --- |
| 1 | 1 |
| 2 | 3 |
| 3 | 5 |
| 4 | 10 |

- **Number of weapons**

Different weapons will have different damage, shooting rate, and bullet counts. The default gun does not require purchase, and will be assigned automatically to the characters if no new guns are bought. In addition, there will be three guns available in the shop for the player to buy. The three guns available in the shop are Pistol, Submachine gun, and Rifle.

- **Number of abilities**

There are totally four available abilities in the shop for the player to buy to equip the characters. The four abilities are respectively:

1. Move Faster
2. Higher damage
3. Unlock the lock faster
4. Higher health

- **Collectibles**

There is only one collectible object that can be bought by the player, which is a medikit. Medikit can heal the player for a certain amount of health. This medikit can be purchased from the store in between levels.

#

**Gameplay and Mechanics**

**Gameplay**

In the game the player has to use a mouse cursor to move the character to rob a bank and steal the money in a vault. The camera is moved using W, A, S, D on the keyboard to track the enemies and help organize the movement of the main characters.

Since this game is a RTS(real-time strategy) with a top-down perspective which means that the player has to control the character to avoid the guards and guards while thinking about the way to steal the money and escape. Each level starts from an area near the front door of the building. The squad is supposed to raid the building, steal cash money from the vault and escape back to the van in order to complete the level.

Our game introduces a considerable degree of difficulty by adding more guards and making more complex maps. The player`s squad is always outnumbered by guards forces and yet undiscovered areas are not visible, therefore the player must plan his actions in order to rob the bank. The difficulty will increase with each level by increasing the number of guards forces and the amount of damage each guards unit can cause. The player can prepare themselves by buying abilities, weapons, and medikit.

**Mechanics**

- **Physics**

We use RigidBody 2D from Unity to apply basic physics for each of the characters. With the presence of colliders, we prevent people from flying through objects and walls. NavMesh is used to define obstacles and walkable areas.

- **Movement**

Player-controlled characters move in the map with walking animation. The destination of a single movement is clicked by the player and movement is defined using the pathfinding algorithm. The pathfinding is closely related to the navmesh map, and in this sense, the player will move to the destination by following the best path offered by the algorithm. The movements of enemies are achieved by applying a path finding mechanism on them. The guards or the guards will follow a default path first, and once they detect the characters, they will start to chase them.

- **Fog Of War**

When there are no players inside a room, the room will be covered by black mist. This prevents players from seeing the content of the room and must proceed carefully to explore room by room. Moreover, when there is only one player inside a room and he dies, the fog of war of the room will be reactivated.

- **Objects**

Interactable objects will pop a letter when the character approaches it. If this letter is pressed, the player will interact with the object. The playable characters have a circle collider as its component. With the help of tags, the character will be able to know which object collides with its collider. The object itself will have a script that defines what will happen when they are interacted.

- **Actions**

1. **Opening vault**

The vault will be locked initially. Once the player is close enough with the object, they will be able to press the &#39;E&#39; key to open the vault. The key needs to be held for several seconds (varies between vault), or else the vault will not be open. During this process, the player can&#39;t shift to other characters. Releasing the key before completion will reset the opening timer. Moreover, when there are enemies around the player, the vault opening will automatically be aborted and the &#39;E&#39; key will not update the opening timer. Once open, the items inside the vault are taken and the vault will not be intractable anymore. The opening time and the amount of loot inside varies for each vault. This vault will follow the interactable object mechanics.

![](RackMultipart20211105-4-2u7xbl_html_f9cdfbdd98489ae3.png)

_A character opening a vault_

1. **Turning off the Alarm**

In level 3 and 4, an alarm will be sounded when the enemy enters a room with an alarm attached. The alarm emitted a laser beam to indicate its turn on condition. When the laser beam is no longer visible, it means that the alarm has been turned off. To turn off the alarm, characters need to find the switch and shut them down. The switch must be turned off before or after the alarm is sounded. Once the alarm rings, there is no possible way to turn it off until all the characters die.

![](RackMultipart20211105-4-2u7xbl_html_2815e94276c21a3f.png)

_A character passing through a turned on alarm_

![](RackMultipart20211105-4-2u7xbl_html_6db539ac8f8e0c26.png)

_A character turning off the alarm handle_

1. **Healing**

When the characters are injured, the player can heal the selected character by pressing the &#39;H&#39; key. The health of the selected player will be increased by 50. The limit of healing is controlled by the number of Medikit brought by the team. To keep count on the collectibles we can refer to a counter that will be placed in a game manager. Medikit will only increase the health of the player up to its maximum health.

1. **Reloading**

The character will reload immediately when the ammo runs out. If the ammo is not depleted yet, the player can press R on an active player for an immediate reload.

- **Player Health**

Each character has their own health system. It consists of two main parts; the armor and the health itself. At the start of the game the initial value of both will be 0

- **Combat**

Each playable character has 2 attack modes : automatic and controlled. All currently inactive players are in automatic mode. In automatic mode, playable characters will start shooting at enemies who are detected by the sight system. The currently active (selected) character is operated in control mode which means the player may need to manually select the target for the attack by left clicking on it. However, selecting the target is not the only condition for the shooting, the target has to be detected by the player`s sight system.

In both modes, once the enemy unity is set as a target, the character will continuously shoot and rotate towards the target. In addition, if the active player is moving while in attack mode the character will continue shooting until the point where the enemy unit is no longer detected by the sight system.

- **Changing players**

During the game, the player can shift between squad members by pressing the spacebar. This may allow the player to achieve pseudo-simultaneous execution of orders. For example, assigning a &quot;tank&quot; character to defend the entrance to the room while another character with &quot;fast hacking&quot; ability tries to open the lock.

- **Economy**

In each level, the squad has to steal as much money as possible. Once the level is completed, the player will be given a chance to visit a store before moving to the next level. In the store, the player may buy advanced weapons or abilities and assign those to a particular character. This mechanic allows the player to create his own build for each level.

- **Game Shop**

To enhance the playability of the game, we designed a shop system in which the player can use the money robbed from previous levels to buy different abilities and guns and assign them to each character. The shop panels will appear between levels, after this level is completed, the player will be led to the shop panels. The shop panels contain four scenes, respectively Ramires&#39;s store, Lucas&#39;s store, Andre&#39;s store, and medical kit store in sequence. After the player finishes buying, the next level will start.

Abilities:

| Faster Movement | The character will increase the moving speed by 33% |
| --- | --- |
| Higher Damage | The damage caused by the character will increase by 50% |
| Faster Unlock | The unlock speed of the characters will increase by 100% |
| Higher Health | The character&#39;s starting health points will increase by 50% |

Guns:

| Default Gun | Damage: 25Shooting delay: 2Bullet count: 20 |
| --- | --- |
| Pistol | Damage: 35Shooting delay: 1Bullet count: 20 |
| Submachine Gun | Damage: 40Shooting delay: 0.3Bullet count: 30 |
| Rifle | Damage: 45Shooting delay: 2Bullet count: 30 |

Medical kits:

| Medical kits | Add 50 health points |
| --- | --- |

- **Stage Fail**

The stage will fail when all playable characters in the game die. In this case the game will return to the previous level game shop or to the main menu for level 1 fail. In the main menu, all items bought previously for this stage will be reset so players can re-evaluate their strategy in buying resources.

- **Stage Pass**

The stage will move to the next stage when all alive characters have arrived on the getaway car. It is important to notice that the stage can be passed directly by moving all the characters to the car. However, once the stage is passed all the money in the stage will not be able to be recovered which means players lose points. Moving to the next stage will let players buy resources from the game shop.

**Screenflow**

**Screen Flow Chart**

The following is the screen flow chart for the game:

![](RackMultipart20211105-4-2u7xbl_html_6b56580b033487d4.png)

**Screen Descriptions**

- **Main Menu Screen**

After the game is loaded, the player will be led to the main menu scene. The main menu scene contains three buttons, namely &quot;Play&quot; button, &quot;How to play&quot; button, and &quot;Quit&quot; button. The &quot;Play&quot; button will take the player to level 1, the &quot;How to play&quot; button will show the game instruction panels.

![](RackMultipart20211105-4-2u7xbl_html_ad4cd56b76e65013.png)

Game instruction panels:

![](RackMultipart20211105-4-2u7xbl_html_545daad8064bbbd5.jpg)

- **Level 1 Screen**

Level 1 is the first playable screen in the game:

![](RackMultipart20211105-4-2u7xbl_html_7ab24b6f5248d0fc.jpg)

- **Level passed screen**

A congrats screen will appear once the player passes the level, the &quot;Next Level&quot; button will lead the player to the shop screens:

![](RackMultipart20211105-4-2u7xbl_html_861349aed8a8d863.jpg)

- **Shop Screens - Character&#39;s shop**

There will be three screens in sequence for the player to use the stolen money to upgrade the abilities and guns for each character. On this screen, the character&#39;s name and icon will be shown in the bottom right on the screen, and the player can click on the buttons on the screen and buy the items for this character, take Ramires shop as an example, Lucas shop and Andre shop look similar and will be displayed afterwards.

![](RackMultipart20211105-4-2u7xbl_html_8ca7d755a4a278e4.jpg)

- **Shop Screens - Medical Kits shop**

This screen will be displayed after the three characters&#39; shop screens are done. On this screen, the player can buy medical kits that can be used in the next levels. The &quot;Next Level&quot; button will lead the player to the next level&#39;s play screen:

![](RackMultipart20211105-4-2u7xbl_html_b33aa68961396698.jpg)

- **Level 2 Screen**

Level 2 is the second playable screen in the game:

![](RackMultipart20211105-4-2u7xbl_html_ec4abdd57a90d831.jpg)

- **Level 3 Screen**

Level 3 is the third playable screen in the game:

![](RackMultipart20211105-4-2u7xbl_html_50ad26491abb3ed4.jpg)

- **Level 4 Screen**

Level 4 is the last playable screen in the game:

![](RackMultipart20211105-4-2u7xbl_html_52c4068b80b5a03d.jpg)

- **Congratulation Screen**

After level 4 is completed, there will be a final congrats screen on which the total money (score) the player gets will be displayed. The &quot;Main Menu&quot; button will lead the play to the main menu and the player can start a new game.

![](RackMultipart20211105-4-2u7xbl_html_73e47b9ce2ed036a.jpg)

- **Pause Screen**

The pause canvas will show up when the player presses the pause button in the top right corner in each level screen:

![](RackMultipart20211105-4-2u7xbl_html_ed9d05718697e6bd.jpg)

- **Game Over Screen**

The game over canvas will show up when all the characters die in each level, and if the player clicks the &quot;retry&quot; button, the shop panels will appear and the level failed can be played again. The &quot;Main menu&quot; button will end the game and go back to the main menu.

![](RackMultipart20211105-4-2u7xbl_html_e5ba5984f6f3960c.jpg)

**Story, Setting and Character**

**Story and Narrative**

- **Background story**

He completed three tours in the heat of the Middle Eastern countries, took down Islamic terrorist leaders, saved thousands of innocent souls, and what did he get in return? PTSD, broken family and a heart-shaped purple medal. Tired of living poorly without any jobs, Ingram Ramirez turns to the things he is good at, combat and infiltration. Gathering his old crew, Ingram created a plan to conduct a grand heist to turn his and his comrades&#39; life around.

- **Game Progression**

The game starts with the 3 characters robbing a small house. This is the first stage, and there is only one enemy. Equipped with only hand guns, the characters have to neutralize the enemy and then loot the money in the house. The money gained from this level can be used in the store in between the stages.

When the next level begins, all the characters are respawned no matter if they died in the previous level. The second, third, and fourth levels will have more enemies and traps in which the game becomes increasingly harder.

The stage will fail, if all the characters die in a level in which the game will restart from the latest shop or the main menu if it is level 1.The stage or level is completed when all players reach the getaway car. The game is completed if the player can finish the last level of the game. The score of the player depends heavily on the amount of money left and gained after level 4.

**Game world**

**Area**

- **General Description**

In the game, all the maps(levels) are made using combined sprites so that the visual style remains the same. Since we set the game to be top view, the area actually looks like a blueprint, and each level contains a top view of a bank with several rooms and objects. The general area will be dark since the robbery takes place at night time.

- **Physical Characteristics**

Walls and some objects,like tables or boxes are non walkable, while the ground and the floor are walkable. The movement and shooting abilities of the squad members and enemies follow these basic rules. Enemies can shoot through doors and small objects such as plants.

**Characters**

- **Main characters: Ramirez** , **Lucas, and Andre**

The player has to control these characters to rob and steal.

![](RackMultipart20211105-4-2u7xbl_html_b21473721845db92.jpg)

- **Security Guards**

The security guards are the enemies who make perfunctory rounds in the secured area. When the security guards detect an intruder they will start to chase and attack them to death. After eliminating a crew member, the enemy will look for the rest of them and do everything to eliminate the threat.

If the crew triggers the alarm system, all of the patrolling guards will be aware of the positions of each crew member. All crew members will be chased and attacked to death. Moveover, the backup will come and try to eliminate the characters.

The number of the enemies in the map, their hp and attack capabilities differs from level to level. Below are the characteristics of security guards at each level.

| LVL | Attack damage | Maximum hp |
| --- | --- | --- |
| 1 | 20 | 100 |
| 2 | 25 | 100 |
| 3 | 30 | 120 |
| 4 | 35 | 140 |

**Levels**

The number of enemies in each level has been described in the NPC section above and the details of the guards has been mentioned in the section above this, hence this section will focus more on the level description.

- **Level 1**

The first level of the game acts as a tutorial. Players can freely learn the control during this level This level takes place in a drug lord house. There is only one enemy in this level, and there is only one vault to be cracked. The map of the stage is as follows.

![](RackMultipart20211105-4-2u7xbl_html_b27ba78b47b8939f.png)

- **Level 2**

The second level takes place in a digital store for money laundering. The number of enemies increases in this level. The guards present at this level are level 2 guards with higher stats. The map of the game is as follows.

![](RackMultipart20211105-4-2u7xbl_html_d384b3e1886579ae.png)

- **Level 3**

The third level takes place in a small bank. There are five security guards placed to guard the place. Three new interactable objects; atm, alarm, and alarm handle are introduced in this stage. The soldiers guarding the place are level 3 soldiers. Since the alarm is already present, enemy backup will be available in this stage. Due to the increasing number of enemies, the importance of the items in the shop will be more impactful to the player. The map of the game is as follows.

![](RackMultipart20211105-4-2u7xbl_html_a510cbb5fd22e35e.png)

- **Level 4**

The fourth level takes place in a national bank. The bank is heavily guarded with level 4 guards. With increasing amounts of damage and enemies, items from the shop are very critical in order to get a high score in this stage. Compared to the other levels, level 4 has more loot available for players to increase their total score. The map of level 4 is as follows.

![](RackMultipart20211105-4-2u7xbl_html_6b50091cbd74456.png)

**Interface**

- **Visual System**
  - **HUD**

![](RackMultipart20211105-4-2u7xbl_html_52c4068b80b5a03d.jpg)The top left corner shows how much money the player has and the amount of medkit left. The active player will be highlighted in a yellow circle and the current health of the player will be displayed on a circular health bar around the player. The bottom left panels will show the details of each; name, ammo count, armor and exact health of the player. On the top right corner, a main menu button that can pause the game can be found.

  - **Camera (W,A,S,D)**

The camera is controlled with (w,a,s,d) keys by the player. Boundaries are set for the camera so they will not wander too far from the map.

  - **Control System**

Pausing the game works by clicking the pause button on the right top corner of the game or by pressing the &quot;Esc&quot; key on the keyboard.

Players shall control the characters by right clicking on the map to set the destination for the characters to move to. If the destination is valid (reachable), the path the character will follow will be shown and the character will start moving towards the destination. Players may invoke a &quot;direct attack&quot; by left clicking on the enemies. In this sense, the enemy unit will be set as a target and the character will continuously attack the enemy. Pause button can be called on the top right corner with a mouse click.

  - **Music &amp; Sound Effects**

There is background music and sound effects in the game. The background music will be changed to more intense ones during the stage gameplay. Several sound effects are applied to the objects in the game. For example, gunshots, alarms, and opening vaults. The list of sound effects are as follow

| Sound | Source |
| --- | --- |
| Gunshots | 12-Gauge-Pump-Action-Shotgun-Close-Gunshot-A-www.fesliyanstudios.com |
| Opening vault | Change-www.fesliyanstudios.com |
| Alarm | Fire Alarm-SoundBible.com-78848779 |
| Game Over | mixkit-sad-game-over-trombone-471 |
| Stage complete | mixkit-conference-audience-clapping-strongly-476 |
| Stage Background Music | Purple Planet Music - Predator (1\_30) 122bpm |
| Menu and Shop Background Music | Purple Planet Music - Spy Story (2\_33) 120bpm |

**Artificial Intelligence**

The AI of both playable characters and the enemies is realized with state machine approach. The state will change if a certain condition is satisfied.

- **Enemy AI**

The initial state of an enemy unit depends on whether it was spawned or not. If the enemy is spawned it will enter the Wrath state in which enemies are randomly selecting the playable character and chase him. When the target character is close enough, the enemy enters the Attack state and starts shooting the player. If the target is too far, the attack state goes back to wrath, but now since the target is still alive the wrath state will be responsible for chasing the player. If the target player was killed by anyone, the current enemy will re-enter the wrath state and randomly look for another target.

If the enemy was not spawned, its initial state is Patrolling where it patrols a certain area. If the sight system detects a playable character, he will be set as a target and the enemy enters the Chase State where he tries to reach the target player. If the target is close enough an enemy enters the Attack mode otherwise it will remain chasing. Whenever the target dies, the enemy enters the Wrath state where it randomly selects and chases a playable character.

When all characters are dead, all enemy units enter a Chill mode which basically means remain idle.

- **Player AI**

It consists of movement and attack modules. Both act independently of each other.When it comes to the movement, the default state is Chill which means remain idle. If the valid destination is inputted, the player enters a Move state where it moves towards the destination. The attack system states mainly depend on the currently active player. For non-active characters, the state is Auto which means they will start shooting if the sight system detects any enemies. For an active character, the state is Control, where the player needs to move himself and set the target for shooting manually. The switch between states depends on the switch between crew members.

- **Support AI**

- **Pathfinding and obstacle avoidance**

It is realized in the same way for both playable characters and the enemies. The navmesh2d plugin is used to implement this feature. Objects select the shortest path to reach the destination and avoid all obstacles on the way

- **Sight and shooting**

It is realized in the same way for both playable characters and the enemies. In order to detect something, the object with a specific tag must enter the collider area first and then the ray is casted to the position of the object who entered the collider area. If the raycast returns the object of the anticipated tag, the system concludes that a certain object is detected. Otherwise, the system concludes that nothing was detected

- **Object Interaction**

As mentioned before, interactable objects will be equipped with tags to identify their type. When player&#39;s collide, collide with the object they will interact with the object&#39;s script.

**Game Art**

Our group also focused on art style in the game. From the game design courses we took in previous semesters, we learned how to select appropriate theme songs, 3D modelling styles, theme colours, etc. However, for this project, we are required to create a real 2D game, in which we may have to use different sprites created by other artists. Hence, selecting a decent style that fits our game theme is quite a challenge during the discussion process. First of all, the perspective. Isometric would be the best choice to make our game stand out since it provides a different tone of the 2D game, enhancing the scene&#39;s richness. However, we considered this project&#39;s expected working time; the isometric perspective will take too much time to achieve. We finally decided to use a top view which is the most similar. Then we spent a lot of time searching for sprites we like we can use in our game, which in our expectations, had to be well illustrated, clear, distinctive, and in a low poly art style. We found our final choice on a website called Kenney, on which all the assets and sprites are available for personal use and free of charge. Here is one of the sprites we will use:

![](RackMultipart20211105-4-2u7xbl_html_6e905fb715e472b4.jpg)

source : [https://kenney.nl/assets/topdown-shooter](https://kenney.nl/assets/topdown-shooter)

**Preferred color scheme:**![](RackMultipart20211105-4-2u7xbl_html_11da7729eec5377a.jpg)

**Preferred Typography:**  **Bangers**

![](RackMultipart20211105-4-2u7xbl_html_49ab4cfb5d2d6675.png)

We will follow this art style to create the environment, vehicles, characters, etc. We will also use Adobe Illustrator to create other sprites to support all the animations that will appear in this game, and use Adobe Photoshop to adjust the color theme to fit our game style more. Other adjustments will be further discussed and improved in later development stages.

**Characters &amp; Animations:**

The sprites we use do not obtain animation we need, so we created the walking and dying animation using Adobe illustrator.

![](RackMultipart20211105-4-2u7xbl_html_7a7a9b5ebda13346.png) ![](RackMultipart20211105-4-2u7xbl_html_983d9fe56b9f22ae.png)

**Environment**

![](RackMultipart20211105-4-2u7xbl_html_4dbe7cbced4c0b8b.png)

downloaded assets

| Image | Source |
| --- | --- |
| ![](RackMultipart20211105-4-2u7xbl_html_45ae94fc8e0a9d45.png) | https://favpng.com/png\_view/2d-furniture-top-view-png/RQRv84g6 |
| ![](RackMultipart20211105-4-2u7xbl_html_fb90b5e8ba83a884.png) | https://clipart-library.com/clip-art1-16054\_longhorn-skull-images-cute-skull-clip-art.htm |
| ![](RackMultipart20211105-4-2u7xbl_html_659e8a8d054e7fa4.png) | https://pngtree.com/freepngmoney-bag-vector-icon\_5576571.html |
| ![](RackMultipart20211105-4-2u7xbl_html_fb08d96cfe659b23.jpg) | https://www.pinterest.com/pin328129522858209327 |
| ![](RackMultipart20211105-4-2u7xbl_html_e17a1c5c634798eb.jpg) | https://www.pinterest.com/pin654992339547079999 |
| ![](RackMultipart20211105-4-2u7xbl_html_be8cf06634e7c7c6.jpg) | https://www.pinterest.com/pin762375043166638963 |
| ![](RackMultipart20211105-4-2u7xbl_html_9f53c5d6bfea0036.png) | https:/www.pngkey.com/downloadu2q8q8o0o0w7w7q8\_map-circle-lime-bright-green-circle-png |
| ![](RackMultipart20211105-4-2u7xbl_html_5355605aa8340857.png) ![](RackMultipart20211105-4-2u7xbl_html_934db94282bd5c1e.png) ![](RackMultipart20211105-4-2u7xbl_html_cfa88125faa42db9.png) ![](RackMultipart20211105-4-2u7xbl_html_22e5259b41fa3edc.png) | Icon 8 |

# **Technical Design**

**Class diagram**

![](RackMultipart20211105-4-2u7xbl_html_5bab9ce5b143ade9.png)

The majority of the relationships are associations and aggregations. Only the Gun class and its children are realized with inheritance.

**Use case diagram**

This diagram depicts a high-level overview of the relationship between the player (actor) and the game (system).

![](RackMultipart20211105-4-2u7xbl_html_abf0be57ac52a350.png)

**Player**

- **Player Switch**

The switching between playable characters is realized by one of the managers, namely the GameGod

![](RackMultipart20211105-4-2u7xbl_html_2eea7e5d130b34bc.png)

![](RackMultipart20211105-4-2u7xbl_html_b55328ff1fb25564.png)

![](RackMultipart20211105-4-2u7xbl_html_30f7815191386b59.png)

In general, the code takes references of gameobjects of all playable characters in the scene. It sets the first object in the array to be an active player by default and sets the yellow outline to true and places the corresponding name card above all others in order to indicate that this character is active.Initially, the &quot;Player script&quot; and the outline are disabled for all non-active players. In this sense, the non-active players will not be able to move whenever the player sets the destination or sets the target for the attack mode. However, other systems, like health,sight and attack still operate in currently inactive characters. The inactive characters are still able to move if the destination was set before the switch since the navmeshagent component remains active.

Whenever the player presses the spacebar, the coroutine with a cooldown of 5 starts. This coroutine iterates through the array and thus changes the currently active player. The player script and the outline are activated by the newly selected CurrentPlayer. Also, the corresponding name card is set to be above all others. At the same time, outline and player script are disabled for previously selected CurrentPlayer and its name card is set back to normal. Whenever the count reaches the out of bound value it is reset back to 0.

- **Player AI**
  - **Attack**

The logic behind this system is realized with state machines. The operation of this module is summarized in the state diagram below.

![](RackMultipart20211105-4-2u7xbl_html_b8b9fa0d4f6b2446.png)

The transition between states depends on whether the character is active or not. If there is no gun assigned by &quot;Manager script&quot; (like in level 1), the default gun is assigned.

![](RackMultipart20211105-4-2u7xbl_html_50a20697d65d1ea6.png)

![](RackMultipart20211105-4-2u7xbl_html_44cf57bddc54ff01.png)

![](RackMultipart20211105-4-2u7xbl_html_90107edea0744c29.png)

In auto attack mode, the inactive character monitors the target which is set by the sight module. If there is a target and it is alive, the character rotates towards the target, gets the reference of the target`s health script and decreements its hp periodically. The delay and the damage depend on the type of the weapon or/and ability used.

![](RackMultipart20211105-4-2u7xbl_html_502589bc4d153e33.png)

![](RackMultipart20211105-4-2u7xbl_html_1186cf9ee00cd33a.png)

In the control attack state, the player needs to select the target by using mouse left click on it.

![](RackMultipart20211105-4-2u7xbl_html_4854942bc5cfd17b.png)

If the object clicked is within a range of 5,it is alive and its tag is &quot;Enemy&quot;, its set as a target and character continuously attacks the target using the approach described above.

![](RackMultipart20211105-4-2u7xbl_html_fce4ef4c13bcc0fb.png)

For each shot, line renderer and the muzzle sprite are activated for a while. The linerenderer is supposed to show the trajectory of the bullet. After the delay which is realized with a coroutine &quot;yield return new WaitForSeconds(0.05f)&quot;, those 2 components are disabled.

![](RackMultipart20211105-4-2u7xbl_html_b2100ffd79c34561.png)

Lastly, the attack module contains the sight system. It is used by the inactive characters since their player script is disabled. The sight system will be discussed in detail later.

  - **Movement**

Any playable characters have 2 states for the movement: Chill and Move.

![](RackMultipart20211105-4-2u7xbl_html_1c015e261ac55ac.png)

By default, all characters are in Chill state.

![](RackMultipart20211105-4-2u7xbl_html_b11cad2481b63e0d.png)

If the player selects a valid destination point, the state is changed to the Move.

![](RackMultipart20211105-4-2u7xbl_html_6c8228a8613fc4d7.png)

In order to judge whether the destination point is valid or not, the length of the path to the destination is considered. If the length is less than a defined threshold, the point is valid. Unlike just checking for the distance between 2 characters and the destination, the length of the path is calculated with consideration of obstacle avoidance algorithms provided by the Navmesh2d.

![](RackMultipart20211105-4-2u7xbl_html_f33a2a43775f97e8.png)

![](RackMultipart20211105-4-2u7xbl_html_3c67f0aaf29cdc14.png)

When the character is in the move state, linerenderer is activated to outline the path to the destination. The rotation of the character depends on whether it is attacking anyone at the moment or not. If it&#39;s currently active and attacking someone, the character will rotate towards the target. Otherwise, the character rotates towards the target.

![](RackMultipart20211105-4-2u7xbl_html_b9aa2e5531b58fc2.png)

If the destination is reached, the character goes back to the Chill state.

There is another special case for the character to enter a Chill state.

![](RackMultipart20211105-4-2u7xbl_html_47093843fbfef015.png)

If the character is almost at the destination and the length of the path remaining to the destination has not changed for a while, the character will enter the Chill state.

  - **Sight**

The sight for each character is realized with a circle2d collider and a raycast. ![](RackMultipart20211105-4-2u7xbl_html_d7552b9e939580b5.png)

![](RackMultipart20211105-4-2u7xbl_html_ddd30f4c6ed37847.png)

First, the OnTriggerStay2D(Collider2D collision) method checks if the object inside the collider has the tag enemy. If so, the raycast with length of 5 is projected on the object. The raycast also ignores the ignore raycast layer mask so we avoid colliding with colliders of doors or the collider of an enemy that is used for its sight system.

![](RackMultipart20211105-4-2u7xbl_html_766ffe51e8e708cd.png)

![](RackMultipart20211105-4-2u7xbl_html_7c5cd3e16c2403de.png)

If the raycast returns an object with a tag &quot;Enemy&quot;, the target variable is set and later used by the attack module. Otherwise, the target is set to null.

- **Object interaction**

For object interaction, we rely on a sphere collider to detect any objects around the player. The collider setting is as follows.

![](RackMultipart20211105-4-2u7xbl_html_f48daed272b5baf1.png)

&#39;Is Trigger&#39; is important to be selected otherwise other objects will not be able to enter the collider. The radius is 2 which simulates the range of player sight.

Since all interactable have its own tag; &#39;vault&#39; for vaults, &#39;atm&#39; for ATMs, and &#39;alarm&#39; for Alarms, the player collider is able to differentiate objects.

All object interaction commands are stored in the &#39;Player&#39; script. To control interaction time, the script has a timer called &#39;openTimer&#39;. This is a float which will increment every time an action is done. For example, pressing E will increment the &#39;openTimer&#39; and releasing it will reset the timer to 0.

![](RackMultipart20211105-4-2u7xbl_html_bd34a942d36d6633.png)

When the object enters the collider, the following action in the player script is triggered.

![](RackMultipart20211105-4-2u7xbl_html_a1033b39fbf99cf0.png)

In general, it saves the triggered object and its script into a variable, and reset all timers. Moreover, it will activate the &#39;UI&#39; that indicates which button needs to be pressed along with the timer. As long as the object still remains inside the collider, it will execute the following command.

1. Check if the enemy is present

![](RackMultipart20211105-4-2u7xbl_html_1730eacb34e5e8cb.png)

If an enemy is around, the timer will not respond to player action so the object will not be interactable.

1. Opening the vault

![](RackMultipart20211105-4-2u7xbl_html_f2547cb22bbe45e5.png)

Here is the script to check if the vault has been looted. If it has been looted, there is nothing to do. If the vault has not been looted, it checks for the distance between the player and the vault. When it falls below 1f, it will enable the interaction with the object. Pressing E, will increment the openTimer and increase the amount of the fill in the UI. Releasing &#39;E&#39; will reset everything. If the openTimer is equal to the openTime of the vault, it will open the vault and the player will take the loot inside the vault.

1. Opening atm

![](RackMultipart20211105-4-2u7xbl_html_2adfeb770ffc2e1a.png)

The concept of alarm is the same as the concept of the vault, the only difference is the tag used.

1. Triggering Alarm

![](RackMultipart20211105-4-2u7xbl_html_745be0c451c3eec3.png)

The script will take the transform position of the alarm and perform a raycast from the player position.

![](RackMultipart20211105-4-2u7xbl_html_972203c78963fa45.png)

If there are no colliders in between the alarm and the player, the raycast will hit and trigger the alarm. It is important to set the rigid body 2d of the player and the alarm to never sleep to make sure that it will always be detected by the collider.

1. Turning off alarm

![](RackMultipart20211105-4-2u7xbl_html_ee526ce8f8c9a180.png)

The concept is similar to vault and atm, but it checks two conditions beforehand. It checks if the alarm has been disabled before or is it currently ringing. If the alarm has been deactivated or it is currently ringing, the user will not be able to interact with the alarm. The alarm handle has a timer to control its opening time. If open timer matches this number, the alarm will be deactivated.

- **Player Health**

![](RackMultipart20211105-4-2u7xbl_html_9a424ef3532d52ca.png)

At the start of the stage, each player has 100 health and armor unless they buy a special ability which will be indicated by boolean &#39;HH&#39;.

![](RackMultipart20211105-4-2u7xbl_html_96395b3d9e91885a.png)

Every time the player takes damage, the health will decrease according to the &#39;amount&#39;. The damage will decrease armor first and then health if the armor is already less than 0.

![](RackMultipart20211105-4-2u7xbl_html_74980d0364c84b2d.png)

In the update function, when the amount of health reaches 0, it will trigger an &#39;isDead&#39; boolean which indicates the death of the player. The script will destroy all nav, sprites, and collider after the player dies. Moreover, it will decrease the count of a number of players alive on the stage. The &#39;isDead&#39; boolean makes sure that the player only dies once and prevents null variables.

The health can be incremented by pressing &#39;H&#39; as long as the player still owns a medikit.

![](RackMultipart20211105-4-2u7xbl_html_eaa57c1a97d921e2.png)

The script checks if the player is still alive and if the health is less than the maximum health. If both are correct, pressing H will add 50 health. The amount of medikit is stored in another script called &#39;gamecontroller&#39; which in this case has been saved as &quot;gameManagerScript&quot;.

- **Player additional**

![](RackMultipart20211105-4-2u7xbl_html_bc7842b3f20eb2d2.png)

This is a simple script that is used to satisfy the need of the NavMesh2d plugin. This is used as a separate script since player.cs script is disabled for inactive players. Without these settings, nav mesh agents will not be able to correctly render in the scene (according to the navmesh2d documentation).

- **Bullets**

In the &#39;Player&#39; script, the bullets can be reloaded by pressing &#39;R&#39;.

![](RackMultipart20211105-4-2u7xbl_html_96b5b07e126d7684.png)

The information about the bullets themselves is contained inside the &#39;bulletCount&#39; script.

![](RackMultipart20211105-4-2u7xbl_html_31ee381224f9b6ce.png)

- **Guns**

Guns are realized with a simple parent class Guns that contains all the properties and corresponding getters and setters.

![](RackMultipart20211105-4-2u7xbl_html_d35255e0ad947376.png)

The children of this class will inherit those attributes but their values are changed in constructors.

![](RackMultipart20211105-4-2u7xbl_html_d4b0934a68a4838d.png)

Later, this script is used in the shop system to assign a particular character with a gun.

**Enemy**

- **Enemy Patrol Path**

This is realized by using WayPoint transform. Using Vector2.MoveTowards, we can set the destination of the enemy to the next wayPoint. All of the wayPoints are stored in an array, and there will be a counter to keep count of which wayPoints have been reached. The waypoints are empty objects placed on the game scene as the path coordinate. The counter will be incremented once the distance between the enemy and the waypoint is less than 0.1f. One issue with this is the enemy will not be able to reverse direction once it reaches the end of the wayPoints. Therefore, we use a boolean parameter to determine the direction of the movement.

![](RackMultipart20211105-4-2u7xbl_html_6885fce58cadee4c.png)

- **Enemy sight**

Each enemy has a 2d circle collider and they detect the player with the OnTriggerEnter2d method. If the object that entered the trigger has a tag Player then the state of enemy will change to chase. Later on, this mechanic will be combined with raycast to be used for shooting.

![](RackMultipart20211105-4-2u7xbl_html_2603652ebb2b12c8.png)

It is realized in the similar way as the player`s sight system. It checks if entered objects have an anticipated tag name and if so the raycast of length 5 is used to check if the object is not blocked by something and is visible. If the object returned by the raycast has the tag &quot;Enemy&quot;, it is set as a target. Depending on which state was active before we set the new state. If it was in Wrath before, we set it back to Wrath but with a new target. By doing so we ensure that during its way to the destination if the enemy sees another target he will switch to it. If he was in any other state before, the next state is Chase. For more details about states, refer to the Enemy AI section.

- **Enemy AI**

The operation of enemy AI is summarized with a state machine diagram below.

![](RackMultipart20211105-4-2u7xbl_html_405a019b049c640b.png)

![](RackMultipart20211105-4-2u7xbl_html_cbb5da5a8621d569.png)

The spawnToggle is turned on by default in the prefab version of the enemy object. If the spawnToggle is on it means that the enemy is to be spawned and hence the initial state is Wrath. Otherwise, the state is Patrolling. Below are explanations for each state:

1. Patrolling

This has already been covered.

1. Chase

![](RackMultipart20211105-4-2u7xbl_html_11ac6d816c2fc51e.png)

The target is set by the sight system. The enemy unity will move and rotate towards the set destination. Whenever the distance between the target and the enemy unit is less than the agent`s stopping distance (3), the state is switched to the attack.

1. Attack

This state can be reached from either attack or wrath states. Depending on the previous state and on the fact whether the enemy was spawned or not the attack system is designed to eliminate the selected target. The method of attacking is similar to the player`s attack module.

![](RackMultipart20211105-4-2u7xbl_html_bcbb8921611c5eea.png)

If &quot;this&quot; enemy is still alive and the target is not null (also alive). Keep casting rays towards the target. If the tag of the object returned by the raycast is &quot;Player&quot;, the enemy will start decrementing the health at defined rate. The shooting effect is realized exactly the same way it is done for the player`s attack state. If the distance to the target is too big or the target player is dead, it goes back to the Wrath.

![](RackMultipart20211105-4-2u7xbl_html_d2d7f8dc7cfeb11a.png)

1. Wrath

The wrath state consists of 2 parts : target selection and chasing. The first part is performed only when there is no target selected.

![](RackMultipart20211105-4-2u7xbl_html_a5982b7615264aac.png)

It takes reference from the GameController script where the list with currently alive characters resides. This part of the script repeatedly selects random objects from the targetlist until the one with positive health is found. It is then selected as a target. If Wrath is entered and the target is set already the step with random selection is skipped. When there is only 1 alive character left it is selected manually by iterating through the list of all player objects. This is a half measure that was used to eliminate a bug in a short amount of time. The bug will be discussed later in the report.

Inside GameController:

![](RackMultipart20211105-4-2u7xbl_html_9c47ec5ab7418b45.png)

![](RackMultipart20211105-4-2u7xbl_html_2ec7c38256d01020.png)

After the target is selected the next step is to approach the target player which is realized in a similar way to the Chase state.

![](RackMultipart20211105-4-2u7xbl_html_c13d7d09181101a3.png)

Eventually, if distance between an enemy unit and the target player is less than a threshold, the state is switched to Attack state.

1. Chill

This state ensures that the enemy unit remains idle.

![](RackMultipart20211105-4-2u7xbl_html_c970df6ca68d25dd.png)

- **Enemy Manager**

The enemy manager manages how many enemies will spawn in case the alarm is triggered by the player.

![](RackMultipart20211105-4-2u7xbl_html_640ae5568d82d7e7.png)

It takes an alarm object and checks its status. When the alarm is on it will invoke a spawn. The limit of the enemy is controlled by &#39;ThisEnemyNumber&#39;. The variable of &#39;enemyCount&#39; will increase with each spawn and decrease when the enemy dies. If the number of &#39;enemyCount&#39; is equal with &#39;ThisEnemyNumber&#39;, the spawning will stop.

- **Enemy Health**

The enemy&#39;s health is controlled by the &#39;EnemyHealth&#39; script. It works the same way as &#39;PlayerHealth&#39; however without the armor part. Moreover, in enemy health, we destroy the whole enemy object instead of just the component.

**Object and Environment**

- **Pathfinding and environment**

The pathfinding is realized with NavMesh2d components. The map is baked using NavMeshModifier and this is where obstacles and walkable areas are defined. In order to define the area for an obstacle, box colliders were used. All playable characters and enemies have a navmesh component that is used to access the pathfinding algorithm. In order for the navmesh agents to work, they need to have some adjustments on rotation and axis.

The tilemap does not work well with NavMeshAgent that we use to calculate the best path to take. Hence, we use sprites to draw the environment. The floors use the following setting.

![](RackMultipart20211105-4-2u7xbl_html_285c8aa8cc85b506.png)

The draw mode is changed to tiled, hence when we increase the height and width it will multiple the sprite. The order in the layer needs to be -1 so it is set to be behind others. The NavMeshModifier needs to be set as &#39;walkable&#39; for the floor.

![](RackMultipart20211105-4-2u7xbl_html_24a722eb54688088.png)

For other objects and walls, we put the sprite directly inside the scene. Each of them are equipped with box collider 2D and trigger enable. The area type for these objects are set to be &#39;Not Walkable&#39;.

- **Fog of War**

![](RackMultipart20211105-4-2u7xbl_html_f22903f74455f809.png)

The fog of war is actually canvas with black background equipped attached to an empty with a 2D box collider and &#39;FogofWarCanvas&#39; script. Each room has its own fog of war that covers the entire area. Their collider also covers the whole room. The operation of the script is as simple as this.

![](RackMultipart20211105-4-2u7xbl_html_eaa545180ef4109f.png)

If the collider of the fog of war detects an object with &#39;Player&#39; tag, it will immediately disable the canvas. If the player leaves, the canvas will be enabled again.

- **Alarm**

![](RackMultipart20211105-4-2u7xbl_html_5de431d52bad7895.png)

The alarm consists of the above sprite with an &#39;alarm&#39; tag. The &#39;AlarmTrigger&#39; script controls the alarm.

![](RackMultipart20211105-4-2u7xbl_html_dafeb3adcb58b720.png)

It started by setting the alarm as active, but not ringing. As long as the alarm is still active, the alarm would ring once triggered by the player. &#39;alarmSound.Play()&#39; will play the ringing sound.

- **Alarm Handle**

![](RackMultipart20211105-4-2u7xbl_html_b20289ab49ce03f5.png)

![](RackMultipart20211105-4-2u7xbl_html_6a0341cc6c931563.png)

The alarm handle consists of a script that can be called from the &#39;Player&#39; script. AlarmOff() will prevent the alarm from ringing ever again. The other two functions are used to enable and disable the dialog box.

- **ATM and Vault**

![](RackMultipart20211105-4-2u7xbl_html_98b50d72ed4ce02f.png) ![](RackMultipart20211105-4-2u7xbl_html_803bd57b69cd79a4.png)

Both ATM and Vault works with the same logic. Each of them stores a variable to determine its loot value and its opening time.

![](RackMultipart20211105-4-2u7xbl_html_aa62d39b02949b3.png)

The amount of fill represents the remaining opening time. Once the atm and vault are opened, they will update the total money inside the game manager, disable the UI, and play a sound effect. Special for the vault, I use render.sprite method with variable to set the open and close sprite.

**Animation**

There are two main animations in the game: walking and death. The animation of walking is assigned to each character and enemy. The basic idea was to create walking motion break-down sprites for each character and enemy then use animators to trigger different states. Death animation is relatively simple, a death sprite will be triggered if the character is killed.

Sprites for character&#39;s walking animation (using Adobe Illustrator):

![](RackMultipart20211105-4-2u7xbl_html_b21473721845db92.jpg)

In unity, we sliced the sprite and put them inside the animation panel:

![](RackMultipart20211105-4-2u7xbl_html_7d580bca48f09158.jpg)

Then for each character we created an animator controller to switch between different animations:

![](RackMultipart20211105-4-2u7xbl_html_df068458af36ec0d.jpg)

For the transitions between idle state and walking state, we used a float &quot;Speed&quot; to detect the character&#39;s moving speed. If the value is larger than 0.01, the idle state will be transited to walking state, the walking state will be set back to idle state when the value is less than 0.1:

**animator.SetFloat(&quot;Speed&quot;, agent.velocity.sqrMagnitude);**

The death animation will be triggered if the boolean variable &quot;Death&quot; in the animator is set to be true:

**if (currentHealth \&lt;= 0 &amp;&amp; !isDead)**

**{**

**animator.SetBool(&quot;Death&quot;, true);**

**}**

![](RackMultipart20211105-4-2u7xbl_html_d1e08fdc07a27124.jpg)

**Camera**

The implementation of the camera is straight forward.

![](RackMultipart20211105-4-2u7xbl_html_c98b6027ae0ad5c3.png)

Each camera has its boundary values that are identified while playing the game. The script refers to the keys pressed and changes the transform properties accordingly.

**Shop**

The main difficulty of the shop system is how to pass the variables between different scenes and reset them when needed, since the characters&#39; abilities and guns will be reset for each level, while the money will be carried to the shop system. To achieve this, we used the &quot;PlayerPrefs&quot; class to store Player preferences between game sessions. Getting and Setting variables in the PlayerPrefs were planned in different scripts to build up a logic which supports the game progression.

**PlayerPrefs:**

To store a variable in the PlayerPrefs: PlayerPrefs.SetInt(&quot;totalMoney&quot;, totalMoney);

To get a variable from the PlayerPrefs: totalMoney = PlayerPrefs.GetInt(&quot;totalMoney&quot;);

After the player clicks on the &quot;play&quot; button in the main menu, all the PlayerPrefs will be destroyed in order to start a new game. All the PlayerPrefs variables are shown as following:

**Check If the abilities have already been sold:**

Ramires:

int isRamiresFMsold; //Faster Movement ability

int isRamiresHDsold; //Higher Damage ability

int isRamiresFUsold; //Faster Unlock ability

int isRamiresHHsold; //HigherHealth ability

Lucas:

int isLucasFMsold;

int isLucasHDsold;

int isLucasFUsold;

int isLucasHHsold;

Andre:

int isAndreFMsold;

int isAndreHDsold;

int isAndreFUsold;

int isAndreHHsold;

**Check if the guns have already been sold:**

Ramires:

int isRamiresGun1Sold;

int isRamiresGun2Sold;

int isRamiresGun3Sold;

Lucas:

int isLucasGun1Sold;

int isLucasGun2Sold;

int isLucasGun3Sold;

Andre:

int isAndreGun1Sold;

int isAndreGun2Sold;

int isAndreGun3Sold;

**To store the money:**

int totalMoney;

**To store the money from the preceding level:**

int PreviousTotalMoney;

**To store the level number:**

int level;

**To store the number of medical kits:**

int totalMK;

In the script GameController.cs, once the level starts, the system will first get the &quot;isSold&quot; variables for each character to see if an ability or a gun is assigned to the character, as well as the totalMoney and totalMK:

**Get variables**

![](RackMultipart20211105-4-2u7xbl_html_72efc9c2ca801ee4.png)

**Check if the variables are with a value of 1 (sold), take Ramires as example:**

**Guns:**

![](RackMultipart20211105-4-2u7xbl_html_ce8a475caebcd51b.png)

**Abilities:**

![](RackMultipart20211105-4-2u7xbl_html_d81db4e3bb241cc3.png)

By checking the variables, the character&#39;s abilities will be modified accordingly in the other scripts. For level 1 (int level == 0), after all the characters are dead, the level will be reloaded after the player presses &quot;retry&quot;. In comparison, for level 2, 3, and 4, after all the characters are dead, the player will be led to the stop panels again with the money set to be the amount of which is from previous levels, and all the abilities and guns reset:

![](RackMultipart20211105-4-2u7xbl_html_e207c34ba6ff4adf.png)

If the level is completed, the system will call the gotoShop() function, in which the level number will increase by 1, the abilities and the guns will be reset, the current money will be saved as 1) totalMoney for shop system, and 2) PreviousTotalMoney for use if the next level fails.

![](RackMultipart20211105-4-2u7xbl_html_51c249b6a1fcf1ca.png)

In the shop system, the controller will get the values of totalMoney, and if an item is purchased, the corresponding PlayerPrefs variables will be set to 1. Each character can only buy one ability and one gun, after one ability button or gun button is pressed, the others will be disabled. If the money is not enough for buying an item, it will be disabled. In the medical kits shop, the controller will get the totalMoney, level, and totalMK, and there will be a button for buying medical kits. After the player finishes buying medical kits, the totalMoney and totalMK will be stored into the PlayerPrefs. The controller will then check the level number and go to the corresponding level scene.

**Stage Pass and Fail**

The script called &#39;GameController&#39; has a &#39;realPlayerCounter&#39; variable. Each time a player dies this counter is decremented. When it reaches 0, the stage fail condition would be fulfilled.

The GetAway Car has a 2D box collider that can count how many players are inside it. This counter is different from the real player counter as it will not be affected by players who died inside the collider area. If the number of alive players is equal to the player count inside the collider, the stage will end.

![](RackMultipart20211105-4-2u7xbl_html_a5dacc338632e84c.png)

When the player exit the collider, it will decrement the player count inside the getaway area.

**User Interface and Scene**

- **Camera Movement**

The camera movement around the map is realized by taking the input from the keyboard and moving the Transform of the camera in the particular direction (transform.Translate(...)). The camera movement is limited by the boundaries of the map with the help of Math.Clamp().

- **Main menu and UI**

![](RackMultipart20211105-4-2u7xbl_html_ccea8027c0783930.jpg)

The main menu is realized with the UI buttons in unity. By setting the On Click () function in the inspector, the buttons will lead to different screens by clicking on them and changing the selected screen to be active. For the &quot;Play&quot; button, a function PlayGame() will be called to switch the scene with a higher index. Other buttons work in a similar way to the described method.

- **GUI**

In the GUI and several other scenes, the text might be updated live during the gameplay. One example is the amount of health and armor on the player cards. These are done by assigning a variable with ToString() method to the text.

- **Scene transition**

There are actually two ways for us to change the game screen. One method is to use canvas, which are used by the pause interface and the game over interface. In this case, when the condition is fulfilled, the SetActive(true) method is used to pop out the canvas. In the pause interface, the SetActive(false) method is used to close the canvas. The second method is to use the loadScene() method to call for a specific scene.

- **Pausing the game**

The pause is done using the &#39;Time.timescale = 0&#39; and resumes is done by resetting it back to 1.

- **Music**

The background music is automatically played since we choose the &#39;PlayOnAwake&#39; setting. The sound effects are triggered using the Play() method.

- Demonstration, Screen and Video captures
  - Screen captures of the completed game, and video capture while the game is playing to illustrate how it is played.

**Demonstration**

link : [https://www.designandmake.org/pages/viewpage.action?pageId=128151524](https://www.designandmake.org/pages/viewpage.action?pageId=128151524)


**Project schedule**

| Timeline | Activities |
| --- | --- |
| Week 9 |
- Final proposal discussion, work distribution, and planning technical explorations
- Sprites preparing
- Starting game development
 |
| Week 10 |
- Level 1 map design
- Technical explorations implementation
- Making animation
 |
| Week 11 |
- Technical explorations discussion and implementation
- Programming
- Making UI
- Drawing sprites for game objects
 |
| Week 12 |
- Finalizing level 1, preparing to make other levels
- Fixing bugs in level 1
- Technical exploration discussion with teachers (online tutorial)
- Finalizing UI
- Finalizing animation
 |
| Week 13 |
- Designing maps and interior for level 2, level 3, and level 4
- Finalizing reusable codes, functions, and prefabs that will be used in other levels
 |
| Week 14 |
- Finalizing all levels
- Fixing bugs
- Preparing for peer evaluation plan
 |
| Week 15 |
- Peer evaluation and collecting feedback
- Fixing bugs and improving the game based on the feedback
- Adding sound effects and background music
- Finalizing the completed game
- Building and uploading the packed project onto the web
- Preparing for final play test and oral presentation, walkthrough video, etc.
 |
| Week 16 &amp; 17 |
- Final play test and oral presentation recording, walkthrough video recording
- Collecting evaluation results from teachers and classmates
- Working on the final project report
 |

**Our Process in creating the game**

Our standard for the game was very high at first. We were trying to make a turn-based strategy game with so many available actions. However after the Unity workshop we realized that making the game was not as easy as it seems like and the realization of our original idea was almost impossible to implement. Therefore we decided to make a drastic change. We make the game into a real time strategy and limit the actions into attack and object interaction. From here we only make minor changes on the idea.

Our biggest problem seems to be caused by the Unity Collaborate features. Sometimes our sync will overwrite others and it would be very troublesome as we have to repeat some actions over and over again. Towards the end of the semester we decide that it would be best if we do not edit the same scene all at once.

The second problem we encountered was with the raycast. It seems that sometimes the raycast would not hit the intended object. We stuck for almost a week on this. When I looked it up on the internet there was one person that had a similar problem. It was not exactly the same so it was pretty rough to find it. It turns out that the collider can sleep and might not always awake. This is why sometimes the collision is not detected. The solution of this is to tick the &#39;always awake&#39; option in the rigid body 2d of the player.

The third problem we encountered was about the transform of certain objects. It appears that sometimes the transform printed in the console may differ from the actual transform properties. we could not find appropriate solutions on the internet as the majority of answers suggest adjusting the transform of the parent object. This did not solve the problem. This forced us to abandon certain features.

Lastly, there was a problem with maintaining a list with currently alive playable characters. It was assumed that list in c# works the same way it does in Java and it would dynamically shrink and adjust objects position whenever an element is removed from the list. It appears this is not the case in c#. This caused an infinite loop bug in the Wrath state as it was not possible to break through the list.

![](RackMultipart20211105-4-2u7xbl_html_9a166020340b07f2.png)

(The red line depicts the range for the generation of a random number to select an object)

According to the algorithm, we decrease the range for randomly generated numbers whenever someone dies. In this sense, if the list operated as in Java, everything would be fine.

Below is the description of the bug

![](RackMultipart20211105-4-2u7xbl_html_b7185af1326204f.png)

Since the list was not shrinking after the object is removed it is possible that the in-between object is eliminated. In this sense, if we keep decreasing the range for the randomly generated number, eventually, we may end up in the situation where the range does not allow us to select the only alive object and forces us to select the object which is already dead. The endless loop will not ever break if an object with positive health is created or the number of alive objects equals to 0. In order to solve this, a half measure was used to look for the situation when there is 1 alive character left. We manually look for it by iterating through the loop and set it as a target and break from the loop. This is definitely not the best solution but it solved the problem. It is a great example how sometimes 2 very similar programming languages may have significant differences.

**Evaluations**

**From your target audience**

According to our initial evaluation plan, our group will conduct our evaluation session based on the following schedule:

**Week 14:** Continue to work on the game and make level one for gameplay testing.

**Week 14:** The first testing session will be on Apr.30th during class.

**Week 14-15:** Collect feedback, make improvements, and ask our classmates to test the gameplay individually.

**Week 15:** Continue to work on the game based on the evaluation result.

However, due to the cancelation of the first testing session and time clashes with other classes, we postponed the evaluation plan as following:

**Week 15:** Complete the game and invite a friend to provide feedbacks

**Week 15 - final playing test on May 17th:** modify and improve the game based on the evaluation result.

We prepared the following questions for two students from IMT --- Zhang Zichuan (19084644D), and CHENG Xu (18078422D):

1. Is there any bug you discover during the gameplay?
2. Is the game control handy and easy to understand?
3. Do you think our game is fun to play? Why or why not?
4. Is there any suggestion you can provide to help us improve our game?

Since all of our team members are in different countries, we were not able to conduct a face-to-face evaluation. Instead, we provided them with the link of the game on the webpage. After they tested the first version of our game, they answered the questions as follows (via WeChat):

Chatting record with ZHANG Zichuan (19084644D):

![](RackMultipart20211105-4-2u7xbl_html_22ef8207d8b3af38.jpg)

Chatting record with CHENG Xu (18078422D):

![](RackMultipart20211105-4-2u7xbl_html_cfc330e21415c463.jpg)

To conclude, the points to be improved are listed as the follows:

1. Lack of gameplay description
2. Bugs about scene transitions, player movement, and AI system
3. Imbalanced economy system

We managed to fix the bugs and improved our game according to the feedback before the final gameplay test on 17/05/2021.

**From your team, yourself and others**

After the final gameplay test, we received more evaluations from the teacher and other students in the class:

The first feedback that we gathered from the audiences was about what game we should make. We had three options for the games; escape game, horror game, and robbery game. Among all of the ideas, the Robbery game appeared to be the most suitable one in terms of feasibility and creativeness. Both the escape game and horror game are exploration games, which means we need to make a big world in which each part of the world has a different &#39;story&#39; and &#39;riddles&#39;. This is the main reason for us to drop both of the ideas. We are afraid that we will spend more time on designing the riddles and stories instead of focusing on the technical aspect of the game. On the other hand, robbery games will use similar game mechanics over and over again. The basic technical details are simple, but we can explore more technical aspects in order to make the game and features more interesting. The game will carry a similar concept (to gain as much money as possible) but each stage will have surprises to challenge the player. In the end, the possibility of focusing more on the technical aspect, becomes the main reason why we choose the robbery game. As a reference of the game creation, we take the inspiration from Payday and Door Kickers.

From the final game, we noticed some similar comments as follows.

Positive feedback:

1. The strategy aspect of the game is interesting as it requires planning, multitasking, and careful consideration.
2. The artstyle is beautiful and suits the game.
3. The background music really fills in the mood of the game.
4. The Fog Of War system gives more challenges for the players.
5. The shop let players prepare themselves for upcoming stages.
6. There is an increasing difficulty as level increases and the alarm system really makes the level 3 and 4 more challenging.
7. There is a clear instruction on the basic function of the game.

What can be improved

1. The Background Music is too loud.

Many people think that the game music is very loud. In truth we have set them to 0.5 volume inside Unity. The suggestion to add a change volume option is well accepted by us and we also think that it would be a good idea for the future so the audience can set their own volume.

1. We can complete the stage without robbing anything

The true objective of the game is to gain as much money as possible at the end of stage four instead of just completing each stage. Without taking money in the previous level, players will not be able to survive in level 4. However, the confusion might be resulted from our lack of clarity in the game objective. We will try to improve this in the future.

1. The UI are too small to be read

Our UI size changes according to the screen resolution. However, it appears that when the screen is too small, the words in the player card are not readable. Our main concern for putting a big UI was it would cover the majority of the screen so it bothers the user. After discussing, our team agrees that it would be best to redesign the player card so it emphasizes on the resources information rather than the player face.

1. Hard to control the camera

We really appreciate this comment as it gives us very good feedback. Making the camera to focus on the active player during player switch would gladly save some time for the player and also makes multitasking easier for them.

1. Makes more correlation between character card and the character itself

Currently our active player indication is only a yellow circle highlighter and the upward transform of the player card. The teacher gave a really good suggestion to change the color of the hp bar according to the color of the shirt in the character image. This would give a better indication on which character is active.

1. Misunderstanding on maximum movement distance for the characters

The character can only respond to a click on a certain distance however some players misunderstood this as a bug. In response to this, we need to explain it clearly in the instruction. Moreover, we need an indication to mark how far a player can go.

1. More actions and stealth option

Since the enemyhas a limited sight area, the player can use it to sneak. However, we did not give an UI interface to visualize this and we did not mention it in our game instruction. We will try to develop this to improve our game. Regarding more action we would love to add more actions as well. Given more time, in the future we would love to add more actions to make the game bigger.

**Conclusion**

To conclude, our game &quot;You know how to rob, here&#39;s a reminder&quot; is a real-time strategy, third-person shooter game with a core concept of planning a robbery. We managed to create an exciting gameplay in which the player has to switch between characters and control them to rob as much money as possible, which requires a good organization of actions the player takes.

In the four levels, the difficulty will increase gradually, and the player can try different strategies to pass the level. For example, the player can choose to buy different abilities and guns in the stop system and to see which combination works the best.

We tried to make our game more interesting and challenging by adding more interactive objects, bigger maps, and stronger enemies etc. And we are all glad that the outcome met our expectations.

Our team had a pretty good chemistry, and we tackled a lot of problems during the whole process. Although it was challenging that we work from different places, we made good use of the unity collab and other communication tools such as the MS teams and whatsapp, and the online resources to help us complete the game. It was a tough but enjoyable process, and we were all excited that our game received valuable compliments and advice from the teachers and classmates after the final evaluation.

**Possible future developments**

For the future development, currently there are two ideas that we can make our game better. The first one is to add more maps. Different maps are one of the selling points for our game since a more challenging and complex map is more fun to play. The second idea is to add the multiplayer mode. Our game will fit well to multiplayer mode since in our game it requires collaborations between each character. If there is a multiplayer mode, different gamers can connect online and work together to pass the level in the real time. Our team has built up the core concept and fundamentals so that the future developments can be completed easier.
