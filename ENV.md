# Development Environment

- VS Code
- Windows Terminal
- Git for Windows
- WSL
- Docker Desktop

## VS Code

Standard installation

## Windows Terminal

Standard installation from Windows Store

## Git for Windows

Select the following options
- "Add a Git Bash Profile to Windows Terminal"
  - This allows us to use git bash in Windows Terminal with ease
- "Use Visual Studio Code as Git's default editor"
- Under "Adjusting your PATH environment", select "Git from the command line and also from 3rd-party software" (the recommended option)
- Under "Choosing HTTPS transport backend", it seems like "Use the native Windows Secure Channel Library" might be a really good option.
- "Checkout as-is, commit Unix-style line endings" (i.e., core.autocrlf=input). This works better when developing in WSL and Docker environments in parallel with Windows, and we will use a committed `.editorconfig` to control our line endings anyway.
- "Only ever fast-forward" for git pull
- Use "Git Credential Manager Core"

## WSL + Docker Desktop

* https://docs.microsoft.com/en-us/windows/wsl/install-win10
* https://docs.microsoft.com/en-us/windows/wsl/tutorials/wsl-containers

## Notes

- VS Code doesn't have in-built support for `.editorconfig` files, which seems really out of place to me. 

## Set up git in the container

VS Code DevContainers do a lot of magic when they set themselves up, including making adjustments to the global git config of the container.

This can cause problems with inheriting settings from the host system, e.g., [issue](https://github.com/microsoft/vscode-remote-release/issues/2267).

You can modify your local settings as follows
```json
{
  "remote.containers.copyGitConfig": false
}
```

Unfortunately, this setting cannot be committed to `.vscode/settings`, as VS Code does not read the setting in time to use it.

In a larger organization, I could imaging a set of helper scripts in the `~` folder for the dev user that helps you to finish setup after the container is built. If the environment is completely homogenous, then the script can just be run by the dev container's `postCreateCommand` hook, otherwise developers would be responsible for running the script themselves after a rebuild.

```sh
# don't use nano
git config --global core.editor "code --wait"

# share credential manager on windows
# note that git-credential-manager-core replaces both git-credential-manager and git-credential-wincred.exe
# the core cred manager has support for 2FA among other things
git config --global credential.helper "/mnt/c/Program\ Files/Git/mingw64/libexec/git-core/git-credential-manager-core.exe"
```
