# Papa's What-Is-Going-On-Eria

## Welcome to the Kitchen!

Papa's What-Is-Going-On-Eria is a short game inspired by [Papa's Pizzeria](https://www.coolmathgames.com/0-papas-pizzeria). However, this version is a little bit different. For one, your player can move around the 2-dimensional space to go to each of the stations. Furthermore, something interesting happens every time you complete an order:one of the ingredients becomes corrupted and unusable! The Papa's What-Is-Going-On-Eria staff still has not released a public statement about this phenomenon, so it looks like you'll be serving up some burgers without buns, potentially.

This game was made for COMP_SCI 376-0 in about a week and a half.

## Player Controls
- WASD or arrow keys to move up, left, down, or right, respectively.
- Left mouse button to click on buttons/objects.
- E to interact with an object.
- Escape to exit a UI canvas.

## Instructions
The core loop follows this general structure:

1. Get an order from the order counter (cash register).
2. Prepare the meat (stovetop).
3. Assemble the burger (counter with cutting board).
4. Pour the soda (soda machine).
5. Send the order off (counter with orange lunch tray).

This core loop will be repeated until the 3:00 minutes are up. As for more detailed instructions about each of the five stations:

- Interacting with the order counter will automatically bring up a receipt on the right-hand side of the screen detailing all of the ingredients necessary for the order. The circle at th e bottom left split into four quadrants determines how long the meat needs to be cooked, and the circle at the bottom right indicates the soda accompanying the order.
- Interacting with the stovetop will automatically bring up a panel with the stove and different stacks of meat. Click on the meat you want to cook, and it will automatically appear on the stove burner. The timer at the bottom left of the screen will start. Click on the meat again when you think it is done, and it will be removed from the burner and automatically placed at the next station. Press the "X" button or press escape to close the panel.
- Interacting with the cutting board counter will automatically bring up a panel with a plate, bins of ingredients, the cooked meat, a trash can, a couple other buttons. Click on the bin with the ingredient you wish to place, and it will create a semi-opaque copy of the ingredient which will follow around your mouse. Click again on the plate where you wish to place this ingredient, and it will leave your cursor and show up opaque on the plate. If you wish to change the ingredient before placing it, click on the trash can. Similarly, click on the meat to grab it and click on the plate to place it. Once you are satisfied with your assembled burger, click the done button to send it off. Press the "X" button or press escape to close the panel.
- Interacting with the soda machine will automatically bring up a panel with the soda machine, containing three buttons for each of the three sodas which can be dispensed, and a cup. Simply press the button of the soda you wish to pour and it will pour automatically into the cup. When you are satisfied, press the done button to send it off. Press the "X" button or press escape to close the panel.
- Interacting with the counter with the orange lunch tray will automatically submit your order and score it. You will see a nice confetti effect to indicate that the order has been completed.

### Scoring
At the start of each order, you will gain 100 points. Points will be deducted accordingly for any of the following reasons:

- Your meat is cooked incorrectly.
- You used the incorrect ingredients/assembled the burger incorrectly.
- You poured the wrong soda.
- Your ingredients are assembled in a way that isn't centered.

## Getting Started

### Prerequisites

- This project was made in [Unity 2021.3.10f1](https://unity3d.com/get-unity/download/archive)
- The game is locked in 1920x1080 resolution on a Windows system.

### From Unity Editor

If you wish to play the game from the Unity editor, clone the repository. Open the project in Unity. Navigate to the Assets -\> Scenes folder, and there, click the "Start Menu" scene.
Click play at the top of the screen in the Unity editor, and play!

### Build

A build is available for download in this repository. Simply download and run it!

## Resources (Credits)

All of the assets in this game are my own aside from a few, which are provided below.

- [Candy Beans font](https://www.dafont.com/candy-beans.font)
- [Receipt font](https://www.dafont.com/fake-receipt.font)
- [Confetti](https://opengameart.org/content/confetti-effect-spritesheet)
- [Coin sound](https://www.youtube.com/watch?v=mQSmVZU5EL4)
- [Pop sound](https://www.youtube.com/watch?v=eZrQ_Q8qT_U)
- [Trash can sound](https://www.youtube.com/watch?v=H9viOVIllnA)