# OOP_assignment

# Pink Man – The Enchanted Apple Quest

## Course
**TEB1043 – Object Oriented & Programming**  
**May 2025**  
**Lecturer:** Nordin Zakaria :contentReference[oaicite:8]{index=8}

## Project Overview
Pink Man – The Enchanted Apple Quest is a 2D side-scrolling platformer where players guide Pink Man through five increasingly challenging levels to collect mystical apples and restore magic to the land of Orchardia. :contentReference[oaicite:9]{index=9}

## Table of Contents
- [Prerequisites](#prerequisites)  
- [Installation & Setup](#installation--setup)  
- [Opening the Project in Unity](#opening-the-project-in-unity)  
- [Project Structure](#project-structure)  
- [Gameplay Overview](#gameplay-overview)  
- [Objective](#objective)  
- [Team Members & Contributions](#team-members--contributions)  
- [Links](#links)  
- [License](#license)  
- [Contact](#contact)

## Prerequisites
- **Unity 6000.0.49.f1** (tested with this editor)  
- Git (>= 2.20)  
- Optional: Visual Studio or VS Code for C# editing

## Installation & Setup
1. Clone this repository:  
   ```bash
   git clone https://github.com/scip32/OOP-Game-Project.git
   cd OOP-Game-Project

    Ensure .gitignore (Unity template) is present to exclude cache, build, and IDE files.

    (Optional) If using large assets, install Git LFS and run:

    git lfs install
    git lfs track "*.png" "*.mp4"
    git add .gitattributes

Opening the Project in Unity

    Open Unity Hub.

    Click Add, navigate to this folder (containing Assets/, Packages/, ProjectSettings/), and add it.

    Select the project in Hub and click Open. Unity will regenerate Library/ and load all assets.

Project Structure

OOP-Game-Project/
├── .gitignore
├── README.md
├── LICENSE
├── Packages/
├── ProjectSettings/
├── Assets/                   # Scenes, art, prefabs, scripts, etc.
└── game_prog/               # Core C# program folder and scripts

Gameplay Overview

    Level 1: Basic Awakening — Learn to move and jump while collecting 10 apples.

    Level 2: Forest Frenzy — Dodge frogs and gather 12 apples.

    Level 3: Barnyard Blitz — Avoid frogs on farm-themed terrain while collecting 14 apples.

    Level 4: Bridge of Peril — Cross moving blocks and spike traps to collect 16 apples.

    Level 5: Trial of Reversal — Navigate rotating platforms to secure the final 18 apples. 

Objective

Complete all five levels, overcome each unique obstacle, and restore the power of the Great Apple Tree.
Team Members & Contributions
Name	Student ID	Programme	Contributions
Ch’ng Zhe Wei	22010417	Information Technology	Map layout for Part 2 & 5; Tilemap for Part 1; final adjustments; video capture & upload; code upload; documentation; UML diagram; implemented PlayerMovement, FrogNPCMovement, ItemCollector, DieMapArea
Zhi Siyuan	24006912	Information Technology	Tilemap for Part 3 & modifications to Part 1; character actions (pickup, damage reactions); Start/End UI; spike trap code; documentation; implemented RotatedBlock, StartMenu, EndMenu, MovingBlock
Muhammad Haziq Bin Mohd Shahruddin	22006459	Information Technology	Tilemap for Part 4; trap and obstacle integration; documentation
Links

    GitHub Repository: https://github.com/scip32/OOP-Game-Project

    Video Demo: https://youtu.be/wJaSEyFGyag?feature=shared 

License

This project is licensed under the MIT License. See LICENSE for details.
Contact

Chng Zhe Wei – Project lead
Email: CHNG_22010417@utp.edu.my
GitHub: scip32

for complete documentation check on OOP DOCUMENTATION.pdf
