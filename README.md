# SpaceEx — 2D Space Shooter
**Unity · C# · Object Pooling · Wave Spawning · Boss AI**

A complete 2D arcade space shooter featuring data-driven wave spawning, a reusable object pool, composite enemy AI with homing variants, and a full game flow from splash screen to credits.

---

## Overview

Built as a self-contained production-style project covering the full lifecycle of an arcade shooter — menus, gameplay loop, scoring, persistence, and credits. Emphasis on clean composition and reusable systems rather than monolithic scripts.

---

## Systems

### Object Pool
`Objectpool.cs` — Singleton pool using `Queue<GameObject>` per object type, indexed by name. Eliminates runtime instantiation/destruction during gameplay. All projectiles and enemies are drawn from and returned to the pool.

### Wave Spawning
`EnemySpawner.cs` + `WaveConfig.cs` — Data-driven wave definitions drive spawn timing, enemy type, and path assignment. Adding a new wave requires only a new `WaveConfig` asset — no code changes.

### Enemy AI
- **Orbital pathing** — enemies follow pre-authored path configs (`EnemyPathing.cs`)
- **Homing variant** — `Homing.cs` tracks and intercepts the player
- **Boss** — `BossAi.cs` handles phase-based behaviour separate from standard enemies

### Player Composition
Player is split across three components — `Player.cs` (health/state), `Movement.cs` (input/translation), `Shoot.cs` (fire rate/projectile dispatch) — keeping each concern independently modifiable.

### Persistence
High score stored and retrieved via `PlayerPrefs`. Score and wave count surfaced through TMP HUD.

---

## Scene Structure

| Scene | Purpose |
|-------|---------|
| Splash | Entry, branding |
| Menu | Main menu + options |
| Loading | Async transition |
| Level 1 | Core gameplay |
| Game | Game loop manager |
| Credits | End screen |

---

## What This Demonstrates

- Object pooling with dictionary-indexed queues
- Data-driven spawning via ScriptableObject-style wave configs
- Composite player architecture (input / movement / shooting separated)
- Coroutine-based fire timing for both player and enemies
- Full game flow with scene management

---

## Tech

- Unity 2019.3 · C#
- TextMeshPro
- No third-party dependencies
