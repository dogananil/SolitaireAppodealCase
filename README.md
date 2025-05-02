# Solitaire Developer Case Study

## 🧩 What I Built

This is a modular prototype of a simplified Solitaire-style mobile game, developed in Unity. It demonstrates a fully functional **Undo Move system**, along with clean UI architecture, runtime instantiation, and SOLID principles throughout.

### ✅ Key Features
- **Drag-and-Drop Card Movement** between 3 card stacks
- **Undo System**: Reverts the last move via a centralized `UndoManager`
- **Score Tracking**: +1 on move, -1 on undo, displayed live
- **Runtime UI System**:
  - Views are instantiated via `UIManager` and `Addressables`
  - UI is powered by `IUIData` + `IUIView<T>` interfaces
- **Service Locator Architecture**:
  - Decoupled services: `UIManager`, `UndoManager`, `ScoreManager`
  - All services registered via a `Bootstrap` at runtime
- **Addressables** used instead of `Resources.Load`
- **Canvas and EventSystem** are scene-driven, all else is runtime

---

## 🔧 Tech & Architecture

- **Unity 6000.0.40f1 (2023 LTS)**
- **2D UI-based architecture**
- **UniTask** for async operations (no coroutines)
- **Addressables** for prefab management
- **Strict SOLID principles**
  - `IUndoManager`, `IUIManager`, `IGameInitializer`, `IScoreManager`
  - No singletons, all logic is testable and modular

---

## 🛠 What I'd Improve with More Time

- Add a **Redo System** and full command pattern for move history
- Implement **game state saving/loading** (stack data, score)
- Add **transition animations** and visual polish with DOTween
- Create a **view stack or UI layering system** for modal flows
- Add **unit tests** for core services (e.g., `UndoManager`, `ScoreManager`)
- Better UX for card snapping / valid move feedback

---

## 🤖 AI Assistance

I used **ChatGPT-4** to:
- Plan the architecture and system breakdown
- Refine implementation of SOLID-compliant UI/undo systems
- Generate boilerplate code for services and interfaces
- Debug Addressables and scene setup

Prompts used included:
- “Build a SOLID undo system in Unity for Solitaire”
- “How to structure a modular UI architecture using interfaces and addressables”
- “Fix: Addressables prefab instantiation returns null”
- “Create Unity UI prefab view system with IUIData and IUIView”

All AI-generated content was reviewed, refactored, and integrated into a coherent, professional solution.

---

## 📦 How to Run

1. Open the project in Unity
2. Ensure `Card.prefab` and `GameplayView.prefab` are marked Addressable:
   - `"Card"` and `"GameplayView"` keys
3. Build Addressables:  
   `Window → Asset Management → Addressables → Build → New Build`
4. Press Play — the system initializes automatically via `Bootstrap.cs`

---

## 📫 Submission

Project submitted per the case instructions.  
If any issues arise or you'd like to discuss design choices, I'm happy to walk through them!

