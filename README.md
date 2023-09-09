
## Gesnhin Wish Counter 1.5

Welcome!

This app helps you count your pity in Ganehin Impact game for limited banner.
If you are not similiar with pity system check [this](https://game8.co/games/Genshin-Impact/archives/305937).

This app displays your 4 and 5 star counter, and history of pulls.

This repository contains raw project and .rar file with ready to use application.


## Installation
Just unpack ``GenshinWishCounter1.5.rar`` and run ``GenshinWishCounter1.5.exe`` file.

After that app is ready to use.

## Usage/Examples
On the top left side you can see counters for 4 and 5 star character.
Below are three buttons:
- +1 - adds one overall pull. It will Increment you 4 and 5 star counter by 1.
- ★★★★ - resets 4 star counter and increment 5 star counter by 1.
- ★★★★★ - adds 1 to your counters and navigates to another window where you have to choose which 5 star character you got. After adding character both counters will be resets.

Every button is your next pull For example if your 5 star counter had value of 10, and your next pull was a 5 star character, then you should press ★★★★★ button. Added 5 star character will be displayed as when you pulled it at 11 pull. Same goes for 4 star counter. If your 4 star counter had value of 5, and your next pull was a 4 star, then you should click ★★★★ button.

4 star counter is just to display your counter. It will be not added to any list and will not be displayed elsewere. If you are not interested in your 4 star pulls then you dont even have to press ★★★★ button. At the end +1 and ★★★★ button will increment 5 star counter by 1.


After any changes your counters and list will be saved. 


Initially I made this app just for me, so there is no function like editing your list/counters. Once button is clicked a counter will be added and saved in file.
For this moment only way to correct your mistakes is: close your app. Open ``Counter.json`` file in main folder of the app, and edit manually your counters:
```
[

  61, <-- 5 star counter

  0   <-- 4 star counter

]
```
After that just save file and run app again.

In case of mistakes in your pull history there is also a way to correct it in ``PullData.json`` file. Just close the app. Open mentioned file, adn edit it manually:
```
{

    "PulledAt": 29, <-- pull value

    "TheElement": "/Images/electro.png", <-- source path of element

    "CharacterName": "Yae Miko", <-- character name

    "FiftyFiftyResult": "100%" <-- 50/50 result

  },

```
Beware that source of image must have a proper name. You can check ``/Image/`` folder for names of images.
50/50 result should only have one of this values: ``100%`` / ``Win`` / ``Lose``. Otherwise app can crash.

## Author

Kamil Krześ - [usernameAki](https://github.com/usernameAki)
