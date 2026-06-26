CyberSecurityChatBot
 Cybersecurity Awareness Bot - PROG6221 Parts 1, 2 & 3

Student Information
Namae Ayandiswa Williams  
Student Number [st10468447]

Project Description

This project is a comprehensive **Cybersecurity Awareness Bot** developed as Part 3 of the PROG6221 module. 

- **Part 1**: Basic chatbot with keyword responses and sentiment detection.
- **Part 2**: Enhanced NLP features, conversation memory, and modular architecture.
- **Part 3**: Full integration with Task Management system, Educational Quiz, Activity Logging, and a polished WPF user interface.

The application educates users on cybersecurity best practices through natural conversation, task tracking, and gamified learning.

## Full List of Features (Parts 1, 2 & 3)

### Part 1 Features
- Basic keyword-based responses
- Simple sentiment detection (positive/negative/neutral)
- Welcome message and fallback responses

### Part 2 Features
- Advanced NLP intent recognition (add task, start quiz, show log)
- Conversation memory (`MemoryStore`)
- Rule-based expert system (`KeywordResponder`)
- Sentiment-aware empathetic replies

### Part 3 Features
- Full Task Management (Add, View, Complete, Delete)
- Persistent JSON storage (`tasks.json`)
- Interactive 11-question Cybersecurity Quiz with scoring
- Comprehensive Activity Logging with timestamps
- Modern dark-themed WPF GUI with sidebar navigation
- Menu system and keyboard support (Enter to send)
- Real-time chat interface with rich formatting

## Prerequisites

- Visual Studio 2022
- .NET 8.0 SDK
- Newtonsoft.Json NuGet package

 ## Step-by-Step Setup Instructions

1. Download / Clone the project folder.
2. Open `CyberSecurityChatBot.sln` in Visual Studio 2022
3. Install Newtonsoft.Json (if not already installed):
   - Right-click on the project → manage NuGet Packages
   - Search for `Newtonsoft.Json`
   - Click **Install** (Version 13.0.4 is used)
4. **Build** the solution (`Ctrl + Shift + B`).
5. Run the application (`F5`).

**Note**: `tasks.json` is **auto-created** automatically when the first task is added. No manual setup is required.

# Audio File Setup

Place the file **`greeting.wav`** in the **root folder** of the project (same location as `tasks.json` will appear) or in the `bin/Debug/net8.0-windows/` folder after building.

The application will play this greeting sound on startup.

##  Screenshots

### Running GUI

### GitHub Actions Stat

##  Demo Video

**YouTube Video (Unlisted):**  

##  Releases

- **Release 1 (Part 1)**: Basic chatbot with keyword and sentiment features.
- **Release 2 (Part 2)**: Added NLP intents, memory, and modular design.
- **Release 3 (Part 3)**: Full integration — Tasks, Quiz, Logging, and polished WPF UI with navigation.

---

##  Project Structure
