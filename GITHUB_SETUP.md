# Unity Project GitHub Setup Guide

Your Unity project is now ready to use with GitHub! Here's what to do next:

## What This .gitignore Does

✅ **Excludes large auto-generated folders:**
- `Library/` - Unity's cache (5-30GB)
- `Temp/` - Temporary build files
- `Logs/` - Log files
- `obj/` and `Build/` - Compiled builds
- `.vs/` - Visual Studio cache

✅ **Excludes auto-generated files:**
- `*.csproj` - Unity regenerates these
- `*.sln` - Solution files
- IDE files (Rider, Visual Studio Code)

✅ **Keeps essential files:**
- `Assets/` - Your game content
- `ProjectSettings/` - Project settings
- `Packages/` - Package dependencies

## How to Set Up GitHub (First Time)

### Step 1: Initialize Git Repository
```powershell
cd "C:\Users\lucas\Documents\MyCode\MyCode\Code\unity\Veil Of Valor"
git init
```

### Step 2: Add All Files
The .gitignore will automatically exclude the large folders:
```powershell
git add .
git commit -m "Initial commit: Unity project setup"
```

### Step 3: Create GitHub Repository
1. Go to https://github.com/new
2. Create a new repository (e.g., "Veil-Of-Valor")
3. **DO NOT** initialize with README, .gitignore, or license (you already have files)

### Step 4: Connect and Push
Replace `YOUR_USERNAME` and `YOUR_REPO` with your details:
```powershell
git branch -M main
git remote add origin https://github.com/YOUR_USERNAME/YOUR_REPO.git
git push -u origin main
```

## How Teammates Clone the Project

Your teammates simply clone the repository:
```powershell
git clone https://github.com/YOUR_USERNAME/YOUR_REPO.git
cd YOUR_REPO
```

Then open the folder in Unity Hub. Unity will automatically:
- Regenerate the `Library/` folder
- Regenerate the `Temp/` folder
- Recreate `.csproj` and `.sln` files
- Set up everything needed to run the project

## Daily Workflow

### Making Changes
```powershell
# See what changed
git status

# Add your changes
git add .

# Commit with a message
git commit -m "Added new player controller"

# Push to GitHub
git push
```

### Getting Teammate's Changes
```powershell
# Pull latest changes
git pull
```

## Important Notes

⚠️ **Before First Push:**
- Make sure `.gitignore` is in the root directory
- Close Unity before committing (avoids file locks)
- First push might take a few minutes (uploading all assets)

✅ **After Setup:**
- Project size on GitHub: ~200MB-2GB (instead of 10-50GB)
- Fast cloning for teammates
- Version control for all your code and assets
- Automatic conflict resolution for most files

## Troubleshooting

**"Repository size too large"**
- GitHub has a 100GB soft limit
- If you have massive assets (4K textures, videos), consider Git LFS

**"File exceeds 100MB"**
- Use Git LFS for individual large files:
```powershell
git lfs install
git lfs track "*.psd"
git lfs track "*.mp4"
git add .gitattributes
```

**"Merge conflicts"**
- For `.unity` scene files, use Unity's Smart Merge
- For code files, resolve manually

## Quick Commands Reference

```powershell
# Check status
git status

# See what changed
git diff

# Add all changes
git add .

# Commit changes
git commit -m "Your message"

# Push to GitHub
git push

# Pull from GitHub
git pull

# See commit history
git log --oneline

# Create new branch
git checkout -b feature-name

# Switch branches
git checkout main
```

## Next Steps

1. Run the commands in "Step 1-4" above
2. Share the GitHub repository URL with your team
3. They clone it and open in Unity
4. Start collaborating! 🚀

---

**Need help?** Check the log files in `unity_packager_logs/` if you encounter issues.
