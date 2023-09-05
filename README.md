# CGT_TIMER
WPF Timer App for Gorilla Tag (CGT). This timer app is specifically preset for CGT matches and scrims, and it is intended for use on Windows 10/11.

# Installation
1. Download the .exe file from Releases
2. Put the .exe file somewhere accessible (e.g., Desktop)
3. (Optional) Pin the .exe file to your Taskbar (right click, pin to taskbar)

# How to Use
After opening the application, you will see a green window with two times on it. The top time is the current running time. The bottom time is the time to beat. You can start/pause/resume/reset the timer. You can set/clear the time to beat.

In OBS, change the Window Capture source to this application and use the same filtering (Chroma Key) that you used for LiveSplit. Resize and position the Window Capture how you want it.

## Hotkeys
- Spacebar: start, pause, or resume the timer
- Delete: reset the timer
- Ctrl+Spacebar: set the time to beat to the current time
- Ctrl+Delete: clear the time to beat
- Esc: close the application

## Mouse
Currently, there are only 2 functions implemented. 
1. Move the application around by dragging the window wherever you want on screen.
2. Right clicking on the window will open the context menu. There is a settings button and Always On Top button.
   - Settings doesn't do anything except open a new window. I will add stuff to this in the future.
   - Always On Top will toggle making the application stay on top. This is useful for when you're casting a scrim/match and you don't want to keep switching between windows.

# TODO
I plan to add a bit more functionality/customization to this app. This includes:
- Make it so hotkeys work regardless of which window is focused.
- Settings
  - Font Selector
    - choose font
    - size
    - style
    - color(?)
  - Map your own hotkeys to start/pause/resume/reset timer and set/clear time to beat
- Modifying/Coloring text based on
  - time (winner - green; loser - red; reset round - yellow)
  - current time is within 2-second rule
  - timecap
- Sound effects(?)
  - runners run
  - taggers tag
  - round over
  - everyone get tagged (reset round due to wrong player being first lava or accidental tag)
  - countdown (for stalling, resetting, etc.)
- Other reffing functions(?)
- Automated scoring for OBS(?)
