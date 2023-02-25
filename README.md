# ValorantTS


## What's that ? 🤔
ValorantTS is the easiest way to use true stretched resolution on VALORANT

## What is true stretched ❓
By default, VALORANT disables the ability to play in a stretch resolution like in Counter-Strike, they only stretch the HUD (which is useless except for the crosshair)
true-stretched resolution is everything stretched.

## Without/With
![without](https://user-images.githubusercontent.com/47573987/185723174-a042a516-2e94-4276-9ac1-a1b273170dea.jpg)
![with](https://user-images.githubusercontent.com/47573987/185723178-6c804314-a3d9-4425-b153-0e240047e5a3.jpg)


## How to ? 😥
After you downloaded the binaries, open ``user.json``, inside replace ``Resolution`` by the stretched resolution you want to have and ``DefaultResolution`` by your monitor default resolution (e.g: 1920x1080)

**Userid**: Press Windows Key + R type 'AppData' and click OK, go to ``Local\VALORANT\Saved\Config\`` and then you should find a folder looking like this ``x9cfyg4c-a8a1-5ag7-e956-2e96bvb7gxcp-na`` here is your userid.

Start the program and enjoy !


NOTE: When the game is fully started, the program will ask you to press enter. Make sure that your video settings are set to `Windowed` and `Fill` before pressing enter. You may experience black bars if it is not on `Fill`. When you restart the game, the game may be revert the settings, so make sure to check this setting each time. the resolution should not matter
![image](https://user-images.githubusercontent.com/35702680/221350489-70d71004-40ea-41d2-97b1-60d09ba17b7f.png)

## How does it work ? ⚙

First, the program change your game's config to match your default res and settings to use true-stretched (it also prevents VALORANT from changing your settings back).
Once this is done, the program will change WS_BORDER to remove them, and then set the game to Maximized.
The resolution is changed using QRes.

If you're having issues where the resolution is not centered / too stretched, make sure you put back windowed mode at your default res every time you launch Valorant

NOTE: every time you ALT+TAB, your resolution will be changed automatically to your default res and will be changed back to stretch one back in game.

## Is it safe ? 🔒
Some people claimed that they got banend using true stretched, however i don't think these ellegations are true: The technique used to make true stretched working does not interract with the game directly (game memory). The only thing that could be debatable is modifying ``WS_BORDER`` and even this, i don't think this should cause any issue since it's a windows property that every application has and not part of the VALORANT game itself.


Credits: QRes
