# gOS
is an operating system written in c# with the Cosmos OS Kit
![alt text](https://i.gyazo.com/f5ba2fb9203a0426d042ba49e4821f12.png)

## Commands
### Power Commands
shutdown: Turns the OS and computer off.

reboot: Reboots the computer.

### Console Commands
reinit: Reinitializes the OS (pseudo-reboot).

clear: Clears the console.

echo (message): Prints the specified message to the console, Not necessary in the current state of the OS right now but planned to be more fleshed out later.

theme (themeID): Changes the theme of the console. 1 = Ice (default), 2 = Plain, 3 = Inferno, 4 = Sahara, 5 = Magic.

### Filesystem commands
ls: Shows all subdirectories and files within current directory.

cd (path): Changes current directory to specified path, if no path is specified it will change the current directory to root.

rm (path): Removes specified directory or file.

mkdir (path): Creates new directory in specified path.

touch (path): Creates new file in specified path.

cat (path): Prints all the lines of specified file.

grep (pattern) (path): Prints lines of text specifed file which match the specified pattern. use flag -h in gOS for more info.

#### WIP filesystem commands
##### These commands are not finished and are not reliable to use

write (path) (text): Writes to specified text to specified file.

writeline (path) (text): Creates new line and writes specified text to specified file.

### Other Commands
beep (frequency): Plays a sound with the specified frequency throught the pc speakers

info: Shows system and OS information.
