
## Gesnhin Wish Counter 1.5

Welcome!

This app helps you count your pity in Ganehin Impact, Honkai Star Rail, and Zenless Zone Zero game for limited banners.
If you are not familiar with pity system check [this article](https://game8.co/games/Genshin-Impact/archives/305937).

This app displays your 4 and 5 star counter, and history of your 5* pulls.

This repository contains raw project and .zip file with ready to use application.


## Installation
Make sure you have installed [.NET 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

Just unpack ``GenshinWishCounter.zip`` and run ``GenshinWishCounter1.5.exe`` file.

After that app is ready to use.

## Usage/Examples
On the top left side you can see counters for 4 and 5 star character.
Below are three buttons:
- +1 - adds one overall pull. It will Increments your 4 and 5 star counter by 1.
- ★★★★ - resets 4 star counter and increments 5 star counter by 1.
- ★★★★★ - adds 1 to your counters and navigates to another window where you have to choose which 5 star character / weapon / light cone you got. After adding character both counters will be resets.

Every button is your next pull. For example if your 5 star counter had value of 10, and your next pull was a 5 star character, then you should press ★★★★★ button. Added 5 star character will be displayed as when you pulled it at 11 pity. Same goes for 4 star counter. If your 4 star counter had value of 5, and your next pull was a 4 star, then you should click ★★★★ button.

4 star counter is just to display your counter. It will be not added to any list and will not be displayed elsewere. If you are not interested in your 4 star pulls then you don't even have to press ★★★★ button. At the end +1 and ★★★★ button will increment 5 star counter by 1.

After any changes your counters and list will be saved automatically. 

In the top left corner you can find small menu which allow you to change banner (for now it has ugly design. Will be updated in the future).


Initially I made this app just for me, so there is no function like editing your list or counters. Once button is clicked a counter will be added and saved.
However, you can still edit files.. 
You can delete ``Counter.json`` or ``Pulls.json`` to reset your counters or history.
You can also correct your mistakes. For counters: close your app, open ``Counter.json`` file in main folder of the app, and edit it manually:
```
{
  "genshinCharacterCounterModel": {
    "Counters": [
      22, <-- 5* counter
      8   <-- 4* counter
    ]
  }
}
```
After that just save file and run app again.

Similiar goes for your history. Just close the app, open ``Pulls.json`` file, and edit it:
```
{
  "genshinCharacterPullHistoryModel": {
    "PullList": [
      {
        "PulledAt": 1, <-- as it says
        "Type": "/Images/anemo.png", <-- must be "/Images/{name}.png"
        "Name": "Jean", <-- must match name from Images folder
        "FiftyFiftyResult": "Lose" <-- 50/50 result
      }
    ]
  }
}

```
Beware that source of image must have a proper name. You can check ``/Images/`` folder for names of images.
50/50 result should only have one of this values: ``100%`` / ``Win`` / ``Lose``. Otherwise app can not work properly.

## Author

Kamil Krześ - [usernameAki](https://github.com/usernameAki)
