# MadboxTechTest
This is the personal explanations on how I did this tech test for my application into Madbox.

Phase 5 and 6 were added after initial delivery.

## How I approached this test:
### Phase 1 - Set up
- I read the whole assignment twice, trying to understand what was required to do completelly.
- I created this repository and a Trello board, in order to keep things ordered and properly prioritized.
- Opened the content given to take a look on how things were organised in it and check if I may need some changes to work comfortably.
- Created all Trello items dividing the things to do in small pieces.

This whole phase lasted like 30 min, as I could do some of those in parallel.

![Trello screenshoot](Trello.png)

### Phase 2 - Customising experience
- I reordered stuff in order to feel comfortable with it, for example, I created new Game Prefabs for Hero and Enemy, making them both inherit from an Unit one.
- This allowed to make both kind of Units to have a health component, a visuals one and Rigidbody+Collider. Things that all of them will share.
- Also unified the AnimatorController State names to be the same. So the visuals component can call same states when needed and became reusable.
- Changed the scene to use the new Hero prefab + make the camera work well with it.
- Add all weapons to hero and just show 1 of them at random.
- Creating a Game Manager and other required Managers to Initialize all in proper order, with Singletons.

This phase was around 1h 30min. Together with last one, done on Friday Afternoon.

### Phase 3 - Feature Development
- Add health component to unit with base events to handle hits/death.
- Make the hero move using the touch logic for the screen.
- Make enemies to spawn up to a maximum, around the hero, with some rules and using a Pool.
- Make hero detect enemies at a fixed distance and face the nearest one.
- Make the hero attack when stopped.
- Create the trigger, adding the layers for the hero/enemy in order to allow hit detection.
- Synch animations with hits.
- Create a visual representation of hitting distance.
- Create a visual representation of targeted enemy.
- Add diferent parameters for weapons and adapt existing code for each modification: attack range, attack speed, movement speed, damage done...
- Create buttons for selecting and changing the weapon and all the inner changes.

This whole feature development toopk around 5h. Done between Saturday afternoon, Sunday morning and Sunday afternoon.

### Phase 4 - Landing
- Final test play on device and polish minor stuff. Device is a low end Huawei P20 Lite (2018).
- Writing this document.

Landing took around 1h.

### Phase 5 - Extra time
 - Added all visual feedback points from Improvements section in Delivered code v1.
   - Added a tool to check FPS performance and memory usage
   - Spawn enemies choreography
   - White frame on hit
   - Health bar for all units
   - Damage particles with DamageNumbersPro
 - Fixed the attacking system to behave properly.

Time spent 2h

### Phase 6 - Additional Features Added
- Create a Win-Lose condition pair
  - Amount of bee to kill to win
  - Time runs out for lose
- Remote Config through Unity Services to be able to change it with no new builds required
- Intro choreography 
- End Screen
- Buttons for reset/retry in-game and in end screen

Time spent 3h

## Difficulties
I have worked in Action games like Archero for the last year and a half. I already have a trained expertise in this specific kind of games. Also have developed previously all features in this game, except for weapon selector/weapon change ingame.  

But, as well as I have this trained skill set, I wanted to do thinks that worked well but with limited time, I had decided to go with Singletons instead of using better long-term SOLID DependencyInversion approach, in order to stick to the plan and be able to finish everything on the required time.

## Improvements
Also, I would like to:
- Not all managers need to be a MonoBehaviour class. Also not need to be Singletons. I have created task maked as Extra to remove that and make the test be more SOLID like using a ServiceLocator tool like [Reflex Dependency Injection](https://github.com/gustavopsantos/Reflex).
- ~~test a better approach on how attacking using the onTriggerStay logic works. I assume current logic with trigger in sword may work better with the onTriggerEnter, as we enable/disable properly with current coreography.~~  
- ~~Spawning enemies feels so popping, as I'm used to some great effects, with a bit more time I could recover old assets I have and add them.~~  
- ~~I also feel like hitting has not enough feedback, so I would add a white frame (changing material to a full white one) during 0.1s + add the damage using a very helpful tool called [Damage Numbers Pro](https://assetstore.unity.com/packages/2d/gui/damage-numbers-pro-186447)~~  
- ~~Last but not least, I'd love to add a health bar, on the Unit prefab. I did not add it because I felt it will be a 100% copy of what I have already done in other projects. I used a 2 bar system Green(top)/White(middle) over a dark backgrouind: When damage is received, green bar empties immediately, white bar empties progressive till it's hidden under the green one.~~


## Further Development
- ~~I would also like to have time to create a win-lose condition~~. 
- Regarding Enemies:
    - Make Enemies randomly move, pursuit and attack the player. So there is a thread to the hero other than time running out. I didn't include it because it may need a lot of readjust to current melee behaviors. In that case, having a melee weapon should be an option.
        - As a proof of knowledge of this topic, I include some references on next section so you can check.
    - May be able to drop items (xp/health potions) on death and hero can collect them.
    - Enemies will grow in hp and damage the more time it passes, at spawn time.
    - Create More enemies to have more variety.
- Do a more elaborate maps with hazards, like spikes or poison that can hurt or give the hero some status effect, or holes, so only flying units can go over them.
- I feel like a "Fog of war" System, similar to Age of empires one, will fit very well.
- And a long of things to make the test to feel more like Archero.

## Other
I'm quite proud of what my team and I did and I suggest to take a look at my other repo called [Planet Royale Repo](https://github.com/AlexandreAlberti/PlanetRoyale) which has a minor bug solved, or download the latest build from the [Google Play Store](https://play.google.com/store/apps/details?id=com.quicksand.planetroyale)  

You can find any other game I participated and released for [QuickSand Games](https://play.google.com/store/apps/dev?id=6383870736725209348) in my CV. The first ones have a Fog of War System, like the mentioned in previous section.

Thanks a lot for the opportunity to participate in your selection process.
