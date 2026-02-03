# HW4
## Devlog
In this project, I used a simplified model-view-control pattern to keep the Player code decoupled from UI and audio systems. The control side is handled by BirdControl.cs and ScoreZone.cs, which manage player input, movement, collisions, and scoring rules without referencing any UI elements. For example, ScoreZone detects when the player passes a pipe using OnTriggerEnter2D and calls GameManager.Instance.AddScore(1) without knowing how the score is displayed. The view side is defined by ScoreTextUI.cs, which is only responsible for displaying the score and updates itself by responding to score-change events. Decoupling is achieved through the use of a Singleton, GameManager, which stores the game state, and events such as OnScoreChanged, which notify the UI and audio systems when the score updates. This event-based approach allows the view and control systems to remain independent, keeping the Player logic clean and modular.

## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites
