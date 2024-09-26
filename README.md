# Cutscene System for Unity

Cutscenesystem is a utility package where cutscene will display using comic strip style. Unity timeline is being used for the system

## Table of Contents

1. [Installation](#installation)
2. [Getting Started](#getting-started)
   - [Initialization](#initialization)


## Installation


### Install via Git URL
You can also use the "Install from Git URL" option from Unity Package Manager to install the package.
```
https://github.com/Studio-23-xyz/com.studio23.ss2.cutscenesystem.git#upm
```

## Getting Started

### Initialization

1. Select one of the three templates for the cutscene template, which is located on the Runtime/Prefabs/ directory.

2. Assign desired texture/images to the page.

3. Create a Timeline on Window > Sequencing > Timeline

4. Add Track Asset by selecting (+) icon and Studio23.SS2.Cutscenesystem.Core > CutsceneTrack

5. Add New CutsceneClip Timeline on the track

6. Assign desired page object onto the clip inspector to travese the page animation flow.

7. You can use Activation Track/Audio Track for better use of the timeline.

8. Sample scene can be helpful for understanding better. 

### Scene Setup

1. Each template prefab contains Cutscene Controller class, where OnPageAdvance, OnPageSkip two events expose.

2. OnPageAdvance event will trigger after a segments of Comicsprite is shown.

3. OnPageSkip event will trigger after whole segments of Cutscene page is loaded.



